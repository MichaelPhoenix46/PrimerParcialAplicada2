using BLL;
using Entities;
using PrimerPacialAplicada2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.Registros
{
    public partial class RPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void Limpiar()
        {
            PrestamoIdTextBox.Text = string.Empty;
            CuentaTextBox.Text = string.Empty;
            CapitalTextBox.Text = string.Empty;
            InteresTextBox.Text = string.Empty;
            TiempoMesesTextBox.Text = string.Empty;
            ViewState["detallePrestamo"] = null;
        }

        private Prestamo LlenaClase(Prestamo prestamo)
        {
            prestamo.PrestamoId = Utils.ToInt(PrestamoIdTextBox.Text);
            prestamo.CuentaId = Utils.ToInt(CuentaTextBox.Text);
            prestamo.Capital = Utils.ToInt(CapitalTextBox.Text);
            prestamo.InteresAnual = Utils.ToInt(InteresTextBox.Text);
            prestamo.Meses = Utils.ToInt(TiempoMesesTextBox.Text);
            prestamo.Fecha = DateTime.Now;
            prestamo.Detalle = (List<DetallePrestamo>)ViewState["detallePrestamo"];
            return prestamo;
        }
        private void LlenaCampos(Prestamo prestamo)
        {
            Limpiar();
            PrestamoIdTextBox.Text = prestamo.PrestamoId.ToString();
            CuentaTextBox.Text = prestamo.CuentaId.ToString();
            CapitalTextBox.Text = prestamo.Capital.ToString();
            InteresTextBox.Text = prestamo.InteresAnual.ToString();
            TiempoMesesTextBox.Text = prestamo.Meses.ToString();
            FechaTextBox.Text =prestamo.Fecha.ToString();
            prestamo.Detalle = (List<DetallePrestamo>)ViewState["detallePrestamo"];
            PrestamoGridView.DataSource = prestamo.Detalle;
            PrestamoGridView.DataBind();
        }
        



        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            var prestamo = repositorio.Buscar(Utils.ToInt(PrestamoIdTextBox.Text));

            if (prestamo != null)
            {
                Limpiar();
                LlenaCampos(prestamo);

                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this.Page, "El prestamo que intenta buscar no existe", "Error", "error");
        }

        protected void CacularButton_Click(object sender, EventArgs e)
        {
            Prestamo prestamo = new Prestamo();
            DetallePrestamo detalle = new DetallePrestamo();
            List<DetallePrestamo> detallePrestamolista = new List<DetallePrestamo>();
            decimal capital = Utils.ToDecimal(CapitalTextBox.Text);
            decimal interes = Utils.ToDecimal(InteresTextBox.Text) / 100;
            int meses = Utils.ToInt(TiempoMesesTextBox.Text);
            decimal total;
            int cuota=0;

            for (int i = 0; i < meses; i++)
            {
                detalle.InteresMensual = interes * capital / meses;
                detalle.CapitalMensual = capital / meses;
                total = detalle.InteresMensual * meses + capital;
                prestamo.Total = detalle.InteresMensual + detalle.CapitalMensual;
                cuota = cuota += 1;

                if (i == 0)
                {
                    detalle.Balance = total - (detalle.InteresMensual + detalle.CapitalMensual);
                }
                else
                    detalle.Balance = detalle.Balance - (detalle.InteresMensual + detalle.CapitalMensual);

                if (i == 0)
                {
                    detallePrestamolista.Add(new DetallePrestamo(cuota, 0, detalle.Fecha, Utils.ToInt(PrestamoIdTextBox.Text),detalle.InteresMensual, detalle.CapitalMensual, detalle.Balance));
                }
                else
                {
                    detallePrestamolista.Add(new DetallePrestamo(cuota,0, detalle.Fecha, Utils.ToInt(PrestamoIdTextBox.Text), detalle.InteresMensual, detalle.CapitalMensual, detalle.Balance));
                }



            }
            ViewState["Cuotas"] = detallePrestamolista;
            PrestamoGridView.DataSource = ViewState["Cuotas"];
            PrestamoGridView.DataBind();

        }


        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            PrestamoRepositorio repositorio = new PrestamoRepositorio();
            Prestamo prestamo = new Prestamo();
            bool paso = false;
            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }
            prestamo = LlenaClase(prestamo);
            if (prestamo.PrestamoId == 0)
                paso = repositorio.Guardar(prestamo);
            else
                paso = repositorio.Modificar(prestamo);
            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
            }
            else
                Utils.ShowToastr(this.Page, "Revisar todos los campos", "Error", "error");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(PrestamoIdTextBox.Text);
            PrestamoRepositorio repositorio = new PrestamoRepositorio();
            if (repositorio.Eliminar(id))
            {
                Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
            }
            else
                Utils.ShowToastr(this.Page, "Fallo al Eliminar", "Error", "error");
            Limpiar();
        }
    }
}