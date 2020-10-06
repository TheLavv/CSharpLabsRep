using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Figures;

namespace Collections
{
    public class Collection
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
    }
}
