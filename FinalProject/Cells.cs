using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject
{

    class Cells
    {
        public bool[] statuscell = new bool[140];
        public bool[] reservationcell = new bool[140];
        public int[] contentcell = new int[140];
        public int[] sizecell = new int[140];

        private int nambercell, checkcell, pricecell;
        public string visual, reservation, bookcell;

        //Базовое заполнение ячеек  
        public void StartFillingCell()
        {
            for (int cell = 0; cell < 140; cell++)
            {
                if (cell == 21 || cell == 122 || cell == 26 || cell == 98 || cell == 4)
                {
                    statuscell[cell] = true;
                    reservationcell[cell] = true;
                }
                else
                {
                    statuscell[cell] = false;
                    reservationcell[cell] = false;
                    contentcell[cell] = (int)CellContent.Empty;
                }

                if (cell >= 0 && cell <= 30)
                {
                    sizecell[cell] = (int)CellSize.Tiny;
    }
                else if (cell >= 31 && cell <= 50)
                {
                    sizecell[cell] = (int)CellSize.Small;
                }
                else if (cell >= 51 && cell <= 100)
                {
                    sizecell[cell] = (int)CellSize.Middle;
                }
                else if (cell >= 101 && cell <= 140)
                {
                    sizecell[cell] = (int)CellSize.Large;
                }
                contentcell[4] = (int)CellContent.Other;
                contentcell[21] = (int)CellContent.Documents;
                contentcell[26] = (int)CellContent.Preciousmetals;
                contentcell[98] = (int)CellContent.Money;
                contentcell[122] = (int)CellContent.Antiques;  
            }
        }

        //Бронирование ячейки    
        public void BookACell() 
        {
            bookcell = "-";
            checkcell = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nХотите забронировать ячейку?\nЕсли да то введите ‘+’ нет ‘-’\nВаш выбор:");
            bookcell = Console.ReadLine();
            Console.Write($"\n\n");
            if (bookcell == "+")
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"\nВведите номер ячейки которую хотите забронировать: ");
                    nambercell = (int.Parse(Console.ReadLine())) - 1;
                    if (reservationcell[nambercell] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"\nЯчейка с номераом: {nambercell+1}  - Занята \nВведите номер не занатой ячейки\n");
                    }
                    else
                    {
                        reservationcell[nambercell] = true;
                        checkcell = 1;
                    }
                }
                while (checkcell < 1);
            }

        }
        

        public void CellsAccount(int setsubmenu)
        {

            //Вывод ячеек  
            if (setsubmenu == (int)SubCells.ViewAllCells)
            {
                Console.WriteLine("{0,4} {1,13} {2,27}", "Номер ячейки", "Статус", "Бронь ");
                Console.WriteLine("---------------------------------------------------------------");
                for (int cell = 0; cell < 140; cell++)
                {
                    if (statuscell[cell] == true)
                    {
                        visual = "Заполненная";
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        visual = "Пустая   ";
                    }
                    if (reservationcell[cell] == true)
                    {
                        reservation = "Зарезервированная ";
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        reservation = "Резерв отсутствует";
                    }
                    Console.WriteLine("{0,5} {1,23} {2,30}", cell+1, visual, reservation);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("---------------------------------------------------------------");
                }
                BookACell();
            }



            //Проверить ячейку
            else if (setsubmenu == (int)SubCells.CheckCell)
            {
                pricecell = 0;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"\nВведите номер ячейки которую хотите проверить: ");
                nambercell = (int.Parse(Console.ReadLine()))-1;

               
                if (statuscell[nambercell] == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\n{0,5} {1,22} ", "Номер ячейки:", nambercell+1);
                    Console.Write("\n{0,5} {1,35} ", "Стасу:", "Ячейка занятая");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\n{0,5} {1,22} ", "Номер ячейки:", nambercell+1);
                    Console.Write("\n{0,5} {1,37} ", "Стасу:", "Ячейка свободная");
                }
                switch (sizecell[nambercell])
                {
                    case (int)CellSize.Tiny:
                        Console.Write("\n{0,5} {1,30} ", "Размер ячейки:", "Маленькая (100х50)");
                        pricecell += 300;
                        break;
                    case (int)CellSize.Small:
                        Console.Write("\n{0,5} {1,30} ", "Размер ячейки:", "Меньше среднего (200х70)");
                        pricecell += 500;
                        break;
                    case (int)CellSize.Middle:
                        Console.Write("\n{0,5} {1,30} ", "Размер ячейки:", "Средняя (350х100)");
                        pricecell += 800;
                        break;
                    case (int)CellSize.Large:
                        Console.Write("\n{0,5} {1,30} ", "Размер ячейки:", "Большая (500х500)");
                        pricecell += 1000;
                        break;
                    default:
                        break;
                }
                switch (contentcell[nambercell])
                {
                    case (int)CellContent.Empty:
                        Console.Write("\n{0,5} {1,20} ", "Типы содержимого:", "Пустая");
                        pricecell += 100;
                        break;
                    case (int)CellContent.Antiques:
                        Console.Write("\n{0,5} {1,20} ", "Типы содержимого:", "Антиквариат");
                        pricecell += 3000;
                        break;
                    case (int)CellContent.Documents:
                        Console.Write("\n{0,5} {1,20} ", "Типы содержимого:", "Документы");
                        pricecell += 2000;
                        break;
                    case (int)CellContent.Money:
                        Console.Write("\n{0,5} {1,20} ", "Типы содержимого:", "Деньги");
                        pricecell += 5000;
                        break;
                    case (int)CellContent.Other:
                        Console.Write("\n{0,5} {1,20} ", "Типы содержимого:", "Другое");
                        pricecell += 1000;
                        break;
                    case (int)CellContent.Preciousmetals:
                        Console.Write("\n{0,5} {1,25} ", "Типы содержимого:", "Ценные металлы");
                        pricecell += 4000;
                        break;
                    default:
                        break;
                }
                Console.Write("\n{0,5} {1,9},грн. ", "Стоимость ячейкив в мес.:", pricecell);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                BookACell();
            }




            //Добавить вещи в ячейку
            else if (setsubmenu == (int)SubCells.AddThingsToTheСell)
            {
                checkcell = 0;
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"\nВведите номер ячейки которую хотите добавить вещи: ");
                    nambercell = (int.Parse(Console.ReadLine())) - 1;
                    if (statuscell[nambercell] == true || reservationcell[nambercell] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"\nЯчейка с номераом: {nambercell+1}  - Занята \nВведите номер не занатой ячейки\n");
                    }
                    else
                    {
                        checkcell = 1;
                        statuscell[nambercell] = true;
                        reservationcell[nambercell] = true;
                    }
                }
                while (checkcell < 1);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"\nВведите из категории номер содержимого которое собираетесь хранить: \n");
                
                Console.Write("\n{0,5} {1,18} ", "Номер '0' типы содержимого:", "Пустая ячейка");
                Console.Write("\n{0,5} {1,14} ", "Номер '1' типы содержимого:", "Деньги");
                Console.Write("\n{0,5} {1,17} ", "Номер '2' типы содержимого:", "Антиквариат");
                Console.Write("\n{0,5} {1,18} ", "Номер '3' типы содержимого:", "Ценные металлы");
                Console.Write("\n{0,5} {1,16} ", "Номер '4' типы содержимого:", "Документы");
                Console.Write("\n{0,5} {1,15} ", "Номер '5' типы содержимого:", "Другое\n");
                

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\nНомер категории содержимого для хранения: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case (int)CellContent.Empty:
                        contentcell[nambercell] = (int)CellContent.Empty;
                        break;
                    case (int)CellContent.Antiques:
                        contentcell[nambercell] = (int)CellContent.Antiques;
                        break;
                    case (int)CellContent.Documents:
                        contentcell[nambercell] = (int)CellContent.Documents;
                        break;
                    case (int)CellContent.Money:
                        contentcell[nambercell] = (int)CellContent.Money;
                        break;
                    case (int)CellContent.Other:
                        contentcell[nambercell] = (int)CellContent.Other;
                        break;
                    case (int)CellContent.Preciousmetals:
                        contentcell[nambercell] = (int)CellContent.Preciousmetals;
                        break;
                    default:
                        break;
                }

            }
            //Вызов резервирования ячейки  
            if (setsubmenu == 335533)
            {
                BookACell();
            }

        }
    }
}
