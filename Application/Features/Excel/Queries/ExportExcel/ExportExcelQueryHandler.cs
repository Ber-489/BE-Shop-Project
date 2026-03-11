namespace Application.Features.Excel.Queries.ExportExcel;

public class ExportExcelQueryHandler 
    : IRequestHandler<ExportExcelQuery, byte[]>
{
    private readonly IExcelService _excelService;
    private readonly IExcelRepository _excelRepository;

    public ExportExcelQueryHandler(
        IExcelService excelService,
        IExcelRepository excelRepository)
    {
        _excelService = excelService;
        _excelRepository = excelRepository;
    }

    public async Task<byte[]> Handle(
        ExportExcelQuery request,
        CancellationToken cancellationToken)
    {
        var rows = await _excelRepository.GetAllAsync();

        return _excelService.Export(rows);
    }
}