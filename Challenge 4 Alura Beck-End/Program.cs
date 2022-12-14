using Challenge_4_Alura_Beck_End.Data;
using Challenge_4_Alura_Beck_End.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("Challenge4Connection"), new MySqlServerVersion(new Version(8,0))));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ReceitaService, ReceitaService>();
builder.Services.AddScoped<DespesaService, DespesaService>();
builder.Services.AddScoped<CategoriaService, CategoriaService>();
builder.Services.AddScoped<ResumoService, ResumoService>();

builder.Services.AddAuthentication(auth => {
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(token => {
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aseo2sef@53hd!3673fgdj!3@%$¨T#WEGhergaihzsef#@%$@3rGasrgaise!gisehf%ufy@")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
