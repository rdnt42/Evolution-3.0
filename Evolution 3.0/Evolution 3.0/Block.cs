using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Evolution_3._0
{
    /// <summary>
    /// Класс для генерации блоков элементов и основых характеристик всех объектов
    /// </summary>
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
        public static int heightBlock = 5;
        public static int widthBlock = 5;
        public static int heightMap = heightBlock * heightField;
        public static int widthMap = widthBlock * widthField;
        public static int countBlocks = widthField * heightField;

        public static int heightFood = heightBlock * 4;
        public static int widthFood = widthBlock * 4;
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

        public Block(int setRnd, int setX, int setY)
        {
            age = 0;
            X = setX;
            Y = setY;
            idBlock = countBlock;
            countBlock++;

            switch (rnd.Next(setRnd))
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
        public static void CreateMap(string size, int pix)
        {
            if (size == "1600 x 900")
            {
                widthMap = 1200;
                heightMap = 700;
            }
            else if (size == "1366 x 768")
            {
                widthMap = 1000;
                heightMap = 625;
                if (pix == 4)
                    heightMap = 624;
            }
            widthBlock = pix;
            heightBlock = pix;
            widthField = widthMap / widthBlock;
            heightField = heightMap / heightBlock;
            countBlocks = widthField * heightField;
            heightFood = heightBlock * 4;
            widthFood = widthBlock * 4;
            heightCell = heightBlock * 6;
            widthCell = widthBlock * 6;
        }
        public void NewStatus()
        {
            switch (rnd.Next(6))
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
    }
}
