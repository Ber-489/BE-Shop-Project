namespace Api.Endpoints.Excel;

public class ExportExcelEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/excel/export",
        async (IMediator mediator) =>
        {
            var file = await mediator.Send(new ExportExcelQuery());

            return Results.File(
                file,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "data.xlsx");
        })
        .Produces(StatusCodes.Status200OK)
        .WithTags("Excel");
    }
}