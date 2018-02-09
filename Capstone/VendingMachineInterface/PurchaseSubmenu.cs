﻿using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.VendingMachineInterface;
using Capstone.Exceptions;

namespace Capstone.VendingMachineInterface
{
    public class PurchaseSubmenu
    {
        private VendingMachine vm;

        public PurchaseSubmenu(VendingMachine vendingMachine)
        {
            vm = vendingMachine;
        }
        public void Display()
        {
            while (true)
            {
                Console.WriteLine($"You have ${vm.Balance} remaining.");
                Console.WriteLine();
                Console.WriteLine("1] Feed Money");
                Console.WriteLine("2] Select Product");
                Console.WriteLine("3] Finish Transaction");


                Console.Write("What option do you want to select? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    try
                    {
                        Console.WriteLine("Enter money in denominations of $1, $5, $10, or $20");
                        int dollar = Convert.ToInt32(Console.ReadLine());
                        if (dollar == 1 || dollar == 5 || dollar == 10 || dollar == 20)
                        {
                            vm.FeedMoney(dollar);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }

                }

                else if (input == "2")
                {
                    try
                    {
                        Console.WriteLine("Select a product: ");
                        string productInput = Console.ReadLine().ToUpper();
                        vm.Purchase(productInput);                                                
                    }
                    catch (VendingMachineExceptions ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Thank you for using Team 0's Vending Machine.");
                    Console.WriteLine($"{vm.GetChange().GiveChange()}");

                    break;
                }


            }



        }
    }
}

