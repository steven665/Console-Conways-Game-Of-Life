using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace ConwaysGameOfLife
{
    class Game
    {
        int height;
        int width;
        Cell[,] cells;
        bool[,] nextStates;
        Random rnd = new Random();
        int maxX;
        int maxY;

        public Game()
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth;
            cells = new Cell[height, width];
            nextStates = new bool[height, width];


            //initalizing cells array
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = new Cell(new Point(j, i));
                    int random = rnd.Next(1, 9);
                    if (random == 1)
                        cells[i, j].alive = true;
                    cells[i, j].Draw();
                }
            }
            //initalizing next state array
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    nextStates[i, j] = cells[i, j].alive;

            //!!!This is how we should reference all so edges automatically wrap.!!!!
            maxX = width;
            //int testWidth = 239 % maxX;
            maxY = height;
            //int testHeight = 59 % maxY;

        }
        public void Run()
        {

            while (true)
            {

                //Loop for checking what next state will be.
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int count = 0;
                        //up down left right
                        Point point = new Point(i - 1 % maxY, j);
                        if (cells[Cell.Mod(i - 1, maxY), j].alive) { count++; }
                        if (cells[Cell.Mod(i + 1, maxY), j].alive) { count++; }
                        if (cells[i, Cell.Mod(j - 1, maxX)].alive) { count++; }
                        if (cells[i, Cell.Mod(j + 1, maxX)].alive) { count++; }
                        //up left up right
                        if (cells[Cell.Mod(i - 1, maxY), Cell.Mod(j - 1, maxX)].alive) { count++; }
                        if (cells[Cell.Mod(i - 1, maxY), Cell.Mod(j + 1, maxX)].alive) { count++; }
                        //down left down right
                        if (cells[Cell.Mod(i + 1, maxY), Cell.Mod(j - 1, maxX)].alive) { count++; }
                        if (cells[Cell.Mod(i + 1, maxY), Cell.Mod(j + 1, maxX)].alive) { count++; }
                        CheckSetAlive(count, cells[i, j].alive, i, j);

                    }
                }
                //Loop for applying next state
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        cells[i, j].alive = nextStates[i, j];
                        cells[i, j].Draw();
                    }
                }

            }
        }

        private void CheckSetAlive(int count, bool b, int i, int j)
        {
            if (count > 8)
                throw new Exception("Count was greater than 8!!!");
            if (b == true)
            {
                if (count < 2)
                    nextStates[i, j] = false;
                if (count == 2 || count == 3)
                    nextStates[i, j] = true;
                if (count > 3)
                    nextStates[i, j] = false;
            }
            if (b == false)
            {
                if (count == 3)
                    nextStates[i, j] = true;
            }

        }
    }
}
