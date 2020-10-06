using System;
using System.Collections.Generic;
using System.Text;
using FigureCollections;

namespace Collections
{
    class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        public void Push(T element)
        {
            Add(element);
        }
        public T Pop()
        {
            T res;
            if (this.Count == 0)
            {
                throw new Exception("Попытка считывания несуществующего элемента!");
            }
            else
            {
                if (this.Count == 1)
                {
                    res = this.first.data;
                    this.first = null;
                    this.last = null;
                }
                else
                {
                    SimpleListItem<T> prev = this.GetItem(this.Count - 2);
                    res = this.last.data;
                    this.last = null;
                    this.last = prev;
                }
            }
            this.Count--;
            return (res);
        }
    }
}
