using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.Reportes
{
    public partial class RPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBase<DetallePrestamo> repositorio = new RepositorioBase<DetallePrestamo>();
            reporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            reporte.Reset();
            reporte.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\PrestamoReport.rdlc");
            reporte.LocalReport.DataSources.Clear();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("Prestamo", repositorio.GetList(x => true)));
            reporte.LocalReport.Refresh();
        }
    }
}