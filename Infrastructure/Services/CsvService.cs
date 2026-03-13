using CsvHelper;
using System.Globalization;
using DomainExcelRow = Domain.Entities.ExcelRow;

namespace Infrastructure.Services;

public class CsvService : ICsvService
{
    public async Task<List<DomainExcelRow>> ImportAsync(Stream stream)
    {
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<DomainExcelRow>().ToList();

        foreach (var r in records)
        {
            r.Id = Guid.NewGuid();
            r.Date = DateTime.SpecifyKind(r.Date, DateTimeKind.Utc);
        }
        return records;
    }

    public byte[] Export(List<DomainExcelRow> rows)
    {
        using var memory = new MemoryStream();
        using var writer = new StreamWriter(memory);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(rows);

        writer.Flush();

        return memory.ToArray();
    }
}