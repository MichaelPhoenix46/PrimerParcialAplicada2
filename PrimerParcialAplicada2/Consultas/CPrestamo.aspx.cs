using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerPacialAplicada2.Consultas
{
    public partial class CPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            Expression<Func<Prestamo, bool>> filtro = x => true;
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();

            int id;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todor
                    repositorio.GetList(x => true);
                    break;
                    
                case 1://PrestamoId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.PrestamoId == id;
                    //&&(c.Fecha >= Convert.ToDateTime(DesdeTextBox.Text) && c.Fecha <= Convert.ToDateTime(HastaTextBox.Text));
                    break;
                case 2://CuentaId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.CuentaId == id;
                    //&& (c.Fecha >= Convert.ToDateTime(DesdeTextBox.Text) && c.Fecha <= Convert.ToDateTime(HastaTextBox.Text));
                    break;
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {

        }
    }
}