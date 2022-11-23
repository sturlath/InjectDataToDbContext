using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace EFGetStarted
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

#if DEBUG
            // Only load from the .env file when we are working locally
            LoadDevelopmentEnvironment();
#endif

            return builder;
        }

        public static void LoadDevelopmentEnvironment()
        {
            var dotEnvFilePath = Path.Combine(AppContext.BaseDirectory, ".env");
            foreach (var line in File.ReadAllLines(dotEnvFilePath))
            {
                var withoutComments = line.Split("#").FirstOrDefault();
                if (withoutComments == null)
                {
                    continue;
                }

                var keyValuePair = withoutComments.Split("=", 2, System.StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length == 2)
                {
                    Environment.SetEnvironmentVariable(keyValuePair[0], keyValuePair[1]);
                }
            }
        }
    }
}
