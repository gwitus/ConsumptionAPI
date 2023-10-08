

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();
// Passando parametro HTTPS e passando arquivos estáticos;
app.UseHttpsRedirection();
app.UseStaticFiles(); //Tenho que validar se para programação dinâmica and Angular funciona

app.UseRouting();
app.MapRazorPages();

app.Run();