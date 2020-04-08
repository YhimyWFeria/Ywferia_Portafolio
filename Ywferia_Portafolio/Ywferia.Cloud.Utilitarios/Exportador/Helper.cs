using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
namespace Ywferia.Cloud.Utilitarios.Exportador
{
    public class Helper
    {

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            if (typeof(T) == typeof(object[]) || typeof(T) == typeof(List<string>))
            {

                int i = 0;
                foreach (object row in data)
                {

                    object[] trow = typeof(T) == typeof(List<string>) ? ((List<string>)row).ToArray() : (object[])row;


                    if (trow != null)
                    {
                        if (i == 0)
                        {
                            foreach (object col in trow)
                            {
                                string strcol = col == null ? string.Empty : col.ToString().Trim();
                                table.Columns.Add(strcol);
                            }
                        }
                        else
                        {
                            table.Rows.Add(trow);
                        }
                        i++;
                    }
                }

            }
            else
            {
                foreach (PropertyDescriptor prop in properties)
                {
                    Type t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    if (t == DateTime.Now.GetType() || EsDecimal(t))
                    {
                        t = String.Empty.GetType();
                    }


                    table.Columns.Add(prop.Name, t);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        Type t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        object value = prop.GetValue(item) ?? DBNull.Value;

                        if (t == DateTime.Now.GetType() && value != DBNull.Value && value != null)
                        {
                            DateTime temp = (DateTime)value;
                            value = temp.ToShortDateString();
                        }
                        else if (EsDecimal(t) && value != DBNull.Value && value != null)
                        {
                            string tmp = String.Format("{0:0.00}", value);
                            value = tmp;
                        }

                        row[prop.Name] = value;
                    }
                    table.Rows.Add(row);
                }
            }


            return table;

        }

        public static DataTable WithColumns(DataTable table, IEnumerable<string> columns, IEnumerable<string> displayNames)
        {

            DataTable dt = new DataTable();
            foreach (string column in columns)
            {
                dt.Columns.Add(column);
            }


            foreach (DataRow r in table.Rows)
            {

                object[] row = new object[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row[i] = r[dt.Columns[i].ColumnName];
                }
                dt.Rows.Add(row);

            }

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = displayNames.ElementAt(i);
            }

            return dt;

        }

        private static bool EsDecimal(Type t)
        {

            if (t == decimal.MaxValue.GetType() || t == double.Epsilon.GetType() || t == float.Epsilon.GetType())
            {
                return true;
            }

            return false;
        }


    }
}
