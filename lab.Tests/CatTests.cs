using lab10;
using LibAnimals;

namespace lab10
{
    [TestClass]
    public class CatTests
    {
        [TestMethod]
        public void TestCatConstructor()
        {
            var cat = new Cat();
            Assert.IsNotNull(cat);
            Assert.AreEqual(default(string), cat.Name);
            Assert.AreEqual(default(string), cat.Gender);
            Assert.AreEqual(default(int), cat.Age);
            Assert.AreEqual(0, cat.Id.Number);
            Assert.AreEqual(default(double), cat.Weight);
            Assert.AreEqual(default(string), cat.Breed);
            Assert.AreEqual(default(string), cat.Color);
            Assert.AreEqual(default(double), cat.TailLength);
        }
        [TestMethod]
        public void TestCatConstructorWithParametrs()
        {
            var cat = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Серый", 25.5, 1);
            Assert.AreEqual("Тоша", cat.Name);
            Assert.AreEqual("Самец", cat.Gender);
            Assert.AreEqual(5, cat.Age);
            Assert.AreEqual(10.5, cat.Weight);
            Assert.AreEqual("Мейн-кун", cat.Breed);
            Assert.AreEqual("Серый", cat.Color);
            Assert.AreEqual(25.5, cat.TailLength);
            Assert.AreEqual(1, cat.Id.Number);
        }
        [TestMethod]
        public void TestCatShow()
        {
            var cat = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Серый", 25.5, 1);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                cat.Show();
                var result = sw.ToString().Trim();
                Assert.AreEqual("\nИмя: Тоша, пол: Самец, возраст: 5\nВес: 10.5 кг\nПорода: Мейн-кун, окрас: Серый, длина хвоста: 25.5 см", result);
            }
        }

        [TestMethod]
        public void TestCatInit()
        {
            var cat = new Cat();
            using (var sr = new StringReader("Тоша\nСамец\n5\n10.5\n1\nМейн-кун\nСерый\n25.5"))
            {
                Console.SetIn(sr);
                cat.Init();
                Assert.AreEqual("Тоша", cat.Name);
                Assert.AreEqual("Самец", cat.Gender);
                Assert.AreEqual(5, cat.Age);
                Assert.AreEqual(10.5, cat.Weight);
                Assert.AreEqual("Мейн-кун", cat.Breed);
                Assert.AreEqual("Серый", cat.Color);
                Assert.AreEqual(25.5, cat.TailLength);
                Assert.AreEqual(1, cat.Id.Number);
            }
        }
        [TestMethod]
        public void TestCatRandomInit()
        {
            var cat = new Cat();
            cat.RandomInit();
            Assert.IsNotNull(cat.Name);
            Assert.IsNotNull(cat.Gender);
            Assert.IsTrue(cat.Age >= 1 && cat.Age <= 44);
            Assert.IsTrue(cat.Weight >= 1 && cat.Weight <= 100);
            Assert.IsNotNull(cat.Breed);
            Assert.IsNotNull(cat.Color);
            Assert.IsTrue(cat.TailLength >= 10 && cat.TailLength <= 44);
        }
        [TestMethod]
        public void TestCatEquals()
        {
            var cat1 = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Серый", 25.5, 1);
            var cat2 = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Серый", 25.5, 1);
            var cat3 = new Cat("Федя", "Самец", 5, 10.5, "Мейн-кун", "Серый", 25.5, 1);
            var cat4 = new Cat("Тоша", "Самец", 5, 10.5, "Манчкин", "Серый", 25.5, 1);
            var cat5 = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Черный", 25.5, 1);
            var cat6 = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Серый", 30.5, 1);
            Assert.IsTrue(cat1.Equals(cat2));
            Assert.IsFalse(cat1.Equals(cat3));
            Assert.IsFalse(cat1.Equals(cat4));
            Assert.IsFalse(cat1.Equals(cat5));
            Assert.IsFalse(cat1.Equals(cat6));
        }
        [TestMethod]
        public void TestCatToString()
        {
            var cat = new Cat("Тоша", "Самец", 5, 10.5, "Мейн-кун", "Серый", 25.5, 1);
            var result = cat.ToString();
            Assert.AreEqual("Имя: Тоша, пол: Самец, возраст: 5, Id: 1, вес: 10.5 кг, порода: Мейн-кун, окрас: Серый, длина хвоста: 25.5 см", result);
        }
    }
}