using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using OfficeOpenXml;

namespace TpIngSoftII.Models.Reportes
{
    public class ExcelExport
    {

        private class ExcelColumn
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Format { get; set; }
            public string PropertyName { get; set; }
        }

        public ExcelExport()
        {

        }






        public byte[] Export(List<object[]> dt)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Libro1");

                ws.Cells["A1"].LoadFromArrays(dt);

                using (ExcelRange col = ws.Cells[2, 5, dt.Count, dt[0].Length])
                {
                    col.Style.Numberformat.Format = "0";
                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                }

                using (ExcelRange col = ws.Cells[1, 1, dt.Count, dt[0].Length])
                {
                    col.AutoFitColumns();
                }


                this.bytes = pck.GetAsByteArray();
            }

            return this.bytes;
        }

        readonly string _filename = string.Empty;
        byte[] bytes;


        public byte[] Export<T>(List<T> entityList, object columns)
        {
            return Export(entityList, columns, "Libro1");
        }

        public byte[] Export<T>(List<T> entityList, object columns, string nombreHoja)
        {
            //System.Data.DataTable datas = _createTwoDimensionalObject<T>(entityList, columns);
            int listCount = 0;
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(nombreHoja);

                if (columns != null)
                {
                    List<object[]> datas = _createTwoDimensionalObject<T>(entityList, columns);
                    listCount = datas.Count;
                    ws.Cells["A1"].LoadFromArrays(datas);
                }
                else
                {
                    listCount = entityList.Count;
                    ws.Cells["A1"].LoadFromCollection<T>(entityList, true);
                }

                if (entityList.Count > 0)
                {

                    if (this._columns != null)
                    {
                        for (int i = 0; i < this._columns.Count; i++)
                        {
                            using (ExcelRange col = ws.Cells[2, i + 1, 2 + listCount, i + 1])
                            {

                                col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                                if (this._columns[i] != null)
                                {
                                    if (string.IsNullOrEmpty(this._columns[i].Type))
                                    {
                                        System.Reflection.PropertyInfo prop = entityList[0].GetType().GetProperty(this._columns[i].PropertyName);

                                        if (prop != null)
                                        {


                                            var propertyType = prop.PropertyType;

                                            if (propertyType.FullName.ToLower() == "system.datetime")
                                            {

                                                col.Style.Numberformat.Format = "DD/MM/YYYY";
                                                col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                                            }
                                            else if (propertyType.FullName.ToLower() == "system.string")
                                            {

                                            }
                                            else
                                            {
                                                object pval = prop.GetValue(entityList[0], null);

                                                if (pval != null && !string.IsNullOrEmpty(pval.ToString()))
                                                {
                                                    bool result = int.TryParse(pval.ToString(), out int res);

                                                    if (result)
                                                    {

                                                        col.Style.Numberformat.Format = "0";
                                                        col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                                                    }
                                                    else
                                                    {
                                                        result = double.TryParse(pval.ToString(), out double res2);
                                                        if (result)
                                                        {

                                                            col.Style.Numberformat.Format = "0.00";
                                                            col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                                                        }
                                                    }
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        switch (this._columns[i].Type)
                                        {
                                            case "number": col.Style.Numberformat.Format = this._columns[i].Format ?? "0"; col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right; break;
                                            case "decimal": col.Style.Numberformat.Format = this._columns[i].Format ?? "0.00"; col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right; break;
                                            case "date": col.Style.Numberformat.Format = this._columns[i].Format ?? "DD/MM/YYYY"; break;
                                            case "text": col.Style.Numberformat.Format = this._columns[i].Format ?? "@"; break;
                                            case "time": col.Style.Numberformat.Format = this._columns[i].Format ?? "HH:mm"; break;
                                        }
                                    }

                                }

                                col.AutoFitColumns();

                            }
                        }
                    }
                    else
                    {

                        System.Reflection.PropertyInfo[] properties = entityList[0].GetType().GetProperties();
                        for (int i = 0; i < properties.Length; i++)
                        {

                            var propertyType = properties[i].PropertyType;

                            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                propertyType = propertyType.GetGenericArguments()[0];
                            }



                            if (propertyType.FullName.ToLower() == "system.datetime")
                            {
                                using (ExcelRange col = ws.Cells[2, i + 1, 2 + listCount, i + 1])
                                {
                                    col.Style.Numberformat.Format = "DD/MM/YYYY";
                                    col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    col.AutoFitColumns();
                                }
                            }
                            else if (propertyType.FullName.ToLower() == "system.string")
                            {

                            }
                            else
                            {
                                object pval = properties[i].GetValue(entityList[0], null);

                                if (pval != null && !string.IsNullOrEmpty(pval.ToString()))
                                {
                                    bool result = int.TryParse(pval.ToString(), out int res);

                                    if (result)
                                    {
                                        using (ExcelRange col = ws.Cells[2, i + 1, 2 + listCount, i + 1])
                                        {
                                            col.Style.Numberformat.Format = "0";
                                            col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                            col.AutoFitColumns();
                                        }
                                    }
                                    else
                                    {
                                        result = double.TryParse(pval.ToString(), out double res2);
                                        if (result)
                                        {
                                            using (ExcelRange col = ws.Cells[2, i + 1, 2 + listCount, i + 1])
                                            {
                                                col.Style.Numberformat.Format = "0.00";
                                                col.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                                col.AutoFitColumns();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }

                this.bytes = pck.GetAsByteArray();

            }

            return this.bytes;
        }

        object _columnsFormat;

        public byte[] Export<T>(List<T> entityList)
        {
            return Export(entityList, null);
        }

        public byte[] Export(System.Data.DataTable entityList)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Libro1");

                ws.Cells["A1"].LoadFromDataTable(entityList, true);
                ws.Cells.AutoFitColumns();

                this.bytes = pck.GetAsByteArray();

            }

            return this.bytes;
        }
        /// <summary>
        /// Busca el nombre pasado por parametro en la colección privada _columnsFormat.
        /// Si no la encuentra retorna una instancia de ExcelColumn con Name=null.
        /// Si la encuentra retorna una instancia de ExcelColumn con Name y PropertyName como minimo, y si hay type y format estos tb se incluyen.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ExcelColumn _getProperty(string name)
        {

            ExcelColumn ret = new ExcelColumn
            {
                Name = null
            };

            object columns = this._columnsFormat;
            if (columns != null)
            {
                var item = columns.GetType().GetProperties().Where(w => w.Name == name).FirstOrDefault();

                if (item != null)
                {
                    object value = item.GetValue(columns, null);

                    ret.PropertyName = item.Name;

                    if (value.GetType().FullName.ToLower() == "system.string")
                    {
                        ret.Name = value.ToString();
                    }
                    else
                    {
                        PropertyInfo nameProperty = value.GetType().GetProperty("name");
                        PropertyInfo excelTypeProperty = value.GetType().GetProperty("excelType");
                        PropertyInfo excelFormat = value.GetType().GetProperty("format");

                        if (nameProperty != null)
                            ret.Name = (nameProperty.GetValue(value, null) != null) ? nameProperty.GetValue(value, null).ToString() : string.Empty;

                        if (excelTypeProperty != null)
                            ret.Type = (excelTypeProperty.GetValue(value, null) != null) ? excelTypeProperty.GetValue(value, null).ToString() : string.Empty;

                        if (excelFormat != null)
                            ret.Format = (excelFormat.GetValue(value, null) != null) ? excelFormat.GetValue(value, null).ToString() : string.Empty;
                    }
                }
            }
            return ret;
        }

        List<ExcelColumn> _columns;

        private System.Data.DataTable _createDataTable<T>(List<T> lst, object columns)
        {

            _columnsFormat = columns;
            _columns = new List<ExcelColumn>();
            ExcelColumn _property;


            int _rowCount = (lst.Count > 0) ? lst.Count + 1 : 1;
            int _columnsCount = (lst.Count > 0) ? ((this._columnsFormat != null) ? this._columnsFormat.GetType().GetProperties().Length : lst[0].GetType().GetProperties().Length) : 1;


            System.Data.DataTable dt = new System.Data.DataTable();
            //object[,] datas = new object[_rowCount, _columnsCount];

            if (lst.Count > 0)
            {

                int col = 0;

                if (this._columnsFormat != null)
                {
                    System.Reflection.PropertyInfo[] _properties = this._columnsFormat.GetType().GetProperties();

                    foreach (System.Reflection.PropertyInfo propInfo in _properties)
                    {
                        _property = _getProperty(propInfo.Name);
                        if (_property.Name != null)
                        {
                            _columns.Add(_property);
                            dt.Columns.Add(_property.Name);
                            //datas[0, col] = _property.Name;
                            col++;
                        }
                    }

                    for (int row = 0; row < lst.Count; row++)
                    {
                        int column = 0;
                        System.Data.DataRow dtrow = dt.NewRow();

                        foreach (ExcelColumn propInfo in _columns)
                        {
                            System.Reflection.PropertyInfo _pInfo = lst[row].GetType().GetProperty(propInfo.PropertyName);
                            if (_pInfo != null)
                            {
                                if (propInfo.Type == "text")
                                {
                                    object value = _pInfo.GetValue(lst[row], null);
                                    dtrow[column] = (value != null) ? value.ToString() : "";
                                }
                                else
                                {
                                    var val = _pInfo.GetValue(lst[row], null);
                                    bool res;

                                    if (val != null)
                                    {
                                        res = int.TryParse(val.ToString(), out int resInt);
                                        if (res)
                                        {
                                            dtrow[column] = resInt;
                                        }
                                        else
                                        {
                                            res = double.TryParse(val.ToString(), out double resDouble);
                                            if (res)
                                            {
                                                dtrow[column] = resDouble;
                                            }
                                            else
                                            {
                                                dtrow[column] = val;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        dtrow[column] = val;
                                    }


                                }

                            }
                            column++;
                        }

                        dt.Rows.Add(dtrow);
                    }
                }
                else
                {

                    foreach (var propInfo in lst[0].GetType().GetProperties())
                    {
                        dt.Columns.Add(propInfo.Name);
                        //datas[0, col] = propInfo.Name;
                        col++;
                    }

                    for (int row = 0; row < lst.Count; row++)
                    {
                        int column = 0;
                        System.Data.DataRow dtrow = dt.NewRow();

                        foreach (var propInfo in lst[row].GetType().GetProperties())
                        {
                            dtrow[column] = propInfo.GetValue(lst[row], null);
                            column++;
                        }

                        dt.Rows.Add(dtrow);
                    }

                }
            }
            return dt;
        }


        /// <summary>
        /// Crea un lista donde cada item es un array[0...n] y cada item del array es una columna.
        /// El primer item del array tiene los nombres de las columnas y los siguientes item son los valores de cada columna.
        /// El metodo siempre recibe el parametro columns, se podria quitar donde se pregunta si es null ya que nunca se llama a este metodo cuando es null.
        /// Ademas de calcular la lista de salida carga dos variables privadas _columnsFormat y _columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private List<object[]> _createTwoDimensionalObject<T>(List<T> lst, object columns)
        {

            _columnsFormat = columns;
            _columns = new List<ExcelColumn>();
            ExcelColumn _property;


            int _rowCount = (lst.Count > 0) ? lst.Count + 1 : 1;
            int _columnsCount = (lst.Count > 0) ? ((this._columnsFormat != null) ? this._columnsFormat.GetType().GetProperties().Length : lst[0].GetType().GetProperties().Length) : 1;


            List<object[]> list = new List<object[]>();

            List<object> objs;



            if (this._columnsFormat != null)
            {

                System.Reflection.PropertyInfo[] _properties = this._columnsFormat.GetType().GetProperties();

                objs = new List<object>();
                /*Itera por cada propiedad que luego sera cada columna del excel*/
                foreach (System.Reflection.PropertyInfo propInfo in _properties)
                {
                    _property = _getProperty(propInfo.Name);
                    if (_property.Name != null)
                    {
                        _columns.Add(_property);
                        objs.Add(_property.Name);
                    }
                }
                /*crea el primer item del excel con los titulos en la lista de salida 'list'*/
                list.Add(objs.ToArray());

                /*Itera por la item de la lista a exportar*/
                for (int row = 0; row < lst.Count; row++)
                {

                    int column = 0;
                    objs = new List<object>();
                    /*itera por cada propiedad armando el array que luego agrega a la lista de salida 'list'*/
                    foreach (ExcelColumn propInfo in _columns)
                    {

                        System.Reflection.PropertyInfo _pInfo = lst[row].GetType().GetProperty(propInfo.PropertyName);

                        if (_pInfo != null)
                        {
                            string propName = propInfo.Name;

                            objs.Add(_pInfo.GetValue(lst[row], null));
                        }
                        column++;
                    }

                    list.Add(objs.ToArray());

                }

            }
            return list;
        }



        //    public static System.Data.DataSet GetDataSet(string path)
        //    {
        //        string filePath = path;//Console.ReadLine();

        //        System.IO.FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);

        //        return GetDataSet(stream);
        //    }

        //    public static System.Data.DataSet GetDataSet(System.IO.Stream stream, string extension = ".xlsx")
        //    {

        //        IExcelDataReader excelReader;

        //        if (extension == ".xls")
        //        {
        //            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //        }
        //        else
        //        {
        //            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //        }

        //        System.Data.DataSet dataSet = excelReader.AsDataSet();

        //        excelReader.Close();
        //        excelReader.Dispose();

        //        return dataSet;
        //    }


        //    public static IExcelDataReader GetReader(string path)
        //    {
        //        System.IO.FileInfo fInfo = new FileInfo(path);
        //        System.IO.FileStream stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read);

        //        return GetReader(stream, fInfo.Extension);
        //    }

        //    public static IExcelDataReader GetReader(System.IO.Stream stream, string extension = ".xlsx")
        //    {

        //        IExcelDataReader excelReader;

        //        if (extension == ".xls")
        //        {
        //            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        //        }
        //        else
        //        {
        //            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        //        }



        //        return excelReader;
        //    }


        //}

        //public static class ExcelExportHelper
        //{
        //    public static DataTable ToDataTable<T>(this IList<T> data)
        //    {
        //        System.ComponentModel.PropertyDescriptorCollection properties =
        //             System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
        //        DataTable table = new DataTable();
        //        foreach (System.ComponentModel.PropertyDescriptor prop in properties)
        //            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        //        foreach (T item in data)
        //        {
        //            DataRow row = table.NewRow();
        //            foreach (System.ComponentModel.PropertyDescriptor prop in properties)
        //                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        //            table.Rows.Add(row);
        //        }
        //        return table;
        //    }
        //}
    }
}
