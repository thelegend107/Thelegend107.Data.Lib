using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Thelegend107.MySQL.Data.Lib.Helpers
{
    public static class ObjectToSQLHelper<T> where T : new()
    {
        private static readonly object obj = new T();

        public static StringBuilder GenerateSelectQuery()
        {
            StringBuilder sb = new StringBuilder();

            List<string> properties = new List<string>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties().Where(p => !p.GetGetMethod().IsVirtual))
                properties.Add(prop.Name);

            sb.AppendLine("SELECT ");
            sb.AppendLine("\t" + string.Join("," + Environment.NewLine + "\t", properties));
            sb.AppendLine($"FROM {obj.GetType().GetCustomAttribute<TableAttribute>()?.Name}");

            return sb;
        }
    }
}
