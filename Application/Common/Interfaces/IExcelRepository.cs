namespace Application.Common.Interfaces;

public interface IExcelRepository
{
    Task AddRangeAsync(List<ExcelRow> rows);

    Task<List<ExcelRow>> GetAllAsync();
}