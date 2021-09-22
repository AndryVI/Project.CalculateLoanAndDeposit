using System;
using System.Collections.Generic;

namespace FinalProject
{
    /*
     * Система поддержки банковского работника.
     * Что она умеет делать?
     * 
     * Считать проценты по кредиту (Тело кредита, проценты, количество месяцев)
     * Считать проценты по депозиту(Тело депозита, проценты, количество месяцев)
             * Тут нужна еще предусмотреть дополнительное действие, для того, чтобы можно было задать возможность ежемесячного пополнения - увеличение тела 
             * Можно посмотреть формулы тут - https://exceltable.com/otchety/kalkulyator-rascheta-kredita 
     * Вклад - овернайт. 
             * Посчитать доход от вклада, размещенного на одну ночь. Формула Х = СуммаВклада *ГодовойПроцент/365 - КомиссияБанка
             * Сумма вклада, Годовой процент с клавиатуры, Комиссия банка - 100 дол.
     * Управление банковским хранилищем. 
             * В банке есть ячейки для хранения ценностей. Их у нас 140 штук.
             * Система работает следующим образом - [| 1 |] - Пустая ячейка. [*122*] - заполненная.
             * Данные хранятся в двух массивах - заполненные и пустые ячейки.
             * При вызове номера ячейки показывает ее содержимое
             * Полная - Тип, Цена содержимого; Типы содержимого - Деньги, Антиквариат, Ценные металлы, Документы, Другое. Записать в перечисление.
             * Пустая - Размер (1-5), цена аренды(зависит от цены)
             * Размер/Цена записаны в коллекцию 
             * Бронь ячейки по специальной команде в меню
             * Заняты ячейки - 22, 123, 27, 99, 5. Заполненные типы и цены по желанию 
     * Вывод ячеек на экран обязателен, таблица 14*10 (Ш*В)
        * Меню и функционал
                * Просчет кредита
                        * Аннуитетный
                        * Обычный
                * Просчет депозита
                        * Без пополнения - процент выше на 2%
                        * С пополнением
                * Овернайт
                * Ячейки
                        * Посмотреть все ячейки
                        * Проверить ячейку
                        * Добавить вещи в ячейку*/
    class Program
    {

        static void Main(string[] args)
        {
            string selection = "+";
            int selectstartorend = 0;

            ChoiceMenu MainMenu = new ChoiceMenu();

            Credit CalculateCredit = new Credit();
            Deposit CalculateDeposit = new Deposit();
            Overnight CalculateOvernight = new Overnight();
            Cells CalculateCells = new Cells();

            //Базовое заполнение ячеек
            //
            CalculateCells.StartFillingCell();


            Console.WriteLine("\nВас приветствует 'Система поддержки банковского работника'.\n\nВыберите операцию, из пунктов меню, которую хотите сделать:\n");
            do
            {
                if (selection == "+")
                {
                    MainMenu.StartMenu();
                    switch (MainMenu.setmenu)
                    {
                        case (int)Menu.CreditMiscalculation:
                            CalculateCredit.CreditAccount(MainMenu.setsubmenu);
                            break;
                        case (int)Menu.CalculatingTheDeposit:
                            CalculateDeposit.DepositAccount(MainMenu.setsubmenu);
                            break;
                        case (int)Menu.Overnight:
                            CalculateOvernight.OvernightAccount();
                            break;
                        case (int)Menu.Cells:
                            CalculateCells.CellsAccount(MainMenu.setsubmenu);
                            break;
                        default:
                            break;
                    }
                    //Рецикл программы. 
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"\nЖелаете ли Вы произвести еще операции?\nЕсли да то введите ‘+’ нет ‘-’\nВаш выбор:");
                    selection = Console.ReadLine();
                    Console.Write($"\n\n");
                }
                else if (selection == "-")
                {
                    selectstartorend = 1;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"\nВы ввели неверный символ  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            while (selectstartorend < 1);
            
        }        
    }
}
