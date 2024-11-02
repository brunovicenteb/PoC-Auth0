using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner
builder.Services.AddControllers();

// Configuração da autenticação JWT usando Auth0
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = $"https://dev-8uhb8pxg7x8zh2oe.us.auth0.com/"; // Substitua pelo seu domínio Auth0
    options.Audience = "poc-auth0"; // Substitua pelo seu Audience configurado no Auth0
});

var app = builder.Build();

// Configurando o pipeline da aplicação
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Mapear os controladores

app.Run();