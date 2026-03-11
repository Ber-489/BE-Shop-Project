namespace Application.Features.Excel.Queries.ExportExcel;

public record ExportExcelQuery()
    : IRequest<byte[]>;