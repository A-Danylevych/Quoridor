using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Quoridor.Controller;

//розробила базову логіку гри, дала можливість гравцю ставити стіни і ходити - Довгань Валерія


namespace Quoridor
{

    public partial class Form1 : Form //Все, що відбувається в формі
    {
        Controller.Controller Controller { get; set; }

        bool isGameOver { get; set; }  //стан початку гри
        public Form1()  //запускає дії в формі
        {
            Controller = new Controller.Controller();
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
                            Controller.SetWall(2,3);
                            x.BackColor = Color.LightSlateGray;  //змінюємо колір на постійний
                            x.BringToFront();  //переносимо на перед
                        };


                    x.MouseHover += (a_sender, a_args) =>  //активується при наведенні миші на стіну
                    {
                        if (x.BackColor != Color.LightSlateGray)  //перевіряємо чи не є стіна постійною
                        {
                            x.BackColor = Color.LightSteelBlue;  //задаємо колір стіни, яку можливо поставити
                            x.BringToFront();  //переносимо на передній план
                        }

                    };
                    x.MouseLeave += (a_sender, a_args) =>  //активується коли миша сповзає зі стіни
                    {
                        if (x.BackColor != Color.LightSlateGray)  //перевіряємо чи не є стіна постійною
                        {
                            x.BackColor = Color.LightSkyBlue;  //повертаємоо початковий колір (поки що кращого виходу з ситуації не знайдено)
                            x.SendToBack();
                        }
                    };
                }

                if ((string)x.Tag == "Cell")  //прописуємо дії для гральних клітинок
                {
   
                            x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                            {
                                int rtop = x.Top + 4;
                                int rleft = x.Left + 4;

                                RedDot.Top = rtop;
                                RedDot.Left = rleft;

                                RedDot.BringToFront();

                            };


                            x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                            {
                                int gtop = x.Top + 4;
                                int gleft = x.Left + 4;

                                GreenDot.Top = gtop;
                                GreenDot.Left = gleft;

                                GreenDot.BringToFront();

                            };
                    }
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
        public bool DrawWall { get; set; } = false;

        public bool DrawDot { get; set; } = false;

        public bool GoGreen { get; set; } = false;

        public bool GoRed { get; set; } = false;
    }

    class Moove  //зчитує рухи
    {
        // public

    }

}
