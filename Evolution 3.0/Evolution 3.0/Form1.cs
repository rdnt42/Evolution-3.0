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
        DataTable dt = new DataTable();
        PictureBox map = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    Status[x, y] = 'E';
                }
            }
            dt.Columns.Add("Id");
            dt.Columns.Add("Group");
            dt.Columns.Add("HP");
            dt.Columns.Add("MaxHP");
            /////////////BITMAP MY GAME/////////////////////////////////////////////////////////////////////
            map.Size = new Size(Block.widthField * Block.widthBlock, Block.heightField * Block.heightBlock);
            map.Location = new Point(0, 0);
            this.Controls.Add(map);
            /*for (int y = 0; y < Block.heightField * Block.heightBlock-50; y++)
                for (int x = 0; x < Block.widthField * Block.widthBlock-50; x++)
                {
                    rgb[0, y, x] = 255;
                    rgb[1, y, x] = 255;
                    rgb[2,y,x] = 255;
                }*/
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
                    //Block b = new Block();     // нам не нужны объекты, т.к. элементы можно задавать через статусы
                    // b.x = x * Block.widthBlock;
                    // b.y = y * Block.heightBlock;

                }
            }
            timerDraw.Enabled = true;
            timerTurn.Enabled = true;
        }


        public void DrowAll()
        {


            // SolidBrush myBrush = new SolidBrush(Color.Black);
            //Pen myPen = new Pen(Color.Black, 2);
            Graphics g = CreateGraphics();


            //byte[,,] rgb = Rgb.GenerateBytePicture(width, height);
            // byte[,,] rgb = Rgb.Test(width, height);
            //Rgb.setX++;
            //Rgb.setY++;

            Bitmap restored = Rgb.RgbToBitmapQ(rgb); //Rgb.RgbToBitmapNaive(rgb);
            map.Image = restored;

            /* foreach (var c in ListCells)
              {
                  if (c.X != c.prewX || c.Y != c.prewY)
                  {
                      myBrush = new SolidBrush(Color.LightBlue);
                      g.FillEllipse(myBrush, new Rectangle(c.prewX, c.prewY, Block.widthCell, Block.heightCell ));
                      switch (c.group)
                      {
                          case 3:
                              myBrush = new SolidBrush(Color.Green);
                              break;
                          case 4:
                              myBrush = new SolidBrush(Color.CornflowerBlue);
                              break;
                          case 5:
                              myBrush = new SolidBrush(Color.BlueViolet);
                              break;
                          case 6:
                              myBrush = new SolidBrush(Color.Indigo);
                              break;
                          default:
                              myBrush = new SolidBrush(Color.BlanchedAlmond);
                              break;
                      }
                      g.FillEllipse(myBrush, new Rectangle(c.X, c.Y, Block.widthCell, Block.heightCell));
                      c.prewX = c.X;
                      c.prewY = c.Y;
                  }
              }

             foreach (var f in ListFoods)
              {
                  if (f.isAlive)
                  {
                      myBrush = new SolidBrush(Color.Red);
                      g.FillRectangle(myBrush, new Rectangle(f.X, f.Y, Block.widthFood, Block.heightFood));
                  }

                  else
                  {
                      myBrush = new SolidBrush(Color.LightBlue);
                      g.FillRectangle(myBrush, new Rectangle(f.X, f.Y, Block.widthFood, Block.heightFood));

                  }
              }

              for (int y = 0; y < Block.heightField; y++)
              {
                  for (int x = 0; x < Block.widthField; x++)
                  {
                      if (Status[x, y] != PrewStatus[x, y])
                      {
                          switch (Status[x, y])
                          {
                              case 'E':
                                  myBrush = new SolidBrush(Color.LightBlue);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;
                              case 'C':
                                  myBrush = new SolidBrush(Color.Yellow);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;
                              case 'N':
                                  myBrush = new SolidBrush(Color.Gray);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;
                              case 'H':
                                  myBrush = new SolidBrush(Color.Red);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;
                              case 'O':
                                  myBrush = new SolidBrush(Color.Orange);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;
                              case 'S':
                                  myBrush = new SolidBrush(Color.Black);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;
                              case 'P':
                                  myBrush = new SolidBrush(Color.Blue);
                                  g.FillRectangle(myBrush, new Rectangle(x * Block.widthBlock, y * Block.heightBlock, Block.widthBlock, Block.heightBlock));
                                  break;

                          }
                          PrewStatus[x, y] = Status[x, y];
                      }
                  }
              }*/

            // myPen.Dispose();
            // myBrush.Dispose();
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            /////////////////////////здесь заполнение массива карты
            for (int y = 2; y < Block.heightField - 4; y++)
            {
                for (int x = 2; x < Block.widthField - 4; x++)
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

        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            DrowAll();
            // Invalidate();
        }
        private static bool DeadFood(Food foods) //предикат для работы с RemoveAll
        {
            if (!foods.isAlive)
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
            PrintElement();
            // ListFoods.RemoveAll(DeadFood);
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




            labelCells.Text = ListCells.Count.ToString();
            labelFoods.Text = ListFoods.Count.ToString();
        }


        void PrintCell(Cells c)
        {
            for (int y = 0; y < Block.heightCell; y++)
                for (int x = 0; x < Block.widthCell; x++)
                {
                    rgb[0, c.Y + y, c.X + x] = 75;
                    rgb[1, c.Y + y, c.X + x] = 0;
                    rgb[2, c.Y + y, c.X + x] = 130;
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
            byte r=0, g=0, b=0;
            for (int y = 0; y < Block.heightField; y++)
            {
                for (int x = 0; x < Block.widthField; x++)
                {
                    switch (Status[x, y])
                    {
                        case 'E':
                            r = 173;
                            g = 216;
                            b = 230;
                            break;
                        case 'C':
                            r = 255;
                            g = 104;
                            b = 0;
                            break;
                        case 'N':
                            r = 0;
                            g = 184;
                            b = 217;
                            break;
                        case 'H':
                            r = 138;
                            g = 127;
                            b = 128;
                            break;
                        case 'O':
                            r = 173;
                            g = 216;
                            b = 230;
                            break;
                        case 'S':
                            r = 143;
                            g = 254;
                            b = 9;
                            break;
                        case 'P':
                            r = 10;
                            g = 10;
                            b = 10;
                            break;

                    }
                    for (int h = 0; h<Block.heightBlock;h++)
                        for (int w = 0; w<Block.widthBlock;w++)
                        {
                            rgb[0, Block.heightBlock * y +h, Block.widthBlock * x+w] = r;
                            rgb[1, Block.heightBlock * y + h, Block.widthBlock * x + w] = g;
                            rgb[2, Block.heightBlock * y + h, Block.widthBlock * x + w] = b;
                        }

                }
            }
        }
    }
}
