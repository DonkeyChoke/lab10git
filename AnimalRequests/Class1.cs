namespace AnimalRequests
{
    public class Class1
    {
        public static double AverageWeightOfFemaleAnimals(Animal[] animals)
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
            return counter > 0 ? totalWeight / count : 0;
        }
        public static List<string> FemaleCatsWithGreyColor(Animal[] animals)
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
        public static Fish OldestMaleCat(Animal[] animals)
        {
            Cat oldestCat = null;
            foreach (var animal in animals)
            {
                if (animal is Cat cat && cat.Gender = "Самец")
                {
                    if (oldestCat == null || cat.Age > oldestCat.Age)
                    {
                        oldestCat = cat;
                    }
                }
            }

            return oldestCat;
        }
    }
}
