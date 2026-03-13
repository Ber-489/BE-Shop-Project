public class ImportCsvEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/csv/import",
        async (IFormFile file, ICsvService csvService, IExcelRepository repo) =>
        {
            using var stream = file.OpenReadStream();

            var rows = await csvService.ImportAsync(stream);

            await repo.AddRangeAsync(rows);

            return Results.Ok(rows.Count);
        })
        .DisableAntiforgery()
        .WithTags("CSV");
    }
}