
using DatingApp.API.Database;
using DatingApp.API.Database.entities;
using DatingApp.API.Extensions;
using DatingApp.API.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// Add services to the container.

builder.Services.AddControllers();


//Configure the Services

builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<PublishersService>();
builder.Services.AddTransient<AuthorsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddDbContext<DataContext>(
//             dbContextOptions => dbContextOptions
//                 .UseMySql(connectionString, serverVersion)
//                 // The following three options help with debugging, but should
//                 // be changed or removed for production.
//                 .LogTo(Console.WriteLine, LogLevel.Information)
//                 .EnableSensitiveDataLogging()
//                 .EnableDetailedErrors()
//         );
//         builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// DbInitializer.Seed(app);
// Minimal Api

// app.MapGet("/minimalapi/song", async (DataContext context)=> await context.Songs.ToListAsync());
// app.MapPost("/minimalapi/song", async (DataContext context, Song song) =>
// {
//     context.Songs.Add(song);
//     await context.SaveChangesAsync();
//     return Results.Ok(await context.Songs.ToListAsync());

// });

// app.MapGet("/minimalapi/song/{id}", async(DataContext context, int id)=>

//     await context.Songs.FindAsync(id) is Song song ?
//     Results.Ok(song) :
//     Results.NotFound("This song doesn't exist.")
// );


// app.MapPut("/minimalapi/song/{id}", async (DataContext context, int id, Song song)=>
// {
//             var song_old = await context.Songs.FirstOrDefaultAsync(u => u.Id == id);
//             if (song_old == null) {
//                 return Results.NotFound("Ahihi.Not found");
//             }
//                 song_old.Name = song.Name;
//                 song_old.Singer = song.Singer;
//                 song_old.Author = song.Author;
//                 song_old.favorite = song.favorite;
//                 song_old.Price = song.Price;
//                 song_old.Playlists = song.Playlists;
//                 song_old.RemarkablePoint  =  song.RemarkablePoint;
//                 song_old.RemarkablePointId = song.RemarkablePointId;

//                 await context.SaveChangesAsync();
//                 return Results.Ok(await context.Songs.ToListAsync());
// });

// app.MapDelete("/minimalapi/song/{id}", async(DataContext context, int id)=>
// {
//             var song_old = await context.Songs.FirstOrDefaultAsync(u => u.Id == id);
//             if (song_old == null) {
//                 return Results.NotFound("Ahihi.Not found item to delete");
//             }
//                context.Songs.Remove(song_old);

//                 await context.SaveChangesAsync();
//                 return Results.Ok(await context.Songs.ToListAsync());
// });



app.Run();
