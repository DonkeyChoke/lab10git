using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAnimals
{
    public class Cat : Mammal
    {
        public string Breed { get; set; }
        public string Color { get; set; }
        public double TailLength { get; set; }
        public Cat() { }
        public Cat(string name, string gender, int age, double weight, string breed, string color, double tailLength, int id) : base(name, gender, age, weight, id)
        {
            Breed = breed;
            Color = color;
            TailLength = tailLength;
        }
        public override void Show() //методы
        {
            base.Show();
            Console.WriteLine($"Порода: {Breed}, окрас: {Color}, длина хвоста: {TailLength} см");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите породу: ");
            Breed = Console.ReadLine();
            Console.WriteLine("Введите окрас: ");
            Color = Console.ReadLine();
            Console.WriteLine("Введите длину хвоста в см: ");
            TailLength = double.Parse(Console.ReadLine());
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            string[] breeds = {"Мейн-кун", "Манчкин", "Русская голубая", "Сибирская", "Бенгальская"};
            string[] colors = {"Серый", "Черный", "Белый", "Рыжий", "Дымчатый"};
            Breed = breeds[rnd.Next(breeds.Length)];
            Color = colors[rnd.Next(colors.Length)];
            TailLength = rnd.Next(10, 44);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Cat other = (Cat)obj;
            return Breed == other.Breed && Color == other.Color && TailLength == other.TailLength;
        }
        public override string ToString()
        {
            return base.ToString() + $", порода: {Breed}, окрас: {Color}, длина хвоста: {TailLength} см";
        }
    }
}
