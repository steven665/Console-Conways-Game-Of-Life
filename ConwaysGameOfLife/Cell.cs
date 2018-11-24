using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConwaysGameOfLife
{
    class Cell
    {
        public bool alive;
        public char rep;
        public Point pos;
        public Cell(Point p)
        {
            pos = p;
            alive = false;
            rep = ' ';
        }
        public static int Mod(int i, int m)
        {
            if (i < 0)
            {
                return m - Math.Abs(i);
            }

            return i % m;


        }
        public void Draw()
        {
            if (alive)
            {
                rep = 'x';
            }
            else
            {
                rep = ' ';
            }
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write(rep);
        }

    }
}
