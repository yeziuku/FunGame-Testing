using System.Collections;
using System.Data;
using ConverterExample;
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

System.Text.Json.JsonSerializerOptions options = new()
{
    WriteIndented = true,
    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
    Converters = { new DateTimeConverter(), new DataTableConverter(), new DataSetConverter(), new UserConverter(), new RoomConverter(), new PersonConverter(), new AddressConverter() }
};

Room r = Factory.GetRoom(1294367, "w5rtvh8".ToUpper(), DateTime.Now, Factory.GetUser(), Milimoe.FunGame.Core.Library.Constant.RoomType.Mix, Milimoe.FunGame.Core.Library.Constant.RoomState.Created);
User u = Factory.GetUser(1, "LUOLI", DateTime.Now, DateTime.Now, "LUOLI@66.COM", "QWQAQW");

Hashtable hashtable = new()
{
    { "table", table },
    { "room", r },
    { "user", u }
};

string json = NetworkUtility.JsonSerialize(hashtable, options);

Hashtable hashtable2 = NetworkUtility.JsonDeserialize<Hashtable>(json, options) ?? new();

User u2 = NetworkUtility.JsonDeserializeFromHashtable<User>(hashtable2, "user") ?? Factory.GetUser();
Room r2 = NetworkUtility.JsonDeserializeFromHashtable<Room>(hashtable2, "room") ?? Factory.GetRoom();

Console.WriteLine(u2.Username + " 进入了 " + r2.Roomid + " 房间");

Person p = new()
{
    Age = (int)r2.Id,
    Name = u2.Username,
    Address = new()
    {
        State = "呵呵州(Hehe State)",
        City = "哈哈市(Haha City)"
    }
};

json = NetworkUtility.JsonSerialize(p, options);

Person p2 = NetworkUtility.JsonDeserialize<Person>(json, options) ?? new();

Console.WriteLine("My name is " + p2.Name + ", I am " + p2.Age + "-year-old. I live at " + p2.Address.State + " " + p2.Address.City);