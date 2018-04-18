using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// переделано месторасположение клеток, теперь зависит от установленнной длины и ширины, метод движения
//добавлен массив предыдущих состояний,чтобы не отрисовывалось все заново
namespace Evolution_3._0
{
    public partial class Form1 : Form
    {
        char[,] Status = new char[Block.widthField, Block.heightField];
        char[,] PrewStatus = new char[Block.widthField, Block.heightField];
        byte[,,] rgb = new byte[3, Block.heightField * Block.heightBlock, Block.widthField * Block.widthBlock];
        static public Random rnd = new Random();

        List<Cells> ListCells = new List<Cells>();
        List<Food> ListFoods = new List<Food>();
        List<Block> ListElements = new List<Block>();

        DataTable dt = new DataTable();
        PictureBox map = new PictureBox();
        public Form1()
        {
            InitializeComponent();

            dt.Columns.Add("Id");
            dt.Columns.Add("Group");
            dt.Columns.Add("HP");
            dt.Columns.Add("MaxHP");
            /////////////BITMAP MY GAME/////////////////////////////////////////////////////////////////////
            map.Size = new Size(Block.widthField * Block.widthBlock, Block.heightField * Block.heightBlock);
            map.Location = new Point(0, 0);
            this.Controls.Add(map);
        }

        private void btnGeneration_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    switch (rnd.Next(12))
                    {
                        case 0:
                            Status[x, y] = 'H';
                            break;
                        case 1:
                            Status[x, y] = 'C';
                            break;
                        case 2:
                            Status[x, y] = 'N';
                            break;
                        case 3:
                            Status[x, y] = 'O';
                            break;
                        case 4:
                            Status[x, y] = 'S';
                            break;
                        case 5:
                            Status[x, y] = 'P';
                            break;
                        default:
                            Status[x, y] = 'E';
                            break;
                    }
                }
            }
            PrintElement();
            DrowAll();
        }


        public void DrowAll()
        {
            Graphics g = CreateGraphics();
            Bitmap restored = Rgb.RgbToBitmapQ(rgb); //Rgb.RgbToBitmapNaive(rgb);
            map.Image = restored;
            g.Dispose();
        }

        void CreateOrganic(int minHydrogen, int minCarbon, int minNytrogen, int minOxygen, int xCell, int yCell)
        {
            int hydrogen = 0;
            int carbon = 0;
            int nytrogen = 0;
            int oxygen = 0;

            for (int y = yCell - 2; y <= yCell + 2; y++)
            {
                for (int x = xCell - 2; x <= xCell + 2; x++)
                {
                    switch (Status[x, y])
                    {
                        case 'H':
                            hydrogen++;
                            break;
                        case 'C':
                            carbon++;
                            break;
                        case 'N':
                            nytrogen++;
                            break;
                        case 'O':
                            oxygen++;
                            break;
                    }
                }
            }

            if (hydrogen > minHydrogen && carbon > minCarbon && oxygen > minOxygen && nytrogen > minHydrogen)
            {
                //create Cell
                Cells c = new Cells(carbon, xCell * Block.widthBlock, yCell * Block.heightBlock);
                ListCells.Add(c);

                for (int y = yCell - 2; y <= yCell + 2; y++)
                    for (int x = xCell - 2; x <= xCell + 2; x++)
                        Status[x, y] = 'E';

                DataRow r = dt.NewRow();
                r["Id"] = c.idCell;
                r["Group"] = c.group;
                r["MaxHP"] = c.maxHp;
                r["HP"] = c.hp;
                dt.Rows.Add(r);
                dataGridViewInfo.DataSource = dt;
            }

            else if (hydrogen > minHydrogen && carbon > minCarbon && oxygen > minOxygen && nytrogen >= minNytrogen)
            {
                //create Food
                Food f = new Food(xCell * Block.widthBlock, yCell * Block.heightBlock);
                ListFoods.Add(f);

                for (int y = yCell - 2; y <= yCell + 2; y++)
                    for (int x = xCell - 2; x <= xCell + 2; x++)
                        Status[x, y] = 'E';
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            /////////////////////////здесь заполнение массива карты
            for (int y = 2; y < Block.heightField - 2; y++)
            {
                for (int x = 2; x < Block.widthField - 2; x++)
                {
                    if (Status[x, y] == 'C')
                    {
                        CreateOrganic(2, 3, 2, 2, x, y);
                    }
                }
            }

            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    if (Status[x, y] != 'F')//(!char.IsDigit(Status[x, y]))
                    {
                        Status[x, y] = 'E';
                    }
                }
            }

            PrintElement();
            foreach (var c in ListCells)
                PrintCell(c);
            foreach (var f in ListFoods)
                PrintFood(f);
            DrowAll();

        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            DrowAll();
        }
        private static bool DeadElement(Block element) //предикат для работы с RemoveAll
        {
            if (element.age>400)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void timerTurn_Tick(object sender, EventArgs e)
        {
            foreach (var el in ListElements)
            {
                el.age++;
                if (el.age > 400)
                    Status[el.X, el.Y] = 'E';
            }

            GenerationElement();

            PrintElement();

            foreach (var f in ListFoods)
            {
                PrintFood(f);
            }

            foreach (var c in ListCells)
            {
                c.Moving(ListFoods);

                PrintCell(c);

                dt.AsEnumerable().Where(p => Convert.ToInt32(p["Id"]) == c.idCell).ToList().ForEach( //обновление таблицы
                    k =>
                    {
                        if (Convert.ToInt32(k["MaxHP"]) != c.maxHp)
                        {
                            k.BeginEdit();
                            k["MaxHP"] = c.maxHp;
                            k.EndEdit();
                        }
                    });
            }

            ListElements.RemoveAll(DeadElement);
            labelCells.Text = ListCells.Count.ToString();
            labelFoods.Text = ListFoods.Count.ToString();
            labelElements.Text = ListElements.Count.ToString();
        }


        void PrintCell(Cells c)
        {
            for (int y = 0; y < Block.heightCell; y++)
                for (int x = 0; x < Block.widthCell; x++)
                {
                    byte r = 0, g = 0, b = 0;
                    switch (c.group)
                    {
                        case 2:
                            r = 255; g = 228; b = 225;
                            break;
                        case 3:
                            r = 189; g = 183; b = 107;
                            break;
                        case 4:
                            r = 255; g = 255; b = 0;
                            break;
                        case 5:
                            r = 75; g = 0; b = 130;
                            break;
                        case 6:
                            r = 255; g = 0; b = 255;
                            break;
                        case 7:
                            r = 128; g = 0; b = 128;
                            break;

                        case 8:
                            r = 0; g = 0; b = 128;
                            break;
                        case 9:
                            r = 47; g = 79; b = 79;
                            break;

                        default:
                            r = 0; g = 255; b = 0;
                            break;
                    }
                    rgb[0, c.Y + y, c.X + x] = r;
                    rgb[1, c.Y + y, c.X + x] = g;
                    rgb[2, c.Y + y, c.X + x] = b;
                }
        }

        void PrintFood(Food f)
        {
            for (int y = 0; y < Block.heightFood; y++)
                for (int x = 0; x < Block.widthFood; x++)
                {
                    rgb[0, f.Y + y, f.X + x] = 255;
                    rgb[1, f.Y + y, f.X + x] = 0;
                    rgb[2, f.Y + y, f.X + x] = 0;
                }
        }

        void PrintElement()
        {
            byte r = 0, g = 0, b = 0;
            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    switch (Status[x, y])
                    {
                        case 'E':
                            r = 173; g = 216; b = 230;
                            break;
                        case 'C':
                            r = 255; g = 104; b = 0;
                            break;
                        case 'N':
                            r = 0; g = 184; b = 217;
                            break;
                        case 'H':
                            r = 138; g = 127; b = 128;
                            break;
                        case 'O':
                            r = 173; g = 216; b = 230;
                            break;
                        case 'S':
                            r = 143; g = 254; b = 9;
                            break;
                        case 'P':
                            r = 10; g = 10; b = 10;
                            break;
                    }

                    for (int h = 0; h < Block.heightBlock; h++)
                        for (int w = 0; w < Block.widthBlock; w++)
                        {
                            rgb[0, Block.heightBlock * y + h, Block.widthBlock * x + w] = r;
                            rgb[1, Block.heightBlock * y + h, Block.widthBlock * x + w] = g;
                            rgb[2, Block.heightBlock * y + h, Block.widthBlock * x + w] = b;
                        }
                }
            }
        }

        void GenerationElement()
        {
            int x;
            int y;
            for (int i = 0; i < rnd.Next(1, 6); i++)
            {
                x = rnd.Next(2,Block.widthField-2);
                y = rnd.Next(2,Block.heightField-2);

                if (Status[x, y] == 'E')
                {
                    Block element = new Block(6,x,y);
                    ListElements.Add(element);
                    Status[x, y] = element.status;
                    CreateOrganic(0, 0, 0, 1, x, y);
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerDraw.Enabled = true;
            timerTurn.Enabled = true;
        }
    }
}
