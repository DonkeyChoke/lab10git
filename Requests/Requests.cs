public static double AverageWeightOfMaleAnimals(Animal[] animals)
{
    double totalWeight = 0;
    int count = 0;

    foreach (var animal in animals)
    {
        if (animal is Mammal mammal && mammal.Gender == "Мужской")
        {
            totalWeight += mammal.Weight;
            count++;
        }
    }

    return count > 0 ? totalWeight / count : 0;
}