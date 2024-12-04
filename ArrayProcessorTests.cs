using System;
using System.Threading.Tasks;
using Xunit;
using ArrayProcessingApp;

namespace ArrayProcessingApp.Tests
{
    public class ArrayProcessorAsyncTests
    {
        private readonly ArrayProcessor _processor;

        public ArrayProcessorAsyncTests()
        {
            _processor = new ArrayProcessor();
        }

        // Пример асинхронного теста с ThrowsAsync
        [Fact]
        public async Task BubbleSort_NullArray_ShouldThrowArgumentNullExceptionAsync()
        {
            // Arrange
            int[] input = null;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // Если метод не асинхронный, можно использовать Task.Run
                await Task.Run(() => _processor.BubbleSort(input));
            });

            Assert.Contains("array", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        // Если нужен полностью асинхронный метод в классе ArrayProcessor
        public class AsyncArrayProcessor
        {
            // Пример асинхронного метода
            public async Task<int[]> BubbleSortAsync(int[] array)
            {
                if (array == null)
                    throw new ArgumentNullException(nameof(array), "Массив не может быть null");

                // Симуляция асинхронной операции
                await Task.Delay(10);

                return BubbleSort(array);
            }

            // Существующий синхронный метод
            private int[] BubbleSort(int[] array)
            {
                // Логика сортировки осталась прежней
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
        }

        // Тесты для асинхронного ArrayProcessor
        public class AsyncArrayProcessorTests
        {
            private readonly AsyncArrayProcessor _processor;

            public AsyncArrayProcessorTests()
            {
                _processor = new AsyncArrayProcessor();
            }

            [Fact]
            public async Task BubbleSortAsync_ValidArray_ShouldReturnSortedArray()
            {
                // Arrange
                int[] input = { 5, 2, 9, 1, 7 };
                int[] expected = { 1, 2, 5, 7, 9 };

                // Act
                int[] result = await _processor.BubbleSortAsync(input);

                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public async Task BubbleSortAsync_NullArray_ShouldThrowArgumentNullException()
            {
                // Arrange
                int[] input = null;

                // Act & Assert
                var exception = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                {
                    await _processor.BubbleSortAsync(input);
                });

                Assert.Contains("array", exception.Message, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}