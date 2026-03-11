namespace Application.Features.Excel.Commands.ImportExcel;

public class ImportExcelCommandHandler 
    : IRequestHandler<ImportExcelCommand, bool>
{
    private readonly IExcelService _excelService;
    private readonly IExcelRepository _excelRepository;

    public ImportExcelCommandHandler(
        IExcelService excelService,
        IExcelRepository excelRepository)
    {
        _excelService = excelService;
        _excelRepository = excelRepository;
    }

    public async Task<bool> Handle(
        ImportExcelCommand request,
        CancellationToken cancellationToken)
    {
        var rows = await _excelService.ImportAsync(request.Stream);

        await _excelRepository.AddRangeAsync(rows);

        return true;
    }
}