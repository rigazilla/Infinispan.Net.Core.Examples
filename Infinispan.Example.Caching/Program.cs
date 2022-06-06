using Infinispan.Hotrod.Core;
using Infinispan.Hotrod.Caching.Distributed;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfinispanCache(options =>
{
    InfinispanDG cluster = new InfinispanDG();
    cluster.AddHost("127.0.0.1");
    options.Cluster = cluster;
    options.CacheName = "default";
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
