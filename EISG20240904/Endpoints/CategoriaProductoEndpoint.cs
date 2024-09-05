namespace EISG20240904.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<object> categorias = new List<object>();

        public static void AddCategoriaProductoEndpoint(this WebApplication app)
        {
            app.MapGet("/categoria", () =>
            {
                return categorias;
            }).AllowAnonymous();

            app.MapPost("/categoria", (string nombre, string descripcion) =>
            {
                categorias.Add(new { nombre, descripcion });
                return Results.Ok();
            }).RequireAuthorization();

        
        }
    }
}
