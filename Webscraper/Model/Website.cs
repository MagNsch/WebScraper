namespace DataAccess.Model;

public class Website
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Url { get; set; }


    public override string? ToString() => $"Id: {Id}, City: {City}";
}
