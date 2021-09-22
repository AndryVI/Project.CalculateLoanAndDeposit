using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FinalProject
{
    class CheckValues
    {
        private int step;
        public double  givevalue;
        public void CheckFunction(int getvalue, string  firsttest, string secondtext)
        {
            step = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(firsttest);

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();

                givevalue = double.Parse(Console.ReadLine(), numberFormatInfo);
                if (givevalue <= getvalue)
                {
                    step = 1;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(secondtext);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            while (step < 1);
            //return givevalue;
        }
    }
}
