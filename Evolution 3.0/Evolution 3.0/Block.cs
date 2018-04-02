using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Evolution_3._0
{
    class Block
    {
        static int countBlock = 0;
        public int idBlock;

        public char status;
         int x;
         int y;
        public int age;
        

        static public Random rnd = new Random();

        public static int heightField = 125;
        public static int widthField = 200; 
        public static int countBlocks = widthField * heightField;
        public static int heightBlock = 5;
        public static int widthBlock = 5;
        public static int heightFood = heightBlock * 3;
        public static int widthFood = widthBlock * 3;
        public static int heightCell = heightBlock * 6;
        public static int widthCell = widthBlock * 6;

        static public bool[,] isEmpty = new bool[widthField, heightField];

        public Block()
        {
            age = 0;

            idBlock = countBlock;
            countBlock++;

            switch (rnd.Next(12))
            {
                case 0:
                    status = 'H';
                    break;
                case 1:
                    status = 'C';
                    break;
                case 2:
                    status = 'N';
                    break;
                case 3:
                    status = 'O';
                    break;
                case 4:
                    status = 'S';
                    break;
                case 5:
                    status = 'P';
                    break;
                default:
                    status = 'E';
                    break;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
