using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Overnight
    {
        private uint overnightamount = 0, newovernightamount = 0;
        private const int commission = 2800;
        private int issuedate = 0,  checkamount ;
        private double interestrate = 0, resulovernight = 0, resulovernightwithcommission, sumresulovernight;
        public void OvernightAccount()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nДля просчета Овернайт введите поочерёдно:\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nСумма депозита (вклад от 30 000 000 грн. до 4 000 000 000), \nПроцентная ставка минимум 3,5 (дробная ставка вводится через ‘,’), \nСрок вложения депозита (в днях)\n");
            checkamount = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\nСумма депозита, в грн.: ");
                overnightamount = uint.Parse(Console.ReadLine());

                if (overnightamount < 30000000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nВы введи сумме меньше 30 000 000 грн! Введите корректную сумму.\n");
                }
                else 
                {
                    checkamount = 1;
                    newovernightamount = overnightamount;
                }
            }
            while (checkamount < 1);
            checkamount = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\nПроцентная ставка,  % : ");
                interestrate = double.Parse(Console.ReadLine());

                if (interestrate <= 3.5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nВы ввели процентную ставку при который не будет прибили! Введите процентную ставка выше 3,5%.\n");
                }
                else
                {
                    checkamount = 1;
                }
            }
            while (checkamount < 1);
            

            Console.Write($"\nСрок вложения, в днях : ");
            issuedate = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkGray;
            
            Console.WriteLine("\n{0}{1}{2}{3}", "Сумма начисленных %".ToString().PadLeft(30), "Комиссия банка".ToString().PadLeft(17), "Остаток %".ToString().PadLeft(13), "Общая сумма".ToString().PadLeft(17));
            for (int day = 1; day <= issuedate; day++)
            {
                //Сумма начисленных %
                resulovernight = Math.Round(((newovernightamount * (interestrate/100) / 365)), 2);
                //Сомиссия банка - 100 дол.
                resulovernightwithcommission = Math.Round((resulovernight - commission),2);
                //Сумма % с вычетом комиссии 
                sumresulovernight += Math.Round(resulovernightwithcommission,2);
                //Сумма в клада с % 
                newovernightamount += Convert.ToUInt32(resulovernightwithcommission);
                Console.WriteLine("В {0} день: {1}{2}{3}{4}", day.ToString().PadLeft(2), resulovernight.ToString().PadLeft(13), commission.ToString().PadLeft(17), resulovernightwithcommission.ToString().PadLeft(19), newovernightamount.ToString().PadLeft(17));
            }

            Console.WriteLine($"\nСумма начисленных % с вычетом комиссии :  {Convert.ToInt32(sumresulovernight)}, грн");

            Console.WriteLine($"\nCумма вклад + начисленных % с комиссии :  {newovernightamount}, грн");
        }
    }
}
