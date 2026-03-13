public class InvoiceReportDto
{
    public string InvoiceNumber { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public decimal Amount { get; set; }
    public string AmountText { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}