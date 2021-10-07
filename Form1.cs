using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Quoridor.Controller;
using Model;
using Color = System.Drawing.Color;

//розробила базову логіку гри, дала можливість гравцю ставити стіни і ходити - Довгань Валерія


namespace Quoridor
{

    public partial class Form1 : Form, IViewer //Все, що відбувається в формі
    {
        Controller.Controller Controller { get; set; }
        PictureBox Dot { get; set; }
        public Form1()  //запускає дії в формі
        {
            Controller = new Controller.Controller();
            InitializeComponent();
            Dot = RedDot;
            resetGame();
        }

        private void mainGameTimer(object sender, EventArgs e)  //запускає всі процеси в грі (логічні і не дуже)
        {
       
            foreach (Control x in this.Controls) //починаємо працювати з кожним елементом форми
            {

                if ((string)x.Tag == "Wall")  //прописуємо дії для стін
                {
                    Controller.SetAction(Model.Action.PlaceWall);

                    x.MouseClick += (a_sender, a_args) =>  //активується при кліку миші, ставимо стіни
                    {
                        Controller.SetWall(x.Top,x.Left);
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
                    Controller.SetAction(Model.Action.MakeMove);

                        x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                        {
                            int top = x.Top + 4;
                            int left = x.Left + 4;
                            Controller.SetCell(top, left);
                            RenderPlayer(top, left);
                        };
                }
            }
        }
 
        private void resetGame() //дії, які відбуваються при перезапуску гри
        {

            gameTimer.Start();  //починається відлік гри, всі дії можуть відбуватися
        }

        public void RenderEnding()
        {
            throw new NotImplementedException();
        }

        public void RenderPlayer(int top, int left)
        {
            Dot.Top = top;
            Dot.Left = left;
            GreenDot.BringToFront();
        }

        public void RenderWall(int top, int left)
        {
            throw new NotImplementedException();
        }

        public void RenderRemainingWalls(int TopCount, int BottomCount)
        {
            throw new NotImplementedException();
        }

        public void ChangePlayer()
        {
            if(Dot == GreenDot)
            {
                Dot = RedDot;
            }
            else
            {
                Dot = GreenDot;
            }
        }
    }

}
