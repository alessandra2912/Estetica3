using Microsoft.EntityFrameworkCore;
using estetica.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddRazorPages();

// Configura o serviço de contexto de banco de dados com MySQL e especifica a versão do MySQL Server.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
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

// Testa a conexão com o banco de dados antes de executar o aplicativo.
TestDatabaseConnection(app);

app.Run();

void TestDatabaseConnection(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.CanConnect())
            {
                Console.WriteLine("Conexão com o banco de dados bem-sucedida!");
            }
            else
            {
                Console.WriteLine("Falha na conexão com o banco de dados.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
        }
    }
}
