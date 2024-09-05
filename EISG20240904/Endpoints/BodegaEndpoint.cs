namespace EISG20240904.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<Bodega> bodegas = new List<Bodega>();

        public static void AddBodegaEndpoints(this WebApplication app)
        {
            app.MapGet("/bodegas/{id}", (int id) =>
            {
                var bodega = bodegas.FirstOrDefault(c => c.Id == id);
                return bodega; 
            }).RequireAuthorization();

            app.MapPost("/bodegas", (Bodega bodega) =>
            {
                bodegas.Add(bodega); // Agrega el nuevo bodega a la lista
                return Results.Ok(); // Devuelve una respuesta HTTP 200 OK
            }).RequireAuthorization();

            // Configurar una ruta PUT para actualizar bodega existente por su ID
            app.MapPut("/bodegas/{id}", (int id, Bodega bodega) =>
            {
                // Busca un producto en la lista que tenga el ID especificado
                var existingbodega = bodegas.FirstOrDefault(p => p.Id == id);
                if (existingbodega != null)
                {
                    // Actualiza los datos
                    existingbodega.Nombre = bodega.Nombre;
                    existingbodega.Encargado = bodega.Encargado;
                    return Results.Ok(); // Devuelve una respuesta HTTP 200 OK
                }
                else
                {
                    return Results.NotFound(); 
                }
            }).RequireAuthorization();



        }
        internal class Bodega
        {
            public int Id { get; set; }

            public string Nombre { get; set; }

            public string Encargado { get; set; }
        }
    }
}
