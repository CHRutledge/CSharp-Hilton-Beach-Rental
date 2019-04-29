using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiltonRentalApp
{
    class BeachRentalsApp
    {
        static void Main(string[] args)
        {

            string[] itemsRented = new string[1];
            Random rnd = new Random();
            Guest customer = new Guest();
            Rental cRental = new Rental();


            Greeting();

            GuestName();

            Contract();

            MinsRented();

            RentalItems();


            ReadLine();



            void Greeting()
            {
                WriteLine("***********************************************************");
                WriteLine("{0,-10}{1,-10}{2,9}", "*", "Welcome to Waikiki Hilton Beach Rentals!", "*");
                WriteLine("{0,-13}{1,-13}{2,18}", "*", "Equipping your BeachSide Fun", "*");
                WriteLine("{0}{1,58}", "*", "*");
                WriteLine("***********************************************************");
            }

            void GuestName()
            {
                WriteLine("Enter the guest name >> ");
                customer.Name = ReadLine();
            }

            void Contract()
            {
                customer.Contract = customer.Name.Substring(0, 1) + Convert.ToString(rnd.Next(1000, 10000));
            }

            void MinsRented()
            {
                WriteLine("What is the rental time in minutes? ");
                customer.Minutes = Convert.ToInt32(ReadLine());

                if (customer.Minutes >= 60)
                {
                    customer.Minutes = customer.Minutes - 60;
                }

            }


            string[,] RentalItems()
            {
                string result = "y";
                string itemRes = null;
                while (result == "y")
                {
                    cRental.ItemsAvailable();

                    WriteLine("\nItem to rent >> ");
                    itemRes = ReadLine();

                    if (itemRes == Convert.ToString(1))
                    {
                        customer.Items[0, 0] = "Flotation Raft";
                        WriteLine("Qty " + customer.Items[0, 0] + ">> ");
                        customer.Items[0, 1] = ReadLine();
                    }
                    else if (itemRes == Convert.ToString(2))
                    {
                        customer.Items[1, 0] = "Snorkel Gear";
                        WriteLine("Qty " + customer.Items[1, 0] + ">> ");
                        customer.Items[1, 1] = ReadLine();
                    }
                    else if (itemRes == Convert.ToString(3))
                    {
                        customer.Items[2, 0] = "Chair";
                        WriteLine("Qty " + customer.Items[2, 0] + ">> ");
                        customer.Items[2, 1] = ReadLine();
                    }
                    else if (itemRes == Convert.ToString(4))
                    {
                        customer.Items[3, 0] = "Umbrella";
                        WriteLine("Qty " + customer.Items[3, 0] + ">> ");
                        customer.Items[3, 1] = ReadLine();
                    }
                    else if (itemRes == Convert.ToString(5))
                    {
                        customer.Items[4, 0] = "Paddle Boat";
                        WriteLine("Qty " + customer.Items[4, 0] + ">> ");
                        customer.Items[4, 1] = ReadLine();
                    }

                    WriteLine("Enter more rentals y | n >> ");
                    result = ReadLine();
                }

                WriteLine("***************************************************");
                WriteLine("Contract: {0,0} {1,18} {2}", customer.Contract, "Guest:", customer.Name);
                WriteLine("----------------------------------------------------");
                WriteLine("Rental Time: {0} hours and {1} minutes\n", Convert.ToString(customer.Hours()), customer.Minutes);
                WriteLine("\nRental Items");


                for (int i = 0; i < customer.Items.GetLength(0); i++)
                {
                    if (customer.Items[i,0] != null)
                    {
                        WriteLine(String.Format("{0,-10} {1,-10} {2,0}", customer.Items[i, 1], customer.Items[i, 0], cRental.rentalItems[i, 1]));
                    }
                }
                WriteLine("----------------------------------------------------");
                cRental.totalCalculations(customer.Items, customer.Minutes);
                return customer.Items;
            }
        }

        class Guest
        {
            private string name;
            private string contract;
            private int minutes;
            private string[,] items = new string[5, 2];


            public string Name
            {
                get { return name; }
                set { name = value; }

            }

            public string Contract
            {
                get { return contract; }
                set { contract = value; }
            }

            public int Minutes
            {
                get { return minutes; }
                set { minutes = value; }
            }

            public string[,] Items
            {
                get { return items; }
                set { items = value; }
            }

            public int Hours()
            {
                int hour = 0;
                if (minutes >= 60)
                {
                    hour = 1;
                }
                return hour;
            }
        }

        class Rental
        {
            public string[,] rentalItems = new string[,]
            {
            { "Flotation Raft", "15" }, {"Snorkel Gear", "25" },
            { "Chair", "8" }, { "Umbrella", "10" }, {"Paddle Boat", "40" }
            };
            public string[,] itemsRented = new string [5,2];
            public double totalPrice;

            public string[,] ItemsAvailable()
            {
                WriteLine("Items Available for Rental\n----------------------------");
                for (int i = 0; i < rentalItems.Length - 5; i++)
                {
                    WriteLine(i + 1 + ") " + rentalItems[i, 0] + " $" + rentalItems[i, 1] + "\n");
                }
                return rentalItems;
            }

            public void totalCalculations(string [,] itemsRented, double mins)
            {

                for (int i = 0; i < itemsRented.GetLength(0); i++)
                {
                    totalPrice += (Convert.ToDouble(itemsRented[i, 1]) * Math.Ceiling(Convert.ToDouble(mins)/30) * (Convert.ToDouble(rentalItems[i, 1]) / 2));

                }
                WriteLine("{0,36} ${1,1}", "Total Bill", totalPrice);
            }
        }
    }
}

