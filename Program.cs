// https://vmsdurano.com/asp-net-core-5-implement-web-api-pagination-with-hateoas-links/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace DotNetWebApiPaginationHateoas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
