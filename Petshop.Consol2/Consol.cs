using ApplicationService2;
using Core.DomainService2;
using Microsoft.Extensions.DependencyInjection;
using Petshop.InfraStructure.Data2;

namespace Petshop.Consol2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddScoped<IPetService, PetServices>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.ShowMenuItems();
            printer.GetTheMenuItem(printer.AskForNumericInputMenu(printer.ShowMenuItems()));
        }
    }
}
