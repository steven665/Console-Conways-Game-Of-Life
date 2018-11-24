using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConwaysGameOfLife
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowWidth = 150;
            Console.WindowHeight = 40;
            Console.CursorVisible = false;
            Game g = new Game();
            while (true)
            {
                g.Run();
            }
        }
    }
}
