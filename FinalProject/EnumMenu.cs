using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /*
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
                    * Добавить вещи в ячейку
    */
    public enum Menu { CreditMiscalculation = 1, CalculatingTheDeposit = 2, Overnight = 3, Cells = 4 }
    public enum SubMenuCreditM { Annuity = 1, Usual = 2 }
    public enum SubMenuDepositC { WithoutReplenishment = 1, WithReplenishment = 2 }
    public enum SubCells { ViewAllCells = 1, CheckCell = 2, AddThingsToTheСell = 3 }
    public enum CellSize { Tiny = 1, Small = 2, Middle = 3, Large = 4, }
    public enum CellContent { Empty = 0, Money = 1, Antiques = 2, Preciousmetals = 3, Documents = 4, Other = 5 }


}
