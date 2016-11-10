using Microsoft.AspNetCore.Hosting;

namespace AspNetCore.Hosting.Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Empty web app - with StartUp
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}









// 1.
//.UseStartup(Assembly.GetEntryAssembly().FullName)

// 2. Empty web app - with Configure
//var host = new WebHostBuilder()
//    .UseKestrel()
//    .Configure(app =>
//    {
//        app.Run(async (context) =>
//        {
//            await context.Response.WriteAsync("Hello Word Configure!");
//        });
//    })
//    .Build();

// 3. Extensions
//var host = new WebHostBuilder()
//    .UseUrls("http://localhost:2323")
//    .UseIISIntegration()
//    .UseEnvironment("development")
//    .UseKestrel()
//    .UseStartup<Startup>()
//    .Build();
