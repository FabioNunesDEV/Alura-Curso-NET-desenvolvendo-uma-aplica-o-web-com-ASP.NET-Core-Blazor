var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ScreenSoundContext>((options) =>
{
    options
    .UseSqlServer(builder.Configuration["ConnectionStrings:ScreenSoundDB"])
    .UseLazyLoadingProxies(false); // Desabilita a criação de proxies dinâmicos
});

builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
var app = builder.Build();

app.AddEndPointsArtistas();
app.AddEndPointsMusicas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
