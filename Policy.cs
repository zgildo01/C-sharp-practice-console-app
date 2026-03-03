namespace FinysPractice.Models;
public class Policy
{
    public required int Id { get; set; }
    public required decimal Premium { get; set; }
    public required bool Active { get; set; }
    public required Customer Customer { get; set; }
}