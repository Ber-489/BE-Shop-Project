namespace Application.Common.Interfaces;

public interface ICsvService
{
    Task<List<ExcelRow>> ImportAsync(Stream stream);

    byte[] Export(List<ExcelRow> rows);
}