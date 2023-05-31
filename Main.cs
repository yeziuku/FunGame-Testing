using System.Data;
using Milimoe.FunGame.Testing.Solutions;

DataTable dt = DataTableSolution.GetDataTable();

Console.WriteLine(dt.Rows[0]["Name"]);