namespace TestDataabse;

public class Clients
{
    public int? id { get; set; }
    public int status { get; set; }
    public int gender { get; set; }
    public string fullname { get; set; } = string.Empty;
    public int age { get; set; }
    public string phonenumber { get; set; } = string.Empty;
    public bool isblocked { get; set; }
    public bool isanonymous { get; set; }
}