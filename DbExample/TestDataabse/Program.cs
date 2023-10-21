// See https://aka.ms/new-console-template for more information

using MyORM;
using TestDataabse;

var myContext = new MyDataContext();
myContext.Add(new Clients()
{
    age = 19,
    gender = 1,
    fullname = "Чусова Елизавета Юрьевна",
    isanonymous = false,
    isblocked = false,
    phonenumber = "89871854613",
    status = 1
});