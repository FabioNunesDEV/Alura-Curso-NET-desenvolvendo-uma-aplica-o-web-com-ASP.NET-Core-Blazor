var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext
builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
    .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
    .UseLazyLoadingProxies(false); // Desabilita a cria��o de proxies din�micos
});

// Adicione a pol�tica de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
//{
//    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});

var app = builder.Build();

// Use a pol�tica de CORS
app.UseCors("AllowAll");

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
