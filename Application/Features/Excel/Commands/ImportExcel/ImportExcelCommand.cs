namespace Application.Features.Excel.Commands.ImportExcel;

public record ImportExcelCommand(Stream Stream) : IRequest<bool>;