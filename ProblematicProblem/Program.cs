using System;
using System.Collections.Generic;
using System.Threading;

internal class ProblematicProblem
{
    class problem
    {
        
        

        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont = true;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            bool doTheyWantActivity;
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            if(Console.ReadLine().ToLower() != "yes")
            {
                System.Environment.Exit(0);
            }
            

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            bool needAge = true;
            int userAge = 0;
            Console.Write("What is your age? ");
            while(needAge)
            {
                if(Int32.TryParse(Console.ReadLine(), out int age))
                {
                    needAge = false;
                    userAge = age;
                }
                else
                {
                    Console.WriteLine("You did not give an integer. Please enter an integer: ");
                }
            }
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList;

            if (Console.ReadLine().ToLower() == "sure")
            {
                seeList = true;
            }
            else
            {
                seeList = false;
            }
            
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList;
                if (Console.ReadLine().ToLower() == "yes")
                {
                    addToList = true;
                }
                else
                {
                    addToList= false;
                }
                Console.WriteLine();

                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();

                        Console.WriteLine("Would you like to add more? yes/no: ");
                        if (Console.ReadLine().ToLower() == "yes")
                        {
                            addToList = true;
                        }
                        else
                        {
                            addToList = false;
                        }
                    }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber].ToString();

                        if (userAge < 21 && randomActivity == "Wine Tasting")
                        {
                            Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                            Console.WriteLine("Pick something else!");
                            activities.Remove(randomActivity);
                            randomNumber = rng.Next(activities.Count);
                            randomActivity = activities[randomNumber];
                        }

                Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! Do you want to grab another or are you okay with this? another/okay");

                if(Console.ReadLine().ToLower() == "another")
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
        }
    }
}