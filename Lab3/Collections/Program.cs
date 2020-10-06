using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Figures;
using Collections;
using System.Linq;
using SparseMatrix;
using FigureCollections;

namespace Collections
{
    class Program
    {
        public static void PrintCollection(IEnumerable col)
        {
            foreach (object obj in col)
            {
                if (obj.GetType().Namespace == "Figures")
                {
                    Figure t_obj = obj as Figure;
                    t_obj.Print();
                }
                else
                    Console.WriteLine(obj.ToString());
            }
        }
        static void Main(string[] args)
        {
            Square sq = new Square(5);
            Rectangle rec = new Rectangle(10, 5);
            Circle cir = new Circle(1);
            ArrayList AL1 = new ArrayList();
            AL1.Add(sq);
            AL1.Add(rec);
            AL1.Add(cir);
            AL1.Sort();
            Console.WriteLine("ArrayList:\n");
            PrintCollection(AL1);
            List<Figure> list1 = new List<Figure>();
            list1.Add(sq);
            list1.Add(rec);
            list1.Add(cir);
            list1.Sort();
            Console.WriteLine("\nList<Figure>:\n");
            PrintCollection(list1);
            Console.Write("\n");
            Matrix<Figure> x = new Matrix<Figure>(4, 3, 3, null);
            x[0, 0, 0] = sq;
            x[1, 1, 0] = rec;
            x[2, 2, 0] = cir;
            Console.WriteLine(x.ToString() + "\n\n");
            SimpleStack<Figure> figures = new SimpleStack<Figure>();
            figures.Add(cir);
            figures.Add(sq);
            figures.Add(rec);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(figures.Pop().ToString() + "\n");
            }
            try
            {
                Console.WriteLine(figures.Pop().ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
