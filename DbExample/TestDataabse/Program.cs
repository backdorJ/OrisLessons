// See https://aka.ms/new-console-template for more information

using MyORM;
using TestDataabse;

var myContext = new MyDataContext();
// var res = myContext.Select(new Clients());
var client = new Clients()
{
    id = 4, phonenumber = "999999999", isblocked = true, isanonymous = false,
    age = 19, fullname = "Hui", gender = 1, status = 0
};
var update = myContext.Update(client);


// res.ForEach(x => Console.WriteLine($"Id: {x.id}\tFullName: {x.fullname}\t" +
//                                          $"Age: {x.age}\tIsBlocked:{x.isblocked}\t" +
//                                          $"IsAnonymous: {x.isanonymous}\tPhone: {x.phonenumber}\t" +
//                                          $"Status: {x.status}\tGender: {x.gender}"));
