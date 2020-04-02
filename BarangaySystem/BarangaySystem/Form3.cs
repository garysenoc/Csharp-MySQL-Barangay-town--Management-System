using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BarangaySystem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter1", textBox1.Text));
            reportParameters.Add(new ReportParameter("ReportParameter2", textBox2.Text));
            reportParameters.Add(new ReportParameter("ReportParameter3", textBox3.Text));
            reportParameters.Add(new ReportParameter("ReportParameter4", textBox4.Text));
            reportParameters.Add(new ReportParameter("ReportParameter5", textBox5.Text));
            reportParameters.Add(new ReportParameter("ReportParameter6", textBox6.Text));
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();


            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            this.reportViewer1.LocalReport.DataSources.Clear();

            //this.rptViewer.LocalReport.Refresh();
            this.reportViewer1.DocumentMapCollapsed = true;
            this.reportViewer1.RefreshReport();
        }
    }
}
