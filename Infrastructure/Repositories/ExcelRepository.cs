using DomainExcelRow = Domain.Entities.ExcelRow;

namespace Infrastructure.Repositories;

public class ExcelRepository : IExcelRepository
{
    private readonly AppDbContext _context;

    public ExcelRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(List<DomainExcelRow> rows)
    {
        await _context.ExcelRows.AddRangeAsync(rows);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DomainExcelRow>> GetAllAsync()
    {
        return await _context.ExcelRows.ToListAsync();
    }
}