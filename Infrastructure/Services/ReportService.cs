using DevExpress.XtraReports.UI;

public class ReportService : IReportService
{
    public byte[] GenerateInvoicePdf(InvoiceReportDto model)
    {
        var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Reports",
            "InvoiceReport.repx"
        );

        var report = XtraReport.FromFile(path, true);

        // reset datasource cũ trong repx
        report.DataSource = null;
        report.DataMember = null;

        // set datasource mới
        report.DataSource = new List<InvoiceReportDto> { model };
        Console.WriteLine(model.InvoiceNumber);
        report.CreateDocument();

        using var ms = new MemoryStream();
        report.ExportToPdf(ms);

        return ms.ToArray();
    }
}