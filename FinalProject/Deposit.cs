using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Deposit
    {
        private int  issuedate = 0, depositamount = 0, count, day, cheak;
        private double  resuldeposit = 0, replenishment = 0, resuldmonthly = 0, interestrate = 0, newdepositamount;

        public void DepositAccount(int setsubmenu)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nДля просчета депозита введите поочерёдно: \nСумма депозита (максимум  1 000 000 000 ), \nГодовую процентную ставку, Cрок вложения депозита :\n");
            cheak = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\nСумма вложенного депозита, в грн.: ");
                depositamount = int.Parse(Console.ReadLine());
                if (depositamount <= 1000000000)
                {
                    cheak = 1;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"\nВы ввели некорректную  сумму\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            while (cheak < 1);
            
            Console.Write($"\nГодовую процентную ставку,  %    : ");
            interestrate = double.Parse(Console.ReadLine());

            Console.Write($"\nСрок вложения депозита, в месяцах: ");
            issuedate = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkGray;


            if (setsubmenu == (int)SubMenuDepositC.WithoutReplenishment)
            {
                resuldmonthly = resuldeposit = 0;
                Console.WriteLine("\nВы выбрали просчет депозита без пополнения:\n");
                Console.WriteLine("{0,44}{1,30}", "Начисление с %", "Сумма начислений с %");
                //Количество дней в месяце 
                count = 1;
                interestrate += 2;
                for (int month = 1; month <= issuedate; month++)
                {
                    switch (count)
                    {
                        case 1: day = 31; break;
                        case 2: day = 28; break;
                        case 3: day = 31; break;
                        case 4: day = 30; break;
                        case 5: day = 31; break;
                        case 6: day = 30; break;
                        case 7: day = 31; break;
                        case 8: day = 31; break;
                        case 9: day = 30; break;
                        case 10: day = 31; break;
                        case 11: day = 30; break;
                        case 12: day = 31; break;
                        default: break;
                    }
                    resuldmonthly = Math.Round(((depositamount * interestrate * day) / 365 / 100),2);
                    resuldeposit += Math.Round(resuldmonthly,2);
                    Console.WriteLine("% по вкладу в {0,3} месяце: {1,15}{2,25}", month, resuldmonthly, Math.Round(resuldeposit,2));
                    if (count >= 12)
                    {
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }
                }
                Console.WriteLine($"\nСумма % по вкладу: {Convert.ToUInt64(resuldeposit)}, грн");
                Console.WriteLine($"\nИтого:             {Convert.ToUInt64(depositamount + resuldeposit)}, грн");


            }
            else if (setsubmenu == (int)SubMenuDepositC.WithReplenishment)
            {
                cheak = 0;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"\nВведите сумму ежемесячного пополнения \n(максимальное пополезнее 100 000 ), в грн.: ");
                    replenishment = int.Parse(Console.ReadLine());
                    if (replenishment <= 100000)
                    {
                        cheak = 1;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"\nВы ввели некорректную сумму\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                while (cheak < 1);
                
                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine("\nВы выбрали просчет депозита без пополнения:\n");

                resuldmonthly = resuldeposit = 0;
                
                Console.WriteLine("{0,40}{1,16}{2,18}", "Начисление с %", "Сумма  с %", "Сумма тела");
                //Количество дней в месяце 
                newdepositamount = depositamount;
                count = 1;
                for (int month = 1; month <= issuedate; month++)
                {
                    switch (count)
                    {
                        case 1: day = 31; break;
                        case 2: day = 28; break;
                        case 3: day = 31; break;
                        case 4: day = 30; break;
                        case 5: day = 31; break;
                        case 6: day = 30; break;
                        case 7: day = 31; break;
                        case 8: day = 31; break;
                        case 9: day = 30; break;
                        case 10: day = 31; break;
                        case 11: day = 30; break;
                        case 12: day = 31; break;
                        default: break;
                    }
                    resuldmonthly = Math.Round(((newdepositamount * interestrate * day) / 365 / 100), 2);
                    resuldeposit += Math.Round(resuldmonthly, 2);
                    Console.WriteLine("% по вкладу в {0,3} месяце: {1,10}{2,18}{3,18}", month, resuldmonthly, Math.Round(resuldeposit, 2), Math.Round(newdepositamount, 2));
                    newdepositamount += replenishment;
                    if (count >= 12)
                    {
                        count = 1;
                    }
                    else 
                    {
                        count++;
                    }     
                }
                Console.WriteLine($"\nНачальное вложение: {Convert.ToInt32(depositamount)}, грн");
                Console.WriteLine($"\nСумма % по вкладу:  {Convert.ToUInt64(resuldeposit)}, грн");
                Console.WriteLine($"\nСумма вложении:     {Convert.ToInt32(newdepositamount- replenishment)}, грн");
                Console.WriteLine($"\nИтоговая сумма :    {Convert.ToUInt64(newdepositamount + resuldeposit- replenishment)}, грн");


            }

        }

    }
}
