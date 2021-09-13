using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class ChoiceMenu
    {
        private string[] arraymenu = new string[4] { "Просчет кредита", "Просчет депозита", "Овернайт", "Ячейки" };
        private string[] sarraymenucredit = new string[2] { "Аннуитетный", "Обычный" };
        private string[] sarraymenudeposit = new string[2] { "Без пополнения - процент выше на 2%", "С пополнением" };
        private string[] sarraymenucell = new string[3] { "Посмотреть все ячейки", "Проверить ячейку", "Добавить вещи в ячейку" };
        public int setmenu, setsubmenu;

        public void StartMenu()
        {
            int stepprog = 0;
            //Вывод основного меню  
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int stepmenu = 0; stepmenu < arraymenu.RowsCount(); stepmenu++)
            {
                Console.WriteLine($" № {stepmenu + 1} : {arraymenu[stepmenu]} ");
            }

            //Проверка правильности ввода номера меню
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\nНомер операции: ");
                setmenu = Convert.ToInt32(Console.ReadLine());

                Console.Write($"\n");
                if (setmenu >= 1 && setmenu <= arraymenu.RowsCount())
                {
                    switch (setmenu)
                    {
                        case (int)Menu.CreditMiscalculation:
                            //Console.Write($"\nВиберети тип кредита: ");
                            SSubMenu(sarraymenucredit);
                            break;
                        case (int)Menu.CalculatingTheDeposit:
                            SSubMenu(sarraymenudeposit);
                            break;
                        case (int)Menu.Overnight:

                            break;
                        case (int)Menu.Cells:
                            SSubMenu(sarraymenucell);
                            break;
                        default:
                            break;
                    }
                    stepprog = 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Вы ввели неверный номер операции   \nВведите каретный номер операции\n ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (stepprog < 1);
        }

        //Проверка правильности ввода подменю
        void SSubMenu(string[] array)
        {
            int stepprog = 0;
            for (int stepsmenu = 0; stepsmenu < array.RowsCount(); stepsmenu++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" № {stepsmenu + 1} : {array[stepsmenu]} ");
            }
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\nТип подоперации: ");
                setsubmenu = Convert.ToInt32(Console.ReadLine());
                Console.Write($"\n");
                if (setsubmenu >= 1 && setsubmenu <= array.RowsCount())
                {
                    stepprog = 1;
                }
                else if (setsubmenu == 335533 && setmenu == (int)Menu.Cells)
                {
                    stepprog = 1;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"\nВы ввели неверный номер подоперации   \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (stepprog < 1);
        }

    }
}
