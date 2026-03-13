public interface IReportService
{
    byte[] GenerateInvoicePdf(InvoiceReportDto model);
}