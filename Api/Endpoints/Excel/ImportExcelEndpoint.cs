namespace Api.Endpoints.Excel;

public class ImportExcelEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/excel/import",
        async (IFormFile file, IMediator mediator) =>
        {
            if (file == null || file.Length == 0)
                return Results.BadRequest("File is required");

            using var stream = file.OpenReadStream();

            var result = await mediator.Send(new ImportExcelCommand(stream));

            return Results.Ok(result);
        })
        .Accepts<IFormFile>("multipart/form-data")
        .DisableAntiforgery()   
        .WithTags("Excel");
    }
}