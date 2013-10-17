using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        _reportViewer.ProcessingMode = ProcessingMode.Remote;
        _reportViewer.ShowParameterPrompts = false;

        var serverReport = _reportViewer.ServerReport;
        serverReport.ReportServerUrl = new Uri("http://localhost/ReportServer_SQLEXPRESS");
        serverReport.ReportPath = "/Reports/TestReport";

        var reportParameter1 = new ReportParameter("Parameter1");
        reportParameter1.Values.Add("Hello World!");

        var reportParameter2 = new ReportParameter("Parameter2");
        reportParameter2.Values.Add("10/16/2013");

        var reportParameter3 = new ReportParameter("Parameter3");
        reportParameter3.Values.Add("10");

        serverReport.SetParameters(new[] { reportParameter1, reportParameter2, reportParameter3 });
    }
}