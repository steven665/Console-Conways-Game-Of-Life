using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 75;
            Console.WindowHeight = 35;
            Console.CursorVisible = false;
            Game g = new Game();
            while (true)
            {
                g.Run();
            }
        }
    }
}
