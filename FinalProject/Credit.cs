using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


//Считать проценты по кредиту (Тело кредита, проценты, количество месяцев)
//Аннуитетный кредит или дифференцированный
namespace FinalProject
{
    class Credit
    {
        private int issuedate = 0; //cheak
        private double interestrate = 0, rate = 0, coefficient = 0, monthlypaymentpercent = 0, constantpartofpayment = 0, overpayment = 0, monthlypayment = 0, resulcredit = 0; //creditamount = 0,

        CheckValues creditamount = new CheckValues();
        public void CreditAccount(int setsubmenu)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nДля просчета кредита введите поочерёдно: \nСумма кредита (максимум  1 000 000 000 ), Процентная ставка, Срок выдачи :\n");

            creditamount.CheckFunction(1000000000, "\nСумма кредита, в грн     : ", "\nВы ввели некорректную  сумму\n");
            /*
            cheak = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\nСумма кредита, в грн     : ");
                creditamount = int.Parse(Console.ReadLine());
                if (creditamount <= 1000000000)
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
            while (cheak < 1);*/

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();


            Console.Write($"\nПроцентная ставка,  %    : ");
            interestrate = double.Parse(Console.ReadLine(), numberFormatInfo);

            Console.Write($"\nСрок выдачи кредита, мес.: ");
            issuedate = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkGray;

            if (setsubmenu == (int)SubMenuCreditM.Annuity)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n\nВы выбрали аннуитетный просчет кредита согласно ему :\n");

                rate = Math.Round((interestrate / 12f / 100f), 9);
                coefficient = Math.Round(((rate * Math.Pow((1 + rate), issuedate)) / ((Math.Pow((1 + rate), issuedate) - 1))), 10);

                //Платеж
                constantpartofpayment = coefficient * creditamount.givevalue;
                monthlypayment = coefficient * creditamount.givevalue;
                resulcredit = Math.Round((monthlypayment * issuedate), 2);
                overpayment = Math.Round((resulcredit - creditamount.givevalue), 2);
                Console.WriteLine("{0,31}{1,17}{2,12}{3,16}", "Платеж", "Проценты", "Тело", "Остаток");
                for (int month = 1; month <= issuedate; month++)
                {
                    //Проценты
                    monthlypaymentpercent = rate * creditamount.givevalue;
                    //Тело
                    monthlypayment = constantpartofpayment - monthlypaymentpercent;
                    //Остаток
                    creditamount.givevalue = Convert.ToInt32(creditamount.givevalue - monthlypayment);
                    Console.WriteLine("Платеж в {0,3} месяце:   {1}{2,15}{3,15}{4,15}", month, (Math.Round((constantpartofpayment), 2)), (Math.Round(monthlypaymentpercent, 2)), (Math.Round(monthlypayment, 2)), (Convert.ToInt32(creditamount.givevalue)));
                }

                Console.WriteLine($"\nСтавка по кредиту в месяц:        {rate}");
                Console.WriteLine($"Коэффициент аннуитета:            {coefficient}");
                Console.WriteLine($"Ежемесячный аннуитетный платеж:   {constantpartofpayment}, грн");
                Console.WriteLine($"Всего будет оплачено:             {resulcredit}, грн");
                Console.WriteLine($"Итоговая переплата по кредиту :   {overpayment}, грн");

            }
            else if (setsubmenu == (int)SubMenuCreditM.Usual)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                //Тело
                constantpartofpayment = creditamount.givevalue / issuedate;
                //переплата
                overpayment = Math.Round(creditamount.givevalue, 2);
                monthlypaymentpercent = monthlypayment = resulcredit = 0;
                Console.WriteLine("\nВы выбрали обычный просчет кредита согласно ему:\n");
                Console.WriteLine("{0,31}{1,17}{2,12}{3,16}", "Платеж", "Проценты", "Тело", "Остаток");
                for (int month = 1; month <= issuedate; month++)
                {
                    // Проценты
                    monthlypaymentpercent = Math.Round(((creditamount.givevalue * interestrate) / (100 * 12)), 2);
                    //Месячный платеж 
                    monthlypayment = Math.Round((constantpartofpayment + monthlypayment), 2);
                    //Остаток
                    creditamount.givevalue -= Math.Abs(Math.Round(constantpartofpayment, 5));
                    resulcredit += Math.Round((constantpartofpayment + monthlypaymentpercent), 2);
                    //Console.WriteLine($"Платеж в {month} месяце:   { Math.Round(monthlypaymentpercent, 2)}, грн");
                    Console.WriteLine("Платеж в {0,3} месяце:   {1}{2,15}{3,15}{4,15}", month, (Math.Round((monthlypaymentpercent + constantpartofpayment), 2)), (Math.Round(monthlypaymentpercent, 2)), (Math.Round(constantpartofpayment, 2)), (Math.Abs(Math.Round(creditamount.givevalue, 2))));

                }
                Console.WriteLine($"\nВсего будет оплачено:          {Math.Round(resulcredit, 2)}, грн");
                overpayment = resulcredit - overpayment;
                Console.WriteLine($"\nИтоговая переплата по кредиту: {Math.Round(overpayment, 2)}, грн");
            }
               
        }
    } 
}

