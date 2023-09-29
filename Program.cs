// See https://aka.ms/new-console-template for more information
using ProtoBuf;
using ProtoBuf.Meta;
using Protobuf_RuntimeModel_Datetime;

///////////////////////////////////////////////////
// configure runtimetypemodel
var model = RuntimeTypeModel.Default;
model.AllowParseableTypes = true;

var item = model.Add(typeof(Test), false);

ValueMember member = item.AddField(1, "LastModified");


///////////////////////////////////////////////////
// save a file
//var saveInstance = new Test
//{
//    LastModified = new DateTime(2023, 2, 1),
//};
//using (var file = File.Create("test.bin"))
//{
//    Serializer.Serialize(file, saveInstance);
//}

/////////////////////////////////////////////////////
// works
Protobuf.ProtoTest readInstanceProto;
using (var file = File.OpenRead("test.bin"))
{
    readInstanceProto = Serializer.Deserialize<Protobuf.ProtoTest>(file);
}

Console.WriteLine(readInstanceProto.LastModified);
Console.WriteLine(new DateTime(readInstanceProto.LastModified));

/////////////////////////////////////////////////////
// not works
Test readInstance;
using (var file = File.OpenRead("test.bin"))
{
    readInstance = Serializer.Deserialize<Test>(file);
}

Console.WriteLine(readInstance.LastModified.Ticks);
Console.WriteLine(readInstance.LastModified);

Console.ReadKey();