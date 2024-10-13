using System;

namespace SportsManagement
{
    using MainData;

    class Program
    {
        static void Main(string[] args)
        {
            Football f = new Football();
            Tenis t = new Tenis();
            Volleyball v = new Volleyball();

            f.InputInfo(); t.InputInfo(); v.InputInfo();
            f.DisplayInfo(); t.DisplayInfo(); v.DisplayInfo();

            Console.ReadLine();
        }
    }
}

namespace MainData
{
    public class Sport
    {
        public int Num { get; set; }
        public TimeSpan Time { get; set; }
        public string Ball { get; set; }

        public virtual void InputInfo()
        {
            Console.WriteLine($"Enter Info of {this.GetType().Name}:");

            Console.Write("Number of players: "); Num = int.Parse(Console.ReadLine());
            Console.Write("Time limit: "); Time = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Ball's type: "); Ball = Console.ReadLine();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n{this.GetType().Name}\n");

            Console.WriteLine($"Players: {Num}");
            Console.WriteLine($"Time limit: {Time}");
            Console.WriteLine($"Ball's type: {Ball}");
        }
    }

    public class Football : Sport { }
    public class Tenis : Sport { }
    public class Volleyball : Sport { }
}