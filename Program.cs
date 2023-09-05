using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Implementation;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Implementation;
using ProjectManager.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectManagerContext>();
builder.Services.AddScoped<ICreateUserService, CreateUserService>();
builder.Services.AddScoped<ICreateProjectService, CreateProjectService>();
builder.Services.AddScoped<ICreateTaskService, CreateTaskService>();
builder.Services.AddScoped<IJoinProjectService, JoinProjectService>();
builder.Services.AddScoped<ILoginUserService, LoginUserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
builder.Services.AddScoped<ITeamMemberProjectRepository, TeamMemberProjectRepository>();
builder.Services.AddScoped<IProjectListingService, ProjectListingService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/user/login";
                    config.Cookie.Name = "ProjectManager";
                    config.LogoutPath = "/user/logout";
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
// http://localhost:5074/User/JoinProject?projectId=23f8b5c6-e6fb-40ef-8309-a740a2e8cc0f