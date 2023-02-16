using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_1.Extensions.CustomerExtensions
{
    public static class Extension
    {
        // Bu metod ile bir öğe (item)’in koleksiyon içerisinde olup olmadığını kontrol etmek için kullanılabilir.
        public static bool In<T>(this T value, params T[] list)
        {
            if (null == value) throw new ArgumentNullException("value");
            return list.Contains(value);
        }

        //koleksiyon içerisinde tekrar eden kayıtları silmenize yarayacak başla bir extension metod

        public static List<Customer> RemoveDuplicates<Customer>(this List<Customer> input)
        {
            Dictionary<Customer, int> uniqueStore = new Dictionary<Customer, int>();
            List<Customer> finalList = new List<Customer>();

            foreach (Customer currValue in input)
            {
                if (!uniqueStore.ContainsKey(currValue))
                {
                    uniqueStore.Add(currValue, 0);
                    finalList.Add(currValue);
                }
            }
            return finalList;
        }

    }
}
