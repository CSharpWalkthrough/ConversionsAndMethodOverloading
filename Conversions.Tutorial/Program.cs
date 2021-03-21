using Conversions.Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversions.Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Implicit Conversions

            int lessPrecise = 10;
            double morePrecise = lessPrecise;

            Console.WriteLine($"Integer: {lessPrecise}"); // Integer: 10
            Console.WriteLine($"Double: {morePrecise}"); // Double: 10
            Console.WriteLine();


            Dog dog = new Dog();
            Animal animal = dog;

            Console.WriteLine($"Dog: {dog}"); // Dog: Conversions.Tutorial.Models.Dog
            Console.WriteLine($"Animal: {animal}"); // Animal: Conversions.Tutorial.Models.Dog
            Console.WriteLine();

            #endregion

            #region Explicit Conversions

            double morePreciseNum = 15.35;

            // The line below will throw an error
            //int lessPreciseNum = preciseNum;

            // By adding a cast, the program will compile
            int lessPreciseNum = (int)morePreciseNum;

            Console.WriteLine($"Double: {morePreciseNum}"); // Double: 15.35
            Console.WriteLine($"Integer: {lessPreciseNum}"); // Integer: 15
            Console.WriteLine();

            Dog d = new Dog();
            Animal animalParent = d;

            // The line above will throw an error
            // Dog dogChild = animalParent;


            // By adding a cast, the program will compile
            Dog dogChild = (Dog)animalParent;

            Console.WriteLine($"Dog d: {animalParent}"); // Animal: Conversions.Tutorial.Models.Dog
            Console.WriteLine($"Animal animalParent: {animalParent}"); // Animal animalParent: Conversions.Tutorial.Models.Dog
            Console.WriteLine($"Dog dogChild: {dogChild}"); // Dog dogChild: Conversions.Tutorial.Models.Dog
            Console.WriteLine();

            Cat cat = new Cat();
            Animal catAnimal = cat;

            try
            {
                Dog catDog = (Dog)catAnimal;
                Console.WriteLine(catDog);
            }
            catch (InvalidCastException ex)
            {
                // Unable to cast object of type 'Conversions.Tutorial.Models.Cat' 
                //to type 'Conversions.Tutorial.Models.Dog'
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            #endregion

            #region Conversions with helper classes

            string numberText = "123.45";
            double numberConvert = Convert.ToDouble(numberText);
            double numberParse = double.Parse(numberText);

            Console.WriteLine($"Using Convert: {numberConvert}"); // Using Convert: 123.45
            Console.WriteLine($"Using Parse: {numberParse}"); // Using Parse: 123.45

            #endregion

            Console.ReadKey();
        }
    }
}
