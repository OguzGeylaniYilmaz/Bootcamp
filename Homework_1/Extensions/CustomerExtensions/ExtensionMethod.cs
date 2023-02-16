using Homework_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_1.Extensions.CustomerExtensions
{
    public static class ExtensionMethod
    {
        // Customer modelinde name ve lastname'in beraber yazmılması istenirse kullanılabilir
        public static string FullName(this Customer value)
        {
            return $"{value.Name} {value.LastName}";
        }

        // Bu metod ile bir öğe (item)’in koleksiyon içerisinde olup olmadığını kontrol etmek için kullanılabilir
        public static bool In<T>(this T value,params T[] list)
        {
            if (null == value) throw new ArgumentNullException("value");
            return list.Contains(value);
        }

        // Koleksiyon içerisinde tekrar eden kayıtları silmenize yarayacak bir örnek extension

        public static List<T> RemoveDuplicates<T>(this List<T> input)
        {
            Dictionary<T, int> uniqueStore = new Dictionary<T, int>();
            List<T> finalList = new List<T>();

            foreach (T currValue in input)
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
