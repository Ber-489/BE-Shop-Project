namespace Application.Common.Interfaces;

public interface IExcelService
{
    Task<List<ExcelRow>> ImportAsync(Stream stream);

    byte[] Export(List<ExcelRow> rows);
}