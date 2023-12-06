////////////////////////////////////////////////////////////////////////////////////
// FileName: Project2.cs
// FileType: Visual C# Source file
// Author : Truitt Thuecks
// Description : C# program that makes a simple online shopping center.
// Course: CSCI-1250-004
// Professor: Gillenwater
////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int response = 0;

            // Lists to store product names, cart items, product prices, and cart prices
            List<string> Products = new List<string>();
            List<string> Cart = new List<string>();
            List<double> Prices = new List<double>();
            List<double> CartPrices = new List<double>();

            Console.WriteLine("Welcome to the Online Shopping Application:");

            // Initialize products and their prices
            InitializeProducts(Products, Prices);

            do
            {
                // Display the main menu and handle user input
                DisplayMenu(Products, Cart, CartPrices, Prices);
            } while (response != 5);

            Console.ReadLine();
        }

        // Initialize products and their prices
        static void InitializeProducts(List<string> Products, List<double> Prices)
        {
            Products.Add("Laptop");
            Products.Add("Smart Watch");
            Products.Add("Gaming Monitor");
            Products.Add("Headphones");
            Prices.Add(2500.99);
            Prices.Add(250.75);
            Prices.Add(300.50);
            Prices.Add(450.90);
        }

        // Display the main menu and handle user input
        static void DisplayMenu(List<string> Products, List<string> Cart, List<double> CartPrices, List<double> Prices)
        {
            int menuResponse = 0;
            Console.WriteLine("Main Menu:\n1. Browse Products\n2. Add to Cart\n3. View Cart\n4. Complete Purchase\n5. Exit");
            Console.WriteLine("Select an option (1/2/3/4/5): ");
            menuResponse = int.Parse(Console.ReadLine());

            switch (menuResponse)
            {
                case 1:
                    // Display available products
                    DisplayProducts(Products, Cart, CartPrices, Prices);
                    break;
                case 2:
                    // Add selected product to the cart
                    AddToCart(Products, Cart, CartPrices, Prices);
                    break;
                case 3:
                    // View the shopping cart
                    ViewCart(Cart, CartPrices, Prices);
                    break;
                case 4:
                    // Complete the purchase and display total cost
                    Checkout(Products, Cart, Prices, CartPrices);
                    break;
                default:
                    Console.ReadLine();
                    break;
            }
        }

        // Get user choice and ensure it's between 1 and 5
        static int GetChoice()
        {
            int value = 0;

            if (value < 1 || value > 5)
            {
                Console.WriteLine("Please enter a number 1 - 5");
            }
            return value;
        }

        // Display available products
        static void DisplayProducts(List<string> Products, List<string> Cart, List<double> CartPrices, List<double> Prices)
        {
            Console.WriteLine("Available Products:");
            PrintList(Products, Prices);
        }

        // Add selected product to the cart
        static void AddToCart(List<string> Products, List<string> Cart, List<double> CartPrices, List<double> Prices)
        {
            int productResponse = 0;

            DisplayProducts(Products, Cart, CartPrices, Prices);

            Console.WriteLine("Enter the item number to add to your cart:");
            productResponse = int.Parse(Console.ReadLine());

            Console.WriteLine($"{Products[productResponse - 1]} has been added to your cart.");
            Cart.Add(Products[productResponse - 1]);
            CartPrices.Add(Prices[productResponse - 1]);
        }

        // View the shopping cart and display total cost
        static void ViewCart(List<string> Cart, List<double> CartPrices, List<double> Prices)
        {
            Console.WriteLine("Here is your shopping cart:");
            PrintList(Cart, CartPrices);

            Console.WriteLine("Total cost: ");
            Console.WriteLine(CartPrices.Sum());
        }

        // Complete the purchase and display total cost
        static void Checkout(List<string> Products, List<string> Cart, List<double> Prices, List<double> CartPrices)
        {
            Console.WriteLine($"Total cost of your purchase: ${Prices.Sum()}\nPurchase completed. Thank you!");
        }

        // Print the items in a list along with their prices
        static void PrintList(List<string> collection, List<double> Prices)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                Console.WriteLine($"{collection[i]} - {Prices[i]}");
            }
        }
    }
}

