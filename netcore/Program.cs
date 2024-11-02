using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Adicionando servi�os ao cont�iner
builder.Services.AddControllers();

// Configura��o da autentica��o JWT usando Auth0
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = $"https://dev-8uhb8pxg7x8zh2oe.us.auth0.com/"; // Substitua pelo seu dom�nio Auth0
    options.Audience = "poc-auth0"; // Substitua pelo seu Audience configurado no Auth0
});

var app = builder.Build();

// Configurando o pipeline da aplica��o
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Mapear os controladores

app.Run();