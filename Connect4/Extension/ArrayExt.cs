using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Connect4.Extension
{
    public static class ArrayExt
    {
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var columns = array.GetUpperBound(1) + 1;

            return Enumerable.Range(0, columns)
                .Select(i => array[row, i])
                .ToArray();
        }

        public static T[] GetColumn<T>(this T[,] array, int column)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var rows = array.GetUpperBound(0) + 1;
            
            return Enumerable.Range(0, rows)
                .Select(i => array[i, column])
                .ToArray();
        }

        public static T[][] GetRows<T>(this T[,] array)
        {
            var rows = array.GetUpperBound(0) + 1;
            return Enumerable.Range(0, rows).Select(i => GetRow(array, i)).ToArray();
        }

        public static T Random<T>(this T[] array)
        {
            var rand = new Random();
            return array.ElementAt( rand.Next( array.Count() ) );
        }
    }
}