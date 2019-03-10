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
            decimal n;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0: //Todo
                    repositorio.GetList(c => true);
                    break;
                case 1://PrestamoId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.PrestamoId == id;
                    break;
                case 2://CuentaId
                    id = Utilidades.Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.CuentaId == id;
                    break;
            }

            DatosGridView.DataSource = repositorio.GetList(filtro);
            DatosGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}