using lab10;
using LibAnimals;

namespace lab10
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void TestAnimalConstructor()
        {
            var animal = new Animal();
            Assert.IsNotNull(animal);
            Assert.AreEqual(default(string), animal.Name);
            Assert.AreEqual(default(string), animal.Gender);
            Assert.AreEqual(default(int), animal.Age);
            Assert.AreEqual(0, animal.Id.Number);
        }
        [TestMethod]
        public void TestAnimalConstructorWithParametrs()
        {
            var animal = new Animal("Тоша", "Самец", 5, 1);
            Assert.AreEqual("Тоша", animal.Name);
            Assert.AreEqual("Самец", animal.Gender);
            Assert.AreEqual(5, animal.Age);
            Assert.AreEqual(1, animal.Id.Number);
        }
        [TestMethod]
        public void TestAnimalShow()
        {
            var animal = new Animal("Тоша", "Самец", 5, 1);
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                animal.Show();
                var result = sw.ToString().Trim();
                Assert.AreEqual("\nИмя: Тоша, пол: Самец, возраст: 5", result);
            }
        }
        [TestMethod]
        public void TestAnimalInit()
        {
            var animal = new Animal();
            using (var sr = new StringReader("Тоша\nСамец\n5\n1"))
            {
                Console.SetIn(sr);
                animal.Init();
                Assert.AreEqual("Тоша", animal.Name);
                Assert.AreEqual("Самец", animal.Gender);
                Assert.AreEqual(5, animal.Age);
                Assert.AreEqual(1, animal.Id.Number);
            }
        }
        [TestMethod]
        public void TestAnimalRandomInit()
        {
            var animal = new Animal();
            animal.RandomInit();
            Assert.IsNotNull(animal.Name);
            Assert.IsNotNull(animal.Gender);
            Assert.IsTrue(animal.Age >= 1 && animal.Age <= 44);
            Assert.IsTrue(animal.Id.Number >= 1 && animal.Id.Number <= 100);
        }
        [TestMethod]
        public void TestAnimalEquals()
        {
            var animal1 = new Animal("Тоша", "Самец", 5, 1);
            var animal2 = new Animal("Тоша", "Самец", 5, 1);
            var animal3 = new Animal("Вася", "Самец", 5, 1);
            Assert.IsTrue(animal1.Equals(animal2));
            Assert.IsFalse(animal1.Equals(animal3));
        }
        [TestMethod]
        public void TestAnimalToString()
        {
            var animal = new Animal("Тоша", "Самец", 5, 1);
            var result = animal.ToString();
            Assert.AreEqual("Имя: Тоша, пол: Самец, возраст: 5, Id: 1", result);
        }
        [TestMethod]
        public void TestAnimalCompareTo()
        {
            var animal1 = new Animal("Тоша", "Самец", 5, 1);
            var animal2 = new Animal("Федя", "Самец", 10, 2);
            var animal3 = new Animal("Настя", "Самка", 5, 3);
            Assert.IsTrue(animal1.CompareTo(animal2) < 0);
            Assert.IsTrue(animal2.CompareTo(animal1) > 0);
            Assert.IsTrue(animal1.CompareTo(animal3) == 0);
        }

        [TestMethod]
        public void TestAnimalClone()
        {
            var animal = new Animal("Тоша", "Самец", 5, 1);
            var clonedAnimal = (Animal)animal.Clone();
            Assert.AreEqual(animal.Name, clonedAnimal.Name);
            Assert.AreEqual(animal.Gender, clonedAnimal.Gender);
            Assert.AreEqual(animal.Age, clonedAnimal.Age);
            Assert.AreEqual(animal.Id.Number, clonedAnimal.Id.Number);
            Assert.AreNotSame(animal, clonedAnimal);
        }

        [TestMethod]
        public void TestAnimalShallowCopy()
        {
            var animal = new Animal("Тоша", "Самец", 5, 1);
            var shallowCopiedAnimal = animal.ShallowCopy();
            Assert.AreEqual(animal.Name, shallowCopiedAnimal.Name);
            Assert.AreEqual(animal.Gender, shallowCopiedAnimal.Gender);
            Assert.AreEqual(animal.Age, shallowCopiedAnimal.Age);
            Assert.AreEqual(animal.Id.Number, shallowCopiedAnimal.Id.Number);
            Assert.AreNotSame(animal, shallowCopiedAnimal);
        }
    }
}