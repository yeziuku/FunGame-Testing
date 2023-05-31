using System.Data;
using System.Text.Json;
using Milimoe.FunGame.Core.Model;

namespace Milimoe.FunGame.Testing.Solutions
{
    public class DataTableSolution
    {
        public static DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            DataRow dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Name"] = "Mili";
            dt.Rows.Add(dr);

            JsonObject2 jsonobj = new();

            string json = JsonSerializer.Serialize(dt, jsonobj.Options);
            DataTable? dt2 = JsonSerializer.Deserialize<DataTable>(json, jsonobj.Options);

            return dt2 ?? new();
        }
    }
}
