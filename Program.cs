using System;

namespace Rozumatic_OOP_Practice13
{
    // ==========================================================================
    // БАЗОВИЙ КЛАС: SHAPE (Геометрична фігура)
    // ==========================================================================
    public class Shape
    {
        // Віртуальний метод обчислення площі (базова реалізація повертає 0)
        public virtual double GetArea()
        {
            return 0;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Фігура: Невідома | Площа = {GetArea()}");
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: CIRCLE (Коло — Загальне завдання)
    // ==========================================================================
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        // Перевизначення (override) віртуального методу площі кола
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Коло    | Радіус = {Radius,-4} | Обчислена площа = {GetArea():F2}");
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: RECTANGLE (Прямокутник — Загальне завдання)
    // ==========================================================================
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Перевизначення (override) віртуального методу площі прямокутника
        public override double GetArea()
        {
            return Width * Height;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Прямокутник | Сторони = {Width}x{Height,-2} | Обчислена площа = {GetArea():F2}");
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: TRIANGLE (Трикутник — Домашнє завдання)
    // ==========================================================================
    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        // Перевизначення (override) віртуального методу площі трикутника
        public override double GetArea()
        {
            return 0.5 * BaseLength * Height;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Трикутник   | Основа = {BaseLength}, Вис = {Height} | Обчислена площа = {GetArea():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  РОЗУМАТИК // ПРАКТИЧНЕ ЗАНЯТТЯ №13: ПОЛІМОРФІЗМ ТА ВІРТУАЛЬНІ МЕТОДИ");
            Console.WriteLine("==========================================================================");

            // Демонстрація поліморфізму: створюємо масив посилань на базовий тип Shape,
            // але заповнюємо його реальними об'єктами різних дочірніх класів.
            Shape[] shapes = new Shape[]
            {
                new Circle(5.0),
                new Rectangle(4.0, 6.0),
                new Triangle(5.0, 3.0)
            };

            Console.WriteLine("\n--- Обхід масиву фігур за допомогою поліморфного виклику методів ---");
            
            // Завдяки динамічному зв'язуванню (пізньому зв'язуванню), для кожного об'єкта 
            // викликається саме його версія перевизначеного методу площі та інформації.
            foreach (Shape shape in shapes)
            {
                shape.PrintInfo();
            }
        }
    }
}
