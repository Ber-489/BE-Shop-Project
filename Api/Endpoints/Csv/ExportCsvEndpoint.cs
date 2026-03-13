public class ExportCsvEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/csv/export",
        async (ICsvService csvService, IExcelRepository repo) =>
        {
            var rows = await repo.GetAllAsync();

            var file = csvService.Export(rows);

            return Results.File(file, "text/csv", "data.csv");
        })
        .WithTags("CSV");
    }
}