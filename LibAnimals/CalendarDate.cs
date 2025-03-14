using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibAnimals
{
    public class CalendarDate : IInit
    {
        private int day;
        private int month;
        private int year;
        private static int counter = 0;
        public CalendarDate()///констурктор без параметров
        {
            day = 19;
            month = 3;
            year = 2006;
            counter++;
        }
        public CalendarDate(int day, int month, int year)///конструктор с параметрами
        {
            if (isDateCorrect(day, month, year))
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            else
            {
                throw new Exception("Некорректная дата");
            }
            counter++;
        }
        public int Day
        {
            get { return day; }
            set
            {
                if (isDateCorrect(value, month, year))
                    day = value;
                else
                    throw new Exception("Некорректный ввод дня");
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                if (isDateCorrect(day, value, year))
                    month = value;
                else
                    throw new Exception("Некорректный ввод месяца");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                if (isDateCorrect(day, month, value))
                    year = value;
                else
                    throw new Exception("Некорректный ввод года");
            }
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите день: ");
            day = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц: ");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите год: ");
            year = int.Parse(Console.ReadLine());
        }
        public virtual void RandomInit()
        {
            Random rnd = new Random();
            day = rnd.Next(1, 31);
            month = rnd.Next(1, 13);
            year = rnd.Next(1, 30000);
        }
        public bool isYearLeap()///метод для проверки
        {
            return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
        }
        public static bool isYearLeapStatic(int year)///статический метод для проверки високосности 
        {
            return (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0);
        }
        private bool isDateCorrect(int day, int month, int year)///метод для проверки корректности даты 
        {
            if (day < 1 || month < 1 || month > 12 || year < 1)
                return false;
            int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (isYearLeapStatic(year))
                monthDays[1] = 29;
            return day <= monthDays[month - 1];
        }
        public void Show()///метод для вывода
        {
            Console.WriteLine($"Дата: {day}/{month}/{year}.");
        }
        public static int ShowCounter()
        {
            return counter;
        }
        /// ЧАСТЬ 2  ///
        public static bool operator true(CalendarDate cd) ///Унарные операции (true)
        {
            DateTime currentDate = DateTime.Now;
            DateTime date = new DateTime(cd.year, cd.month, cd.day);
            return date >= currentDate;
        }
        public static bool operator false(CalendarDate cd) ///Унарные операции (false)
        {
            DateTime currentDate = DateTime.Now;
            DateTime date = new DateTime(cd.year, cd.month, cd.day);
            return date < currentDate;
        }
        ///
        public static explicit operator int(CalendarDate cd) ///Операция приведения типа int
        {
            return (cd.month + 2) / 3;
        }
        public static implicit operator string(CalendarDate cd) ///Операция приведения типа string
        {
            return ($"{cd.day}.{cd.month}.{cd.year}");
        }
        ///
        public static CalendarDate operator +(CalendarDate cd, int days) ///Бинарная оперция +
        {
            DateTime date = new DateTime(cd.year, cd.month, cd.day).AddDays(days);
            return new CalendarDate(date.Day, date.Month, date.Year);
        }
        public static CalendarDate operator >>(CalendarDate cd, int months) ///Бинарная операция >>
        {
            DateTime date = new DateTime(cd.year, cd.month, cd.day).AddMonths(months);
            return new CalendarDate(date.Day, date.Month, date.Year);
        }
        ///
        public override bool Equals(object obj) ///Метод Equals для юнит тестов
        {
            if (obj is CalendarDate other)
            {
                return day == other.day && month == other.month && year == other.year;
            }
            return false;
        }
    }
}
