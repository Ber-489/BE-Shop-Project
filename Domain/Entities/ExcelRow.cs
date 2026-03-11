namespace Domain.Entities;

public class ExcelRow
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime Date { get; set; }
}