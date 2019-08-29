using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Core.ApplicationService;
using Core.DomainService;
using Petshop.Core.Entity;

namespace Petshop.Consol
{
    public class Printer : IPrinter
    {
        public IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }



        public List<MenuItem> ShowMenuItems()
        {
            Console.Clear();
            Console.WriteLine("\nType the number for the action you wish \n");
            int i = 0;
            foreach (var item in _petService.getAllMenuItems())
            {
                i++;
                Console.WriteLine(i + ":" + item.Name);
            }

            return _petService.getAllMenuItems();
        }


        public int AskForNumericInputMenu(List<MenuItem> menuItems)

        {
            int a;


            while (!Int32.TryParse(Console.ReadLine(), out a) || a < 1 || a > menuItems.Count + 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("you must write a number between 1 and " + (menuItems.Count + 1) +
                                  " and then pres enter");

                Console.ForegroundColor = ConsoleColor.White;
            }



            return a;

        }

        public int AskForNumericInputPets()
        {
            int a;


            while (!Int32.TryParse(Console.ReadLine(), out a))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("you must write a number");
                Console.ForegroundColor = ConsoleColor.White;
            }



            return a;

        }

        public double AskForDoubleInput()
        {
            double a;
            Console.WriteLine("price :");

            while (!double.TryParse(Console.ReadLine(), out a))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("you must write a number");
                Console.ForegroundColor = ConsoleColor.White;
            }



            return a;

        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        int AddExsit(List<MenuItem> list)
        {


            Console.WriteLine("\n" + (list.Count + 1) + ": " + " Return to main menu \n");

            if (AskForNumericInputMenu(list) == list.Count + 1)

            {
                ShowMenuItems();

                GetTheMenuItem(AskForNumericInputMenu(ShowMenuItems()));

            }

            return AskForNumericInputMenu(list);

        }

        public string HasHadPrOvner()
        {

            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Type the Name of previos ovner");
                string preOvner = Console.ReadLine();
                return preOvner;
            }
            else
            {
                return null;
            }
        }








        public void GetTheMenuItem(int inputNumber)
        {
            //inputNumber = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            List<MenuItem> menuItems = new List<MenuItem>();

            switch (inputNumber)
            {
                case 1:


                    Console.Clear();
                    Console.WriteLine("Show the list of pets \n");


                    foreach (var pet in _petService.GetAllPets())
                    {

                        Console.WriteLine("id " + ":" + pet.ID + ": Name " + pet.Name + ": species " + pet.Species);
                        MenuItem item = new MenuItem(pet.Name);
                        menuItems.Add(item);

                    }

                    AddExsit(menuItems);

                    break;



                case 2:
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("Type the Name of the new pet");
                    string name = Console.ReadLine();
                    Console.WriteLine("Type the price of " + name);
                    double price = AskForNumericInputPets();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Write the color of " + name);
                    string color = Console.ReadLine();
                    Console.WriteLine("Type the species");
                    string species = Console.ReadLine();
                    Console.WriteLine("Write the day of birth for " + name + "s");
                    int day = AskForNumericInputPets();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Write the day of month for " + name + "s");
                    int month = AskForNumericInputPets();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Write the day of year for " + name + "s");
                    int year = AskForNumericInputPets();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    DateTime date = new DateTime(year, month, day);
                    Console.WriteLine("Has " + name + "had a privios ovner? Type hasHadPrOvner ore no");
                    HasHadPrOvner();
                    Console.WriteLine(name + " was addet");


                        var pet = _petService.NewPet(name, date, color, price, HasHadPrOvner(), species);
                    _petService.CreatePet(pet);
                    AddExsit(menuItems);



                        break;
                }



                case 3:
                {

                    Console.Clear();

                    foreach (var pet in _petService.GetAllPets())
                    {

                        Console.WriteLine(pet.ID + ": " + pet.Name + "\n");
                        MenuItem item = new MenuItem(pet.Name);
                        menuItems.Add(item);

                    }

                    
                    Console.WriteLine("type the number of the pet you wont to delete");
                    int id = AskForNumericInputPets();
                    _petService.DeltedPet(id);

                    Console.Clear();
                    menuItems.Clear();
                    foreach (var animal in _petService.GetAllPets())
                    {
                        i++;
                        Console.WriteLine(animal.ID + ": " + animal.Name + "\n");
                        MenuItem item = new MenuItem(animal.Name);
                        menuItems.Add(item);
                    }

                    AddExsit(menuItems);
                }

                    break;

                case 4:
                {
                    foreach (var pet in _petService.GetAllPets())
                    {

                        Console.WriteLine(pet.ID + ": " + pet.Name + "\n");
                        MenuItem item = new MenuItem(pet.Name);
                        menuItems.Add(item);

                    }
                    Console.WriteLine("Insert pet Id: ");

                    var IdToUpdate = AskForNumericInputPets();
                    var petToUpdate = _petService.FindPetById(IdToUpdate);
                    Console.WriteLine("Updating " + petToUpdate.Name);
                    var newName = AskQuestion("Name : ");

                    var newprice = AskForDoubleInput();
                    Console.WriteLine("Write the day of birth for " + newName);
                    int day = AskForNumericInputPets();
                   
                    Console.WriteLine("Write the day of month for " + newName);
                    int month = AskForNumericInputPets();
                    
                    Console.WriteLine("Write the day of year for " + newName);
                    int year = AskForNumericInputPets();
                    
                    var newbirthdate = new DateTime(year, month, day);
                       
                    var newcolor = AskQuestion("Color : ");
                    var newpreOvner = HasHadPrOvner();
                    Console.WriteLine("Write the day " + newName +"was sold");
                    int sDay = AskForNumericInputPets();

                    Console.WriteLine("Write the month " + newName + "was sold");
                    int sMonth = AskForNumericInputPets();

                    Console.WriteLine("Write the year " + newName +"was sold");
                    int sYear = AskForNumericInputPets();
                    var newsoldDate = new DateTime(sYear, sMonth, sDay);
                    var newspecies = AskQuestion("Species : ");
                    _petService.UpdatePet(new Pet()
                    {

                        ID = IdToUpdate,
                        Name = newName,
                        Price = newprice,
                        Species = newspecies,
                        Color = newcolor,
                        PreviousOwner = newpreOvner,
                        Birthdate = newbirthdate,
                        SoldDate = newsoldDate,

                    });

                    break;

                }
                case 5:
                {
                    Console.Clear();
                    Console.WriteLine("Type the type of pet you ar looking for and pres Enter");
                    string species = Console.ReadLine();

                    foreach (var pet in _petService.GetPetsBySpecies(species).ToList())
                    {
                        Console.WriteLine("Name: " +pet.Name + " Price:"+ pet.Price +"Valuta'er"+ " species " + pet.Species);
                        MenuItem menu = new MenuItem(pet.Name);
                        menuItems.Add(menu);
                    }

                    AddExsit(menuItems);
                    

                    break;
                }
                case 6:
                {
                    Console.Clear();
                    Console.WriteLine("All pets by price\n");
                    foreach (var pet in _petService.GetPetsByPrice())
                    {
                        Console.WriteLine("Name: " + pet.Name + " Price:" + pet.Price + "Valuta'er");
                        MenuItem menu = new MenuItem(pet.Name);
                        menuItems.Add(menu);
                    }

                    AddExsit(menuItems);
                    

                    break;
                }

                case 7:
                {
                    Console.Clear();
                    Console.WriteLine("The five cheapest pets is\n");

                    foreach (var pet in _petService.GetFiveCheapest())
                    {
                        Console.WriteLine("Name: " + pet.Name + " Price:"+ pet.Price);
                        MenuItem menu = new MenuItem(pet.Name);
                        menuItems.Add(menu);
                    }

                    AddExsit(menuItems);
                    break;
                }

                case 8:
                {
                    Console.WriteLine("Closing");
                    System.Environment.Exit(0);

                    break;
                }



            }
        }

    }
}

