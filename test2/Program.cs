﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace test2
{

    class ElementComparer : IEqualityComparer<Element>
    {
        public bool Equals(Element x, Element y)
        {
            return x.Num == y.Num;
        }

        public int GetHashCode(Element obj)
        {
            return obj.Num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Element> list = new List<Element>()
            {
                new Element() { Num = 1, Age = 32, Name = "John" },
                new Element() { Num = 2, Age = 52, Name = "Alex" },
                new Element() { Num = 3, Age = 22, Name = "Ringo" },
                new Element() { Num = 3, Age = 15, Name = "George" },
                new Element() { Num = 4, Age = 12, Name = "Paul" },
                new Element() { Num = 5, Age = 42, Name = "Freddie" },
                new Element() { Num = 5, Age = 22, Name = "Brian" },
                new Element() { Num = 4, Age = 18, Name = "Roger" }
            };

            var elements = FilterElements(list);
            foreach (var element in elements)
            {
                Console.WriteLine($"Num: {element.Num} Age: {element.Age} Name: {element.Name}");
            }
        }

        static ICollection<Element> FilterElements(ICollection<Element> elements)
        {
            return elements.Where(el => el.Age > 20).Distinct(new ElementComparer()).ToList();
        }
    }
}
