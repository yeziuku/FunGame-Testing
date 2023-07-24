using System.Collections;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Milimoe.FunGame.Core.Api.Utility;
using Milimoe.FunGame.Core.Entity;
using Milimoe.FunGame.Core.Library.Common.JsonConverter;

DataSet ds = new();
DataTable table = new("SampleTable1");
table.Columns.Add("Id", typeof(int));
table.Columns.Add("Name", typeof(string));
table.Columns.Add("Age", typeof(int));
table.Rows.Add(1, "John", 30);
table.Rows.Add(2, "Jane", 25);
table.Rows.Add(3, "Bob", 40);
ds.Tables.Add(table);

table = new("SampleTable2");
table.Columns.Add("Id", typeof(int));
table.Columns.Add("Name", typeof(string));
table.Columns.Add("Age", typeof(int));
table.Rows.Add(1, "John", 30);
table.Rows.Add(2, "Jane", 25);
table.Rows.Add(3, "Bob", 40);
ds.Tables.Add(table);

JsonSerializerOptions options = new()
{
    WriteIndented = true,
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    Converters = { new DateTimeConverter(), new DataTableConverter(), new DataSetConverter(), new UserConverter(), new RoomConverter() }
};

Room r = Factory.GetRoom(1294367, "w5rtvh8".ToUpper(), DateTime.Now, Factory.GetUser(), Milimoe.FunGame.Core.Library.Constant.RoomType.Mix, Milimoe.FunGame.Core.Library.Constant.RoomState.Created);
User u = Factory.GetUser(1, "LUOLI", "123123", DateTime.Now, DateTime.Now, "LUOLI@66.COM", "QWQAQW");

Hashtable hashtable = new()
{
    { "table", table },
    { "room", r },
    { "user", u }
};

string json = JsonSerializer.Serialize(hashtable, options);

Hashtable hashtable2 = JsonSerializer.Deserialize<Hashtable>(json, options) ?? new();

User u2 = NetworkUtility.JsonDeserializeFromHashtable<User>(hashtable2, "user") ?? Factory.GetUser();
Room r2 = NetworkUtility.JsonDeserializeFromHashtable<Room>(hashtable2, "room") ?? Factory.GetRoom();

System.Console.WriteLine(u2.Username + " 进入了 " + r2.Roomid + " 房间");