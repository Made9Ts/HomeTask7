using System;
using System.Linq;

namespace ArrayProcessingApp
{
    public class ArrayProcessor
    {
        /// <summary>
        /// Сортировка массива методом пузырька
        /// </summary>
        public int[] BubbleSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Массив не может быть null");

            if (array.Length <= 1)
                return array;

            int[] sortedArray = (int[])array.Clone();

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                for (int j = 0; j < sortedArray.Length - 1 - i; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }

            return sortedArray;
        }

        /// <summary>
        /// Поиск максимального числа в массиве
        /// </summary>
        public int FindMaxNumber(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Массив не может быть null");

            if (array.Length == 0)
                throw new InvalidOperationException("Невозможно найти максимум в пустом массиве");

            return array.Max();
        }

        /// <summary>
        /// Вычисление среднего арифметического массива
        /// </summary>
        public double CalculateAverage(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Массив не может быть null");

            if (array.Length == 0)
                throw new InvalidOperationException("Невозможно вычислить среднее для пустого массива");

            return array.Average();
        }
    }
}