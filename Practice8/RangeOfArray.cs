using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    public class RangeOfArray
    {
        public int[] array { get; set; }
        public int startIndex;

        public RangeOfArray(int startIndex, int endIndex)
        {

            if (startIndex > endIndex)
            {
                throw new ArgumentException("Конечный индекс должен быть больше начального индекса или равен ему.");
            }

            this.startIndex = startIndex;
            int size = endIndex - startIndex+1;
            array = new int[size];
        }

        public int this[int index]
        {

            get
            {
                if (index < startIndex || index >= startIndex + array.Length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы допустимого диапазона.");
                }

                return array[index - startIndex];
            }
            set
            {
                if (index < startIndex || index >= startIndex + array.Length)
                {
                    throw new IndexOutOfRangeException("Индекс выходит за пределы допустимого диапазона.");
                }

                array[index - startIndex] = value;
            }

        }

    }
}
