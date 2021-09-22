using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    static class ArrayCount
    {
        //количества строк матрицы
        public static int RowsCount(this string[] array)
        {
            return array.GetUpperBound(0) + 1;
        }
    }
}
