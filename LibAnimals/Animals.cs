using System.Reflection;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace LibAnimals
{
    public class Animal : IInit, ICloneable, IComparable<Animal>
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public IdNumber Id { get; set; }
        public Animal() //конструкторы
        {
            Id = new IdNumber(0);
        }
        public Animal(string name, string gender, int age,int id)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Id = new IdNumber(id);
        }
        public virtual void Show() //методы
        {
            Console.WriteLine($"\nИмя: {Name}, пол: {Gender}, возраст: {Age}");
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите имя: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите пол: ");
            Gender = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Введите ID: ");
            Id = new IdNumber(int.Parse(Console.ReadLine()));
        }
        public virtual void RandomInit()
        {
            Random rnd = new Random();
            string[] names = { "Тоша", "Федя", "Настя", "Бобик", "Чипс" };
            string[] genders = { "Самец", "Самка" };
            Name = names[rnd.Next(names.Length)];
            Gender = genders[rnd.Next(genders.Length)];
            Age = rnd.Next(1, 44);
            Id = new IdNumber(rnd.Next(1, 101));
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Animal other = (Animal)obj;
            return Name == other.Name && Gender == other.Gender && Age == other.Age && Id == other.Id;
        }
        public override string ToString()
        {
            return $"Имя: {Name}, пол: {Gender}, возраст: {Age}, Id: {Id}";
        }
        public int CompareTo(Animal other)
        {
            return Age.CompareTo(other.Age);
        }
        public object Clone() //глубокое копирование 
        {
            return new Animal
            {
                Name = this.Name,
                Gender = this.Gender,
                Age = this.Age,
                Id = new IdNumber(this.Id.Number)
            };
        }
        public Animal ShallowCopy()//поверхностное копирование
        {
            return (Animal)this.MemberwiseClone();
        }
    }
}
