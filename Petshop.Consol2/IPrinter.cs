using System.Collections.Generic;
using Petshop.Core.Entity2;

namespace Petshop.Consol2
{
    public interface IPrinter
    {
        List<MenuItem> ShowMenuItems();

        void GetTheMenuItem(int inputNumber);

        int AskForNumericInputMenu(List<MenuItem> menuItems);

        
    }
}
