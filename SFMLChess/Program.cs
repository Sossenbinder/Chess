using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFMLChess.MainWindow;

namespace SFMLChess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mainWindowController = new MainWindowController();
            mainWindowController.RunMainWindow();
        }
    }
}
