using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model;

public class Website
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string City { get; set; }

    [Required]
    public string Url { get; set; }


    public override string? ToString() => $"Id: {Id}, City: {City}";
}
