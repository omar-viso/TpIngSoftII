using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;

namespace TpIngSoftII.Reportes
{
    public interface ISevice
    {
        Stream GetReportPDF(Object report, DataSet items);
        Stream GetReportPDF<TItemSource>(Object report, List<TItemSource> items);
        /// <summary>
        /// Arma un reporte a partir de una lista de lista, debe indicar el nombre de la tabla como key del diccionario.
        /// </summary>
        /// <typeparam name="TItemSource"></typeparam>
        /// <param name="report"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        Stream GetReportPDF(Object report, Dictionary<string, object> items);
        ReportClass GetReportClass(Object report, DataSet items);
        Stream GetReportPDF(ReportClass report);
    }
}
