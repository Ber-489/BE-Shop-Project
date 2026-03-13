public class ExportInvoiceEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reports/invoice", async (
            IReportService reportService) =>
        {
            var model = new InvoiceReportDto
            {
                InvoiceNumber = "PT001",
                CustomerName = "Nguyễn Văn A",
                Address = "Hồ Chí Minh",
                Amount = 1000000,
                AmountText = "Một triệu đồng",
                Description = "Thanh toán đơn hàng",
                Date = DateTime.Now
            };

            var pdf = reportService.GenerateInvoicePdf(model);

            return Results.File(
                pdf,
                "application/pdf",
                "invoice.pdf");
        })
        .WithTags("Reports");
    }
}