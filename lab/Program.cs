using LibAnimals;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace lab10
{
    public class Program
    {
        static List<Animal> animals3 = new List<Animal>();
        static double AverageWeightOfFemaleAnimals(Animal[] animals)
        {
            double totalWeight = 0;
            int counter = 0;
            foreach (var animal in animals)
            {
                if (animal is Mammal mammal && mammal.Gender == "Самка")
                {
                    totalWeight += mammal.Weight;
                    counter++;
                }
            }
            return counter > 0 ? totalWeight / counter : 0;
        }
        static List<string> FemaleCatsWithGreyColor(Animal[] animals)
        {
            List<string> femaleCats = new List<string>();
            foreach (var animal in animals)
            {
                if (animal is Cat cat && cat.Gender == "Самка" && cat.Color == "Серый")
                {
                    femaleCats.Add(cat.Name);
                }
            }
            return femaleCats;
        }
        static Fish OldestSeaFish(Animal[] animals)
        {
            Fish oldestFish = null;
            foreach (var animal in animals)
            {
                if (animal is Fish fish && fish.IsMarine)
                {
                    if (oldestFish == null || fish.Age > oldestFish.Age)
                    {
                        oldestFish = fish;
                    }
                }
            }
            return oldestFish;
        }
        public static void Main(string[] args)
        {
            Animal[] animals = new Animal[20];
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Демонстрационная программа для первой части.\n2. Демонастрационая программа для второй части.\n3. Демонстрационая программа для третьей части.");
                Console.WriteLine("Выберите пункт меню: ");
                string choise = Console.ReadLine();
                try
                {
                    switch (choise)
                    {
                        case "1":
                            Console.Clear();
                            for (int i = 0; i < 20; i=i+4)
                            {
                                animals[i] = new Cat();
                                animals[i+1] = new Animal();
                                animals[i+2] = new Fish();
                                animals[i+3] = new Mammal();
                                animals[i].RandomInit();
                                animals[i+1].RandomInit();
                                animals[i+2].RandomInit();
                                animals[i+3].RandomInit();
                            }
                            for (int i = 0; i < animals.Length; i++)
                            {
                                animals[i].Show();
                            }
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            double averageWeight = AverageWeightOfFemaleAnimals(animals);
                            Console.WriteLine($"\nСредний вес всех животных женского пола: {averageWeight} кг");

                            List<string> femaleCats = FemaleCatsWithGreyColor(animals);
                            Console.WriteLine("\nИмена кошек женского пола серого окраса:");
                            foreach (var catName in femaleCats)
                            {
                                Console.WriteLine(catName);
                            }

                            Fish oldestFish = OldestSeaFish(animals);
                            if (oldestFish != null)
                            {
                                Console.WriteLine($"\nСамая старшая морская рыба: {oldestFish.Name}, Возраст: {oldestFish.Age} лет");
                            }
                            else
                            {
                                Console.WriteLine("\nМорских рыб нет(((.");
                            }
                            Console.ReadKey();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Введите один из пунктов меню!!!");
                            Console.ResetColor();
                            break;
                        case "3":
                            ThirdDemonstration();
                            break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Произошла ошибка: {error.Message}");
                }
            }
        }
        static void ThirdDemonstration()
        {
            Console.Clear();
            Console.WriteLine("Меню третьей части.");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Показать животных");
            Console.WriteLine("3. Отсортировать по возрасту");
            Console.WriteLine("4. Отсортировать по имени");
            Console.WriteLine("5. Поиск по возрасту");
            Console.WriteLine("6. Поиск по имени");
            Console.WriteLine("7. Копировать животное");
            Console.WriteLine("8. Копировать животное поверхностно");
            Console.WriteLine("Выберите пункт меню: ");
            int choise = int.Parse(Console.ReadLine());
            while (true)
            {
                switch (choise)
                {
                    case 1:
                        AddAnimal();
                        break;
                    case 2:
                        ShowAnimals();
                        break;
                    case 3:
                        SortAnimalsByAge();
                        break;
                    case 4:
                        SortAnimalsByName();
                        break;
                    case 5:
                        BinarySearchByAge();
                        break;
                    case 6:
                        BinarySearchByName();
                        break;
                    case 7:
                        CloneAnimal();
                        break;
                    case 8:
                        ShallowCopy();
                        return;
                    default:
                        Console.WriteLine("Введите номер пункта меню (1-8)");
                        break;
                }
            }
        }
        static void AddAnimal()
        {
            Console.Clear();
            Console.WriteLine("\nМеню добавления животного");
            Console.WriteLine("1. Животное");
            Console.WriteLine("2. Млекопитающее");
            Console.WriteLine("3. Кошка");
            Console.WriteLine("4. Рыба");
            Console.WriteLine("5. Назад");
            Console.Write("Выберите тип животного (1-4): ");
            int type;
            if (int.TryParse(Console.ReadLine(), out type))
            {
                Animal animal = null;
                switch (type)
                {
                    case 1:
                        animal = new Animal();
                        break;
                    case 2:
                        animal = new Mammal();
                        break;
                    case 3:
                        animal = new Cat();
                        break;
                    case 4:
                        animal = new Fish();
                        break;
                    case 5:
                        ThirdDemonstration();
                        break;
                    default:
                        Console.WriteLine("Введите номер пункта меню (1-4)");
                        return;
                }
                Console.WriteLine("1.Ввеcти данные самостоятельноили\n2. Сгенерировать случайно");
                int inputChoice;
                if (int.TryParse(Console.ReadLine(), out inputChoice))
                {
                    if (inputChoice == 1)
                    {
                        animal.Init();
                    }
                    else if (inputChoice == 2)
                    {
                        animal.RandomInit();
                    }
                    else
                    {
                        Console.WriteLine("Введите номер пункта меню (1-2)");
                        return;
                    }
                    animals3.Add(animal);
                    Console.WriteLine("Животное добавлено.");
                }
                else
                {
                    Console.WriteLine("Введите номер пункта меню (1-2)");
                }
            }
            Console.ReadKey();
        }
        static void ShowAnimals()
        {
            Console.Clear();
            Console.WriteLine("\nВсе животные:");
            if (animals3.Count == 0)
            {
                Console.WriteLine("Ни одного животного не добавлено.");
            }
            else
            {
                foreach (var animalToShow in animals3)
                {
                    Console.WriteLine(animalToShow);
                }
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
        static void SortAnimalsByAge()
        {
            Console.Clear();
            if (animals3.Count == 0)
            {
                Console.WriteLine("\"Ни одного животного не добавлено.");
                return;
            }

            animals3.Sort();
            Console.WriteLine("\nСписок животных, остортрованный по возрасту:");
            foreach (var animalToShow in animals3)
            {
                Console.WriteLine(animalToShow);
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
        static void SortAnimalsByName()
        {
            Console.Clear();
            if (animals3.Count == 0)
            {
                Console.WriteLine("Ни одного животного не добавлено.");
                return;
            }

            animals3.Sort(new AnimalNameComparer());
            Console.WriteLine("\nСписок животных, остортрованный по имени:");
            foreach (var animal in animals3)
            {
                Console.WriteLine(animal);
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
        static void BinarySearchByAge()
        {
            Console.Clear();
            if (animals3.Count == 0)
            {
                Console.WriteLine("Ни одного животного не добавлено.");
                return;
            }

            Console.Write("Введите возраст: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                animals3.Sort();
                Animal key = new Animal { Age = age };
                int index = animals3.BinarySearch(key);
                if (index >= 0)
                {
                    Console.WriteLine($"Найдено животное с возрастом {age}: {animals3[index]}");
                }
                else
                {
                    Console.WriteLine($"Животное с возрастом {age} не найдено.");
                }
            }
            else
            {
                Console.WriteLine("Введи нормально!");
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
        static void BinarySearchByName()
        {
            Console.Clear();
            if (animals3.Count == 0)
            {
                Console.WriteLine("Ни одного животного не добавлено.");
                return;
            }
            Console.Write("Введите имя для поиска: ");
            string name = Console.ReadLine();
            animals3.Sort(new AnimalNameComparer());
            Animal key = new Animal { Name = name };
            int index = animals3.BinarySearch(key, new AnimalNameComparer());
            if (index >= 0)
            {
                Console.WriteLine($"Найдено животное с именем {name}: {animals3[index]}");
            }
            else
            {
                Console.WriteLine($"Животное с именем {name} не найдено.");
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
        static void CloneAnimal()
        {
            Console.Clear();
            if (animals3.Count == 0)
            {
                Console.WriteLine("Ни одного животного не добавлено.");
                return;
            }
            Console.WriteLine("\nКопирование животного");
            Console.Write("Введите номер животного для клонирования(0-...): ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < animals3.Count)
            {
                Animal clonedAnimal = (Animal)animals3[index].Clone();
                animals3.Add(clonedAnimal);
                Console.WriteLine("Животное успешно копировано и добавлено в список.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
        static void ShallowCopy()
        {
            Console.Clear();
            if (animals3.Count == 0)
            {
                Console.WriteLine("Животных нет.");
                return;
            }

            Console.WriteLine("\nПоверхностное копирование животного");
            Console.Write("Введите индекс животного для копирования: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < animals3.Count)
            {
                Animal shallowCopy = animals3[index].ShallowCopy();
                animals3.Add(shallowCopy);
                Console.WriteLine("Поверхностная копия животного успешно создана.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
            Console.ReadKey();
            ThirdDemonstration();
        }
    }
}