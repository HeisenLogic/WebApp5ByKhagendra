using Microsoft.EntityFrameworkCore;
using WebApp5ByKhagendra.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context
builder.Services.AddDbContext<StudentDBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<StudentDBContext>();
        context.Database.EnsureDeleted(); // Remove this line in production
        context.Database.EnsureCreated();
        
        // Seed initial data if needed
        if (!context.Students.Any())
        {
            context.Students.AddRange(
                new Student { FirstName = "John", LastName = "Doe", Email = "john@example.com", DateOfBirth = new DateTime(2000, 1, 1) },
                new Student { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", DateOfBirth = new DateTime(2001, 2, 15) }
            );
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating or seeding the database.");
    }
}

app.Run();
