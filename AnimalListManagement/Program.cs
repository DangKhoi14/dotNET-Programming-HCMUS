using System;


namespace AnimalListManagement
{
    using MainData;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of dogs: ");
            int dogCount = int.Parse(Console.ReadLine());

            Dog[] dogs = new Dog[dogCount];
            for (int i = 0; i < dogCount; i++)
            {
                dogs[i] = new Dog();
                Console.WriteLine($"Entering information for Dog {i + 1}:");
                dogs[i].InputInfo();
            }

            Console.Write("Enter the number of cats: ");
            int catCount = int.Parse(Console.ReadLine());

            Cat[] cats = new Cat[catCount];
            for (int i = 0; i < catCount; i++)
            {
                cats[i] = new Cat();
                Console.WriteLine($"Entering information for Cat {i + 1}:");
                cats[i].InputInfo();
            }

            Console.WriteLine("\nDisplaying information of all dogs:");
            foreach (var dog in dogs)
            {
                dog.DisplayInfo();
            }

            Console.WriteLine("\nDisplaying information of all cats:");
            foreach (var cat in cats)
            {
                cat.DisplayInfo();
            }

            Console.ReadLine();
        }
    }
}

namespace MainData
{
    public class Animal
    {
        public string Name { get; set; } = "";
        public int Age { get; set; } = 0;
        public float Height { get; set; } = 0;
        public float Weight { get; set; } = 0;

        public void InputAge()
        {
            bool isComplete = false;

            Console.Write($"Enter the age of the {this.GetType().Name}: ");
            try
            {
                Age = int.Parse(Console.ReadLine());
                if (Age < 0 || Age > 20)
                    throw new NegativeNumException();
                isComplete = true;
            }
            catch (FormatException)
            {
                Console.Write("Somethings went wrong! Please enter again: ");
            }
            catch (NegativeNumException)
            {
                Console.Write("Invalid number! Please enter again: ");
            }
            finally
            {
                if (!isComplete)
                    InputAge();
            }
        }

        public enum InputType
        {
            Height,
            Weight
        }

        public void InputNum(InputType inputType)
        {
            bool isComplete = false;

            string prompt = inputType == InputType.Height ? "height" : "weight";
            Console.Write($"Enter the {prompt} of the {this.GetType().Name}: ");

            while (!isComplete)
            {
                try
                {
                    if (inputType == InputType.Height)
                        Height = float.Parse(Console.ReadLine());
                    else if (inputType == InputType.Weight)
                        Weight = float.Parse(Console.ReadLine());
                    isComplete = true;
                }
                catch (FormatException)
                {
                    Console.Write("Something went wrong! Please enter again: ");
                }
                //catch (NegativeNumException)
                //{
                //    Console.Write("Invalid number! Please enter again: ");
                //}
            }
        }

        public virtual void InputInfo()
        {
            Console.Write($"Enter the name of the {this.GetType().Name}: ");
            Name = Console.ReadLine();

            InputAge();

            InputNum(InputType.Height);

            InputNum(InputType.Weight);
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Type: {this.GetType().Name}, Name: {Name}, Age: {Age}, Height: {Height}, Weight: {Weight}");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Height: {Height}, Weight: {Weight}";
        }
    }

    public class NegativeNumException : Exception
    {
        public NegativeNumException() { }
        public NegativeNumException(string message): base(message) { }
    }

    public class Dog : Animal
    {

    }

    public class Cat : Animal
    {

    }
}
