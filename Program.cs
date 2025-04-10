using Microsoft.EntityFrameworkCore;
using PaternLab.Context;
using PaternLab.Csv;
using PaternLab.Service.GenericRepository;
using PaternLab.Service.ImporterService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<CsvReaderService>();
builder.Services.AddScoped<IImporterService, ImporterService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var importer = scope.ServiceProvider.GetRequiredService<IImporterService>();
    var csvPath = args.Length > 0 ? args[0] : "file.csv";
    // importer.FillCsv(csvPath);

    //await importer.ImportCsv(csvPath);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
