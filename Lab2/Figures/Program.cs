using System;

namespace Figures
{
    public interface IPrint
    {
        public void Print();
    }
    public abstract class Figure : IPrint
    {
        public abstract double CountArea();
        public override string ToString()
        {
            return (this.GetType().ToString().Remove(0, 8) + " " + CountArea().ToString());
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    public class Rectangle : Figure
    {
        protected double width;
        protected double height;

        public Rectangle(double t_width, double t_height)
        {
            width = t_width;
            height = t_height;
        }
        public override double CountArea()
        {
            return (width * height);
        }
    }
    public class Square : Rectangle
    {
        public Square(double t_width) : base(t_width, t_width) { }
    }

    public class Circle : Figure
    {
        public double radius;

        public Circle(double t_radius)
        {
            radius = t_radius;
        }

        public override double CountArea()
        {
            return (Math.PI * radius * radius);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Разработчик: Головацкий Андрей\nГруппа: ИУ5-31Б\n");
            Circle obj = new Circle(4);
            Square sq1 = new Square(5);
            Rectangle rect1 = new Rectangle(4, 5);
            sq1.Print();
            rect1.Print();
            obj.Print();
        }
    }
}
