using RecipeBook.Web.Components;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Web.Data;
using Microsoft.AspNetCore.Identity;
using RecipeBook.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Use SQL Server for production deployment (Render or Azure)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorPages();
builder.Services.AddScoped<FileUploadService>();
builder.Services.AddScoped<RecipeService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Initialize sample data (optional — comment out if using real DB)
using (var scope = app.Services.CreateScope())
{
    var recipeService = scope.ServiceProvider.GetRequiredService<RecipeService>();
    await recipeService.InitializeSampleDataAsync();
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorPages(); // Identity pages

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Logout endpoint
app.MapGet("/logout", async (SignInManager<ApplicationUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/");
});

app.Run();