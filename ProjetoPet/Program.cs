using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoPet.Account;
using ProjetoPet.Data;
using ProjetoPet.Repositories;
using ProjetoPet.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Adicionar serviços ao contêiner

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configuração do DbContext com SQL Server

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 3. Configuração de Autenticação JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

// 4. Adicionar AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 5. Injeção de dependência de repositórios e serviços

builder.Services.AddScoped<IDonoRepository, DonoRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IDonoService, DonoService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthenticate, AuthenticateService>();

var app = builder.Build();

// 6. Configuração do pipeline de requisição HTTP

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();  // Correção: incluir a autenticação no pipeline
app.UseAuthorization();

app.MapControllers();

app.Run();
