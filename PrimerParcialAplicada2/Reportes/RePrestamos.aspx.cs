using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using PrimerPacialAplicada2.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicada2.Reportes
{
    public partial class RePrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RepositorioBase<DetallePrestamo> repositorio = new RepositorioBase<DetallePrestamo>();
                reporte.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                reporte.Reset();
                reporte.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\PrestamoReport.rdlc");
                reporte.LocalReport.DataSources.Clear();
                reporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("PrestamoDataSet", CPrestamo.lprestamo));
                //ReportDataSource("PrestamoDataSet", repositorio.GetList(x => true)));
                reporte.LocalReport.Refresh();
            }
        }
    }
}