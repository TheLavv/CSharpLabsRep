using System;

namespace Figures
{
    public interface IPrint
    {
        public void Print();
    }
    public abstract class Figure : IPrint, IComparable
    {
        public abstract double CountArea();
        public int CompareTo(object t_obj)
        {
            if (t_obj.GetType().Namespace != "Figures" || 
                this.GetType().Namespace != "Figures")
                throw new ArgumentException("Неверный тип!");
            Figure f_obj = t_obj as Figure;
            if (f_obj.CountArea() > this.CountArea())
            {
                return (-1);
            }
            else if (f_obj.CountArea() == this.CountArea())
                return (0);
            else
                return (1);
        }
        public override string ToString()
        {
            return (this.GetType().Name + " " + CountArea().ToString());
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
}
