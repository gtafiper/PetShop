using System;
using System.Collections.Generic;
using System.Text;
using Petshop.Core.Entity;

namespace Petshop.Consol
{
    public interface IPrinter
    {
        List<MenuItem> ShowMenuItems();

        void GetTheMenuItem(int inputNumber);

        int AskForNumericInputMenu(List<MenuItem> menuItems);

        
    }
}
