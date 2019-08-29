using System;
using System.Collections.Generic;
using System.Text;
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
            public int AskForNumericInputPets(List<Pet> menuItems)
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
                        i++;
                        Console.WriteLine(i + ": " + pet.Name + ": species " + pet.Species);
                        MenuItem item = new MenuItem(pet.Name);
                        menuItems.Add(item);
                        
                    }

                    break;



                case 2:
                    {
                        _petService.CreatePet();
                        AddExsit(menuItems);
                        break;
                    }



                case 3:
                    {

                        Console.Clear();

                        foreach (var pet in _petService.GetAllPets())
                        {
                            i++;
                            Console.WriteLine(i + ": " + pet.Name + "\n");
                            MenuItem item = new MenuItem(pet.Name);
                            menuItems.Add(item);

                        }

                        AddExsit(menuItems);
                        Console.WriteLine("type the number of the pet you wint to delete");
                        int id = AskForNumericInputPets(_petService.GetAllPets());
                        _petService.DeltedPet(id);

                        Console.Clear();
                        menuItems.Clear();
                        foreach (var animal in _petService.GetAllPets())
                        {
                            i++;
                            Console.WriteLine(i + ": " + animal.Name + "\n");
                            MenuItem item = new MenuItem(animal.Name);
                            menuItems.Add(item);
                        }
                        AddExsit(menuItems);
                        }

 break;

                case 4:
                    {
                        



                    }

                    break;

            }



        }
    }

    }

