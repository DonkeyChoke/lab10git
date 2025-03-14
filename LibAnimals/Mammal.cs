using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibAnimals
{
    public class Mammal : Animal
    {
        public double Weight { get; set; }
        public Mammal() { }
        public Mammal(string name, string gender, int age, double weight, int id) : base(name, gender, age, id)
        {
            Weight = weight;
        }
        public override void Show() //методы
        {
            base.Show();
            Console.WriteLine($"Вес: {Weight} кг");
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Введите вес в кг: ");
            Weight = double.Parse(Console.ReadLine());
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            Weight = rnd.Next(1, 100);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Mammal other = (Mammal)obj;
            return Weight == other.Weight;
        }
        public override string ToString()
        {
            return base.ToString() + $", вес: {Weight} кг";
        }
    }
}