using Refit;
using School.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddRefitClient<IStudentService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7162"));

builder.Services.AddRefitClient<ITeacherService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7162"));

builder.Services.AddRefitClient<IGradeService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7162"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
