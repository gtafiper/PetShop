using System;
using Core.ApplicationService;
using Core.DomainService;
using Microsoft.Extensions.DependencyInjection;
using Petshop.Consol;
using Petshop.Core.Entity;
using Petshop.InfraStructure.Data;

namespace ChrisesPetshop
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetServices>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IMenuitemsReposetory, MenuitemsReposetory>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.ShowMenuItems();
            printer.GetTheMenuItem(printer.AskForNumericInputMenu(printer.ShowMenuItems()));
        }
    }
}
