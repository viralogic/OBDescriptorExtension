using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBDescriptorExtension
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Zeros all entries
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static IEnumerable<T> Zero<T>(this IEnumerable<T> source)
        {
            return source.Zero(0);
        }

        /// <summary>
        /// Zeros rest of entries from a given starting position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public static IEnumerable<T> Zero<T>(this IEnumerable<T> source, int startPos)
        {
            var array = source.ToArray();
            Array.Clear(array, startPos, array.Length - startPos);
            return array;
        }

        /// <summary>
        /// Finds position of first element that is equal to or less than a value
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="source">IEnumerable containing double elements</param>
        /// <param name="value">double</param>
        /// <param name="startPos">int</param>
        /// <returns>position of found element, otherwise -1</returns>
        public static int IndexOf(this IEnumerable<double> source, double value, int startPos)
        {
            int i = startPos;
            var array = source.OrderBy(d => d).ToArray();
            while(i < array.Length && array[i] <= value)
            {
                i++;
            }
            return i;
        }

        /// <summary>
        /// Finds position of first element that is equal to or less than a value
        /// </summary>
        /// <param name="source">IEnumerable containing integer elements</param>
        /// <param name="value">int</param>
        /// <param name="startPos">int</param>
        /// <returns>position of found element, otherwise -1</returns>
        public static int IndexOf(this IEnumerable<int> source, int value, int startPos)
        {
            var array = (IEnumerable<double>)source;
            return array.IndexOf((double)value, startPos);
        }

        /// <summary>
        /// Determines the insertion index immediately to left of an element matching a given value
        /// </summary>
        /// <param name="source">IEnumerable with double elements</param>
        /// <param name="value">double</param>
        /// <returns>position of left bisection point</returns>
        public static int BisectLeft(this IEnumerable<double> source, double value)
        {
            return source.IndexOf(value, 0) - 1;
        }

        /// <summary>
        /// Determines the insertion index immediately to left of an element matching a given value
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="source">IEnumerable with integer elements</param>
        /// <param name="value">int</param>
        /// <returns>position of left bisection point</returns>
        public static int BisectLeft(this IEnumerable<int> source, int value)
        {
            var array = (IEnumerable<double>)source;
            return array.BisectLeft((double)value);
        }

        /// <summary>
        /// Determines the insertion index immediately to the right of an element matching a given value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">IEnumerable containing double elements</param>
        /// <param name="value">double</param>
        /// <returns>-1 if not found, otherwise the immediately right index</returns>
        public static int BisectRight(this IEnumerable<double> source, double value)
        {
            return source.IndexOf(value, 0);
        }

        /// <summary>
        /// Determines the insertion index immediately to the right of an element matching a given value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">IEnumerable containing int elements</param>
        /// <param name="value">int</param>
        /// <returns>-1 if not found, otherwise the immediately right index</returns>
        public static int BisectRight(this IEnumerable<int> source, int value)
        {
            var array = (IEnumerable<double>)source;
            return array.BisectRight((double)value);
        }

        /// <summary>
        /// Returns element wise absolute values in a collection
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<double> Abs(this IEnumerable<double> source)
        {
            return source.Select(i => Math.Abs(i));
        }

        /// <summary>
        /// Returns element wise absolute values in a collection
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<int> Abs(this IEnumerable<int> source)
        {
            return (IEnumerable<int>)((IEnumerable<double>)source).Abs();
        }

        /// <summary>
        /// Calculates the informational entropy of a collection
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double InfoEntropy(this IEnumerable<double> source)
        {
            var numInstances = source.Sum();
            if (numInstances == 0)
            {
                return 0;
            }
            var array = source.ToArray();
            double accum = 0;
            for (var i = 0; i < array.Length; i++)
            {
                var d = array[i] / numInstances;
                if (d != 0)
                {
                    accum += -d * Math.Log(d);
                }
            }
            return accum / Math.Log(2);
        }

        /// <summary>
        /// Element-wise addition of two double collections
        /// </summary>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IEnumerable<double> Add(this IEnumerable<double> source1, IEnumerable<double> source2)
        {
            if (source1.Count() != source2.Count())
            {
                throw new Exception("Length of the two arrays are not equal");
            }
            var array1 = source1.ToArray();
            var array2 = source2.ToArray();
            var length = array1.Length;
            var result = new double[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = array1[i] + array2[i];
            }
            return result;
        }

        /// <summary>
        /// Element-wise addition of two integer collections
        /// </summary>
        /// <param name="source1"></param>
        /// <param name="source2"></param>
        /// <returns></returns>
        public static IEnumerable<int> Add(this IEnumerable<int> source1, IEnumerable<int> source2)
        {
            return (IEnumerable<int>)((IEnumerable<double>)source1).Add((IEnumerable<double>)source2);
        }


        /// <summary>
        /// Add scalar value to double collection
        /// </summary>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static IEnumerable<double> Add(this IEnumerable<double> source, double scalar)
        {
            return source.Select(i => i + scalar);
        }

        /// <summary>
        /// Add scalar value to integer collection
        /// </summary>
        /// <param name="source"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static IEnumerable<int> Add(this IEnumerable<int> source, int scalar)
        {
            return (IEnumerable<int>)((IEnumerable<double>)source).Add((double)scalar);
        }

        /// <summary>
        /// Computes the variance of a collection of doubles
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Variance(this IEnumerable<double> source)
        {
            var denominator = source.Count() > 1 ? source.Count() - 1 : 1;
            var mean = source.Average();
            var sum = source.Select(i => Math.Pow(i - mean, 2)).Sum();
            return sum / denominator;
        }

        /// <summary>
        /// Computes the standard deviation for a collection of integers
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Variance(this IEnumerable<int> source)
        {
            return ((IEnumerable<double>)source).Variance();
        }

        /// <summary>
        /// Return the median of a collection of doubles
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Median(this IEnumerable<double> source)
        {
            var count = source.Count();
            var array = source.OrderBy(i => i).ToArray();
            var pos = (int)(count / 2);
            if (count % 2 == 0)
            {
                return (array[pos] + array[pos - 1]) / 2;
            }
            return array[pos];
        }

        /// <summary>
        /// Return the median of a collection of integers
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double Median(this IEnumerable<int> source)
        {
            return ((IEnumerable<double>)source).Median();
        }
    }
}
