using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution_3._0
{
    class Cells : Block
    {
        static int countCell = 0;
        public int idCell;

        public int group;
        public int hp;
        public int maxHp;
        public int range;
        int stepLength;
        int x;
        int y;

        public Cells(int carbon, int xCell, int yCell)
        {
            idCell = countCell;
            countCell++;

            X = xCell;
            Y = yCell;

            group = carbon;
            range = 100;
            stepLength = 10;
            maxHp = 50 + 100 * carbon;
            hp = maxHp;
        }

        public new int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < Block.widthField - Block.widthCell / Block.widthBlock && value >= 0)
                    x = value;
            }
        }

        public new int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < Block.heightField - Block.heightCell/Block.heightBlock && value >= 0)
                    y = value;
            }
        }

        public void Moving(char[,] array)
        {
            // int moveX = rnd.Next(0, 2);
            // moveX = moveX == 0 ? -1 : 1;
            int moveX = rnd.Next(-1, 2);
            int moveY = rnd.Next(-1, 2);
            // int moveY = rnd.Next(0, 2);
            // moveY = moveY == 0 ? -1 : 1;


            for (int y = Y ; y <= Y + Block.heightCell / Block.heightBlock; y++)
            {
                for (int x = X ; x <= X + Block.widthCell / Block.widthBlock; x++)
                {
                    array[x, y] = 'E';
                }
            }
            X += moveX;
            Y += moveY;
            for (int y = Y ; y <= Y + Block.heightCell / Block.heightBlock; y++)
            {
                for (int x = X ; x <= X + Block.widthCell / Block.widthBlock; x++)
                {
                    array[x, y] = Convert.ToChar(group.ToString());
                }
            }

        }

    }
}
