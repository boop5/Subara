using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public static class LinqExtensions
    {
        private static readonly Random _random = new Random();

        public static T Random<T>(this ICollection<T> sequence)
        {
            return sequence.ElementAt(_random.Next(0, sequence.Count));
        }
    }
}