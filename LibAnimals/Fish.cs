using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAnimals
{
    public class Fish : Animal
    {
        public bool IsMarine { get; set; }
        public int FinCount { get; set; }
        public Fish() { }
        public Fish(string name, string gender, int age, bool isSeaFish, int finCount, int id) : base(name, gender, age, id)
        {
            IsMarine = isSeaFish;
            FinCount = finCount;
        }
        public override void Show() //методы
        {
            base.Show();
            Console.WriteLine($"Морская?: {IsMarine}, Кол-во плавников: {FinCount}");
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Рыба морская? (true/false): ");
            IsMarine = bool.Parse(Console.ReadLine());
            Console.Write("Ведите кол-во плавников: ");
            FinCount = int.Parse(Console.ReadLine());
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            IsMarine = rnd.Next(2) == 0;
            FinCount = rnd.Next(1, 10);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Fish other = (Fish)obj;
            return IsMarine == other.IsMarine && FinCount == other.FinCount;
        }
        public override string ToString()
        {
            return base.ToString() + $", Морская?: {IsMarine}, кол-во плавников: {FinCount}";
        }
    }
}
