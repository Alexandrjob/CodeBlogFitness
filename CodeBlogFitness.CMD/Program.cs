using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static CultureInfo culture = new CultureInfo("ru"); //.CreateSpecifiCulture("ru");
        
        static ResourceManager resurceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);

        static void Main(string[] args)
        {
            Console.WriteLine(resurceManager.GetString("Status", culture));
            Console.WriteLine(resurceManager.GetString("Hello", culture));

            Console.WriteLine(resurceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resurceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();

                double weight = ParseDouble(resurceManager.GetString("EnterWeight", culture));
                double height = ParseDouble(resurceManager.GetString("EnterHeight", culture));

                DateTime birthDate = ParseDateTime();

                userController.SetNewUserData(gender, birthDate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);
            var eatingController = new EatingController(userController.CurrentUser);

            Console.WriteLine(resurceManager.GetString("WhatToDo", culture));
            Console.WriteLine(resurceManager.GetString("EnterMeal", culture));
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("{0}: ", resurceManager.GetString("EnterProductName", culture));
            var food = Console.ReadLine();

            var calories = ParseDouble(resurceManager.GetString("Calorie", culture));
            var prots = ParseDouble(resurceManager.GetString("Protein", culture));
            var fats = ParseDouble(resurceManager.GetString("Fats", culture));
            var carbs = ParseDouble(resurceManager.GetString("Carbohydrates", culture));

            var weight = ParseDouble(resurceManager.GetString("EnterServingWeight", culture));
            var product = new Food(food, calories, prots, fats, carbs);


            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd,MM,yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                //Console.WriteLine($"Введите {name}: ");
                Console.WriteLine("{0} {1}: ", resurceManager.GetString("Enter", culture), name);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}а");
                }
            }
        }
    }
}
