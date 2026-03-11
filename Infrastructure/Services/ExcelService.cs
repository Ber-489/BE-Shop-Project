using DomainExcelRow = Domain.Entities.ExcelRow;

namespace Infrastructure.Services;

public class ExcelService : IExcelService
{
    public async Task<List<DomainExcelRow>> ImportAsync(Stream stream)
    {
        ExcelPackage.License.SetNonCommercialPersonal("Ber");

        var rows = new List<DomainExcelRow>();

        using var package = new ExcelPackage(stream);
        var sheet = package.Workbook.Worksheets.First();

        int rowCount = sheet.Dimension.Rows;

        for (int row = 2; row <= rowCount; row++)
        {
            var dateText = sheet.Cells[row, 2].Text;

            DateTime.TryParse(dateText, out var date);

            var utcDate = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            rows.Add(new DomainExcelRow
            {
                Name = sheet.Cells[row, 1].Text,
                Date = utcDate
            });
        }

        return rows;
    }

    public byte[] Export(List<DomainExcelRow> data)
    {
        ExcelPackage.License.SetNonCommercialPersonal("Ber");

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Data");

        sheet.Cells[1, 1].Value = "Name";
        sheet.Cells[1, 2].Value = "Date";

        int row = 2;

        foreach (var item in data)
        {
            sheet.Cells[row, 1].Value = item.Name;
            sheet.Cells[row, 2].Value = item.Date;
            row++;
        }

        return package.GetAsByteArray();
    }
}