using EISG20240904.Auth;

namespace EISG20240904.Endpoints
{
    public static class AccountEndpoint
    {
        public static void AddAccountEndPoints(this WebApplication app)
        {
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authService) =>
            {
                if (login == "admin" && password == "12345")
                {
                    var token = authService.Authenticate(login);
                    return Results.Ok(token);
                }
                else
                {
                    return Results.Unauthorized();
                }
            });
        }
    }
}
