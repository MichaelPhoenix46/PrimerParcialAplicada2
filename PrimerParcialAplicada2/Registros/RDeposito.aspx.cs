using BLL;
using Entities;
using PrimerPacialAplicada2.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerPacialAplicada2.Registros
{
    public partial class RDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaCombo();
        }

        private void Limpiar()
        {
            DepositoIdTextBox.Text = "0";
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
        }

        private Deposito LlenaClase()
        {
            Deposito deposito = new Deposito();
            deposito.DepositoId = Utils.ToInt(DepositoIdTextBox.Text);
            deposito.CuentaId = Utils.ToInt(CuentaIdDropDownList.Text);
            deposito.Concepto = ConceptoTextBox.Text;
            deposito.Monto = Utils.ToDecimal(MontoTextBox.Text);
            deposito.Fecha = DateTime.Now;
            return deposito;
        }
        private void LlenaCampos(Deposito deposito)
        {
            Limpiar();
            DepositoIdTextBox.Text = Convert.ToString(deposito.DepositoId);
            CuentaIdDropDownList.Text = Convert.ToString(deposito.CuentaId);
            ConceptoTextBox.Text = deposito.Concepto;
            MontoTextBox.Text = Convert.ToString(deposito.Monto);
        }

        protected void LlenaCombo()
        {
            RepositorioBase<Cuenta> repositorioBase = new RepositorioBase<Cuenta>();

            CuentaIdDropDownList.DataSource = repositorioBase.GetList(t => true);
            CuentaIdDropDownList.DataValueField = "CuentaId";
            CuentaIdDropDownList.DataTextField = "CuentaId";
            CuentaIdDropDownList.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Deposito> repositorio = new RepositorioBase<Deposito>();
            var deposito = repositorio.Buscar(Utils.ToInt(DepositoIdTextBox.Text));

            if (deposito != null)
            {
                Limpiar();
                LlenaCampos(deposito);

                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
                Utils.ShowToastr(this.Page, "El deposito que intenta buscar no existe", "Error", "error");
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Deposito deposito = new Deposito();
            bool paso = false;
            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }
            deposito = LlenaClase();
            if (deposito.DepositoId == 0)
                paso = repositorio.Guardar(deposito);
            else
                paso = repositorio.Modificar(deposito);
            if (paso)
            {
                Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
            }
            else
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DepositoIdTextBox.Text);
            DepositoRepositorio repositorio = new DepositoRepositorio();
            if (repositorio.Eliminar(id))
            {
                Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
            }
            else
                Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
            Limpiar();
        }
    }
}