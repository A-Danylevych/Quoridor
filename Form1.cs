using System;
using System.Drawing;
using System.Windows.Forms;

//розробила базову логіку гри, дала можливість гравцю ставити стіни і ходити - Довгань Валерія


namespace Quoridor
{

    public partial class Form1 : Form //Все, що відбувається в формі
    {
        int top, left, wallsgreen = 10, wallsred = 10;

        bool gored = false, gogreen = false;  //стан гравця при ході по клітинках
        bool isGameOver { get; set; }  //стан початку гри
        public Form1()  //запускає дії в формі
        {
            InitializeComponent();
            resetGame();
        }

        private void mainGameTimer(object sender, EventArgs e)  //запускає всі процеси в грі (логічні і не дуже)
        {

            foreach (Control x in this.Controls) //починаємо працювати з кожним елементом форми
            {

                if ((string)x.Tag == "Wall")  //прописуємо дії для стін
                {
                    x.MouseClick += (a_sender, a_args) =>  //активується при кліку миші, ставимо стіни
                    {
                        x.BackColor = Color.LightSlateGray;  //змінюємо колір на постійний
                        x.BringToFront();  //переносимо на перед
                    };
                    x.MouseHover += (a_sender, a_args) =>  //активується при наведенні миші на стіну
                    {
                        if (x.BackColor != Color.LightSlateGray)  //перевіряємо чи не є стіна постійною
                        {
                            x.BackColor = Color.LightSteelBlue;  //задаємо колір стіни, яку можливо поставити
                            x.BringToFront();  //переносимо на передній план
                            wallsred -= 1;
                        }

                    };
                    x.MouseLeave += (a_sender, a_args) =>  //активується коли миша сповзає зі стіни
                    {
                        if (x.BackColor != Color.LightSlateGray)  //перевіряємо чи не є стіна постійною
                            x.BackColor = Color.LightSkyBlue;  //повертаємоо початковий колір (поки що кращого виходу з ситуації не знайдено)       
                    };
                }

                if ((string)x.Tag == "Red Dot")
                    x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                     gored = true;

                if ((string)x.Tag == "Green Dot")
                    x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                     gogreen = true;

                if ((string)x.Tag == "Cell")  //прописуємо дії для гральних клітинок
                {

                    if (gored == true)
                        x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                        {
                            Draw Red = new Draw();
                            Red.Dot(x.Top, x.Left, RedDot.Top, RedDot.Left);

                            RedDot.Top = Red.Dot(x.Top, x.Left, RedDot.Top, RedDot.Left)[0];
                            RedDot.Left = Red.Dot(x.Top, x.Left, RedDot.Top, RedDot.Left)[1];

                            top = RedDot.Top;
                            left = RedDot.Left;

                            gored = false;
                        };

                    if (gogreen == true)
                        x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                        {
                            Draw Green = new Draw();
                            Green.Dot(x.Top, x.Left, GreenDot.Top, GreenDot.Left);

                            GreenDot.Top = Green.Dot(x.Top, x.Left, GreenDot.Top, GreenDot.Left)[0];
                            GreenDot.Left = Green.Dot(x.Top, x.Left, GreenDot.Top, GreenDot.Left)[1];

                            //top = GreenDot.Top;
                            // left = GreenDot.Left;

                            //gored = false;
                        };

                };

            }

        }
    
 
        private void resetGame() //дії, які відбуваються при перезапуску гри
        {
            isGameOver = false;  //вказуємо що гра триває

            gameTimer.Start();  //починається відлік гри, всі дії можуть відбуватися
        }
    }

    public class Draw  //змінює стан клітинок
    {
        public int[]  Dot (int TopCell, int LeftCell, int top, int left)
        {
            top = TopCell + 4;  //переміщуємо гравця (точку) на місце поточної обраної клатинки
            left = LeftCell + 4; //-||-
            int[] coordinates = new int[] {top, left };
            return coordinates;
        }
    }

    class Moove  //зчитує рухи
    {
        // public

    }

}
