﻿using System;
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
        Game Game;

        public Form1()  //запускає дії в формі
        {
            Controller = new Controller.Controller();
            InitializeComponent();
            Dot = RedDot;
            Game = Game.GetInstance(Controller, this);
            resetGame();
        }

        bool isGameOver;

        private void keyisdown(object sender, KeyEventArgs e)
        {

        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isGameOver == true)
                resetGame();
        }

        int leftWallsForRed = 10, leftWallsForGreen = 10, rtop, rleft, gtop, gleft;

        private void mainGameTimer(object sender, EventArgs e)  //запускає всі процеси в грі (логічні і не дуже)
        {
            //label1.Text = "Залишилось стін: " + leftWallsForRed;
            //label2.Text = "Залишилось стін: " + leftWallsForGreen;

            if (GreenDot.Top > 625)
            {
                gameOver("Вы проиграли!");
                isGameOver = true;
            }


            if (RedDot.Top < 30)
            {
                gameOver("Вы выиграли!");
                isGameOver = true;
            }

            foreach (Control x in this.Controls) //починаємо працювати з кожним елементом форми
            {

                if ((string)x.Tag == "Wall")  //прописуємо дії для стін
                {
                    if (leftWallsForRed > 0 && red ==  true || leftWallsForGreen >0 && red == false)
                        x.MouseClick += (a_sender, a_args) =>  //активується при кліку миші, ставимо стіни
                        {
                            Controller.SetAction(Model.Action.PlaceWall);
                            //Controller.SetWall(x.Top, x.Left);
                            x.BackColor = Color.LightSlateGray;  //змінюємо колір на постійний
                            x.BringToFront();  //переносимо на перед
                            if (red == true)
                            {
                                leftWallsForRed --;
                                label1.Text = "Залишилось стін: " + leftWallsForRed;
                                red = false;
                            }
                            else
                            {
                                leftWallsForGreen --;
                                label2.Text = "Залишилось стін: " + leftWallsForGreen;
                                red = true;
                            }

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
                    //Controller.SetAction(Model.Action.MakeMove);

                    x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                    {
                        if (red == true)
                        {
                            rtop = x.Top + 4;
                            rleft = x.Left + 4;
                            RedDot.Top = rtop;
                            RedDot.Left = rleft;
                            //Controller.SetCell(rtop, rleft);
                        }
                        else
                        {
                            gtop = x.Top + 4;
                            gleft = x.Left + 4;
                            GreenDot.Top = gtop;
                            GreenDot.Left = gleft;
                            //Controller.SetCell(gtop, gleft);
                        }

                        Game.Update();
                    };

                }

            }

        }

        private void resetGame() //дії, які відбуваються при перезапуску гри
        {

            gameTimer.Start();  //починається відлік гри, всі дії можуть відбуватися

            label1.Text = "Залишилось стін: 10";
            label2.Text = "Залишилось стін: 10";

            isGameOver = false;
        }

        private void gameOver(string message)
        {
            isGameOver = true;

            gameTimer.Stop();

            label1.Left = 250;

            label1.Text = "     " + message;

            label2.Text = null;
        }


        public bool HorV(int top, int left)
        {
            bool horizont = false; //за замовчуванням вертикальна
            foreach (var v in WallsList())  //if true то горизонтальна
            {
                if (v.Height == 25 && v.Top == top && v.Left == left)
                    horizont = true;
            }
            return horizont;
        }

        public void RenderEnding()
        {
            throw new NotImplementedException();
        }

        public void RenderPlayer(int top, int left)
        {

                Dot.Top = top;
                Dot.Left = left;
            
            Dot.BringToFront();
        }

        public void RenderWall(int top, int left)
        {
            RenderWall(top, left, Color.LightSlateGray);
        }

        public List<PictureBox> WallsList()
        {
            List<PictureBox> Pic = new List<PictureBox>();
            Pic.Add(pictureBox1);
            Pic.Add(pictureBox2);
            Pic.Add(pictureBox3);
            Pic.Add(pictureBox4);
            Pic.Add(pictureBox5);
            Pic.Add(pictureBox6);
            Pic.Add(pictureBox7);
            Pic.Add(pictureBox8);
            Pic.Add(pictureBox9);
            Pic.Add(pictureBox10);
            Pic.Add(pictureBox11);
            Pic.Add(pictureBox12);
            Pic.Add(pictureBox13);
            Pic.Add(pictureBox14);
            Pic.Add(pictureBox15);
            Pic.Add(pictureBox16);
            Pic.Add(pictureBox17);
            Pic.Add(pictureBox18);
            Pic.Add(pictureBox19);
            Pic.Add(pictureBox20);
            Pic.Add(pictureBox21);
            Pic.Add(pictureBox22);
            Pic.Add(pictureBox23);
            Pic.Add(pictureBox24);
            Pic.Add(pictureBox25);
            Pic.Add(pictureBox26);
            Pic.Add(pictureBox27);
            Pic.Add(pictureBox28);
            Pic.Add(pictureBox29);
            Pic.Add(pictureBox30);
            Pic.Add(pictureBox31);
            Pic.Add(pictureBox32);
            Pic.Add(pictureBox33);
            Pic.Add(pictureBox34);
            Pic.Add(pictureBox35);
            Pic.Add(pictureBox36);
            Pic.Add(pictureBox37);
            Pic.Add(pictureBox38);
            Pic.Add(pictureBox39);
            Pic.Add(pictureBox40);
            Pic.Add(pictureBox41);
            Pic.Add(pictureBox42);
            Pic.Add(pictureBox43);
            Pic.Add(pictureBox44);
            Pic.Add(pictureBox45);
            Pic.Add(pictureBox46);
            Pic.Add(pictureBox47);
            Pic.Add(pictureBox48);
            Pic.Add(pictureBox49);
            Pic.Add(pictureBox50);
            Pic.Add(pictureBox51);
            Pic.Add(pictureBox52);
            Pic.Add(pictureBox53);
            Pic.Add(pictureBox54);
            Pic.Add(pictureBox55);
            Pic.Add(pictureBox56);
            Pic.Add(pictureBox57);
            Pic.Add(pictureBox58);
            Pic.Add(pictureBox59);
            Pic.Add(pictureBox60);
            Pic.Add(pictureBox61);
            Pic.Add(pictureBox62);
            Pic.Add(pictureBox63);
            Pic.Add(pictureBox64);
            Pic.Add(pictureBox65);
            Pic.Add(pictureBox66);
            Pic.Add(pictureBox67);
            Pic.Add(pictureBox68);
            Pic.Add(pictureBox69);
            Pic.Add(pictureBox70);
            Pic.Add(pictureBox71);
            Pic.Add(pictureBox72);
            Pic.Add(pictureBox73);
            Pic.Add(pictureBox74);
            Pic.Add(pictureBox75);
            Pic.Add(pictureBox76);
            Pic.Add(pictureBox77);
            Pic.Add(pictureBox78);
            Pic.Add(pictureBox79);
            Pic.Add(pictureBox80);
            Pic.Add(pictureBox81);
            Pic.Add(pictureBox82);
            Pic.Add(pictureBox83);
            Pic.Add(pictureBox84);
            Pic.Add(pictureBox85);
            Pic.Add(pictureBox86);
            Pic.Add(pictureBox87);
            Pic.Add(pictureBox88);
            Pic.Add(pictureBox89);
            Pic.Add(pictureBox90);
            Pic.Add(pictureBox91);
            Pic.Add(pictureBox92);
            Pic.Add(pictureBox93);
            Pic.Add(pictureBox94);
            Pic.Add(pictureBox95);
            Pic.Add(pictureBox96);
            Pic.Add(pictureBox97);
            Pic.Add(pictureBox98);
            Pic.Add(pictureBox99);
            Pic.Add(pictureBox100);
            Pic.Add(pictureBox101);
            Pic.Add(pictureBox102);
            Pic.Add(pictureBox103);
            Pic.Add(pictureBox104);
            Pic.Add(pictureBox105);
            Pic.Add(pictureBox106);
            Pic.Add(pictureBox107);
            Pic.Add(pictureBox108);
            Pic.Add(pictureBox109);
            Pic.Add(pictureBox110);
            Pic.Add(pictureBox111);
            Pic.Add(pictureBox112);
            Pic.Add(pictureBox113);
            Pic.Add(pictureBox114);
            Pic.Add(pictureBox115);
            Pic.Add(pictureBox116);
            Pic.Add(pictureBox117);
            Pic.Add(pictureBox118);
            Pic.Add(pictureBox119);
            Pic.Add(pictureBox120);
            Pic.Add(pictureBox121);
            Pic.Add(pictureBox122);
            Pic.Add(pictureBox123);
            Pic.Add(pictureBox124);
            Pic.Add(pictureBox125);
            Pic.Add(pictureBox126);
            Pic.Add(pictureBox127);
            Pic.Add(pictureBox128);
            Pic.Add(pictureBox129);
            Pic.Add(pictureBox130);
            Pic.Add(pictureBox131);
            Pic.Add(pictureBox132);
            Pic.Add(pictureBox133);
            Pic.Add(pictureBox134);
            Pic.Add(pictureBox135);
            Pic.Add(pictureBox136);
            Pic.Add(pictureBox137);
            Pic.Add(pictureBox138);
            Pic.Add(pictureBox139);
            Pic.Add(pictureBox140);
            Pic.Add(pictureBox141);
            Pic.Add(pictureBox142);
            Pic.Add(pictureBox143);
            Pic.Add(pictureBox144);
            Pic.Add(pictureBox145);
            Pic.Add(pictureBox146);
            Pic.Add(pictureBox147);
            Pic.Add(pictureBox148);
            Pic.Add(pictureBox149);
            Pic.Add(pictureBox150);
            Pic.Add(pictureBox151);
            Pic.Add(pictureBox152);
            Pic.Add(pictureBox153);
            Pic.Add(pictureBox154);
            Pic.Add(pictureBox155);
            Pic.Add(pictureBox156);
            Pic.Add(pictureBox157);
            Pic.Add(pictureBox158);
            Pic.Add(pictureBox159);
            Pic.Add(pictureBox160);
            Pic.Add(pictureBox161);
            Pic.Add(pictureBox162);
            Pic.Add(pictureBox163);
            Pic.Add(pictureBox164);
            Pic.Add(pictureBox165);
            Pic.Add(pictureBox166);
            Pic.Add(pictureBox167);
            Pic.Add(pictureBox168);
            Pic.Add(pictureBox169);
            Pic.Add(pictureBox170);
            Pic.Add(pictureBox171);
            Pic.Add(pictureBox172);
            Pic.Add(pictureBox173);
            Pic.Add(pictureBox174);
            Pic.Add(pictureBox175);
            Pic.Add(pictureBox176);
            Pic.Add(pictureBox177);
            Pic.Add(pictureBox178);
            Pic.Add(pictureBox179);
            Pic.Add(pictureBox180);
            Pic.Add(pictureBox181);
            Pic.Add(pictureBox182);
            Pic.Add(pictureBox183);
            Pic.Add(pictureBox184);
            Pic.Add(pictureBox185);
            Pic.Add(pictureBox186);
            Pic.Add(pictureBox187);
            Pic.Add(pictureBox188);
            Pic.Add(pictureBox189);
            Pic.Add(pictureBox190);
            Pic.Add(pictureBox191);
            Pic.Add(pictureBox192);
            Pic.Add(pictureBox193);
            Pic.Add(pictureBox194);
            Pic.Add(pictureBox195);
            Pic.Add(pictureBox196);
            Pic.Add(pictureBox197);
            Pic.Add(pictureBox198);
            Pic.Add(pictureBox199);
            Pic.Add(pictureBox200);
            Pic.Add(pictureBox201);
            Pic.Add(pictureBox202);
            Pic.Add(pictureBox203);
            Pic.Add(pictureBox204);
            Pic.Add(pictureBox205);
            Pic.Add(pictureBox206);
            Pic.Add(pictureBox207);
            Pic.Add(pictureBox208);
            Pic.Add(pictureBox209);
            Pic.Add(pictureBox210);
            Pic.Add(pictureBox211);
            Pic.Add(pictureBox212);
            Pic.Add(pictureBox213);
            Pic.Add(pictureBox214);
            Pic.Add(pictureBox215);
            Pic.Add(pictureBox216);
            Pic.Add(pictureBox217);
            Pic.Add(pictureBox218);
            Pic.Add(pictureBox219);
            Pic.Add(pictureBox220);
            Pic.Add(pictureBox221);
            Pic.Add(pictureBox222);
            Pic.Add(pictureBox223);
            Pic.Add(pictureBox224);
            Pic.Add(pictureBox225);
            Pic.Add(pictureBox226);
            Pic.Add(pictureBox227);
            Pic.Add(pictureBox228);
            Pic.Add(pictureBox229);



            List<PictureBox> Walls = new List<PictureBox>();
            foreach (var p in Pic)
            {
                if (p.Tag == "Wall")
                    Walls.Add(p);
            }

            return Walls;
        }

        private void RenderWall(int top, int left, Color color)
        {
            foreach (var v in WallsList())
                if (v.Top == top && v.Left == left)
                {
                    v.BackColor = color;
                    v.BringToFront();
                }
        }

        public void RenderRemainingWalls(int TopCount, int BottomCount)
        {
            throw new NotImplementedException();
        }

        bool red = true;

        public void ChangePlayer()
        {
            if (Dot == GreenDot)
            {
                red = true;
                Dot = RedDot;
            }
            else
            {
                red = false;
                Dot = GreenDot;
            }
        }
    }

}
