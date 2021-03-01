using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;

namespace TpIngSoftII.Reportes
{
    public class Service : ISevice
    {

        public Stream GetReportPDF(Object report, DataSet items)
        {
            var reporte = GetReportClass(report, items);

            Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            reporte.Close();

            return stream;
        }



        public Stream GetReportPDF<TItemSource>(Object report, List<TItemSource> items)
        {
            // ReportDocument rd = new ReportDocument();
            ReportClass reporte = (ReportClass)report;
            reporte.Load();
            //reporte.Database.Tables[""].SetDataSource()
            reporte.SetDataSource(items);

            Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            reporte.Close();
            return stream;
        }

        public ReportClass GetReportClass(object report, DataSet items)
        {
            // ReportDocument rd = new ReportDocument();
            ReportClass reporte = (ReportClass)report;
            reporte.Load();

            if (items.Tables.Count > 1)
            {
                reporte.SetDataSource(items);
            }
            else
            {
                DataTable dt = items.Tables[0];
                reporte.SetDataSource(dt);
            }

            return reporte;
        }

        public Stream GetReportPDF(ReportClass report)
        {
            Stream stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            report.Close();

            return stream;
        }

        public Stream GetReportPDF(object report, Dictionary<string, object> items)
        {
            // ReportDocument rd = new ReportDocument();
            ReportClass reporte = (ReportClass)report;
            reporte.Load();
            foreach (var item in items)
            {
                if (item.Key.Split('.')?.ToList()?.Count() > 1)
                {
                    string subReport = item.Key.Split('.')[0];
                    string dataSource = item.Key.Split('.')[1];
                    reporte.Subreports[subReport].Database.Tables[dataSource].SetDataSource(item.Value);
                }
                else
                {
                    reporte.Database.Tables[item.Key].SetDataSource(item.Value);
                }

            }
            //reporte.SetDataSource(items);

            Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            reporte.Close();
            return stream;
        }
    }
}
