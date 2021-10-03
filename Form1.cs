using System;
using System.Drawing;
using System.Windows.Forms;

//розробила базову логіку гри, дала можливість гравцю ставити стіни і ходити - Довгань Валерія


namespace Quoridor
{
    public partial class Form1 : Form //Все, що відбувається в формі
    {
        bool gored { get; set; }  //стан гравця при ході по клітинках
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
                        }

                    };
                    x.MouseLeave += (a_sender, a_args) =>  //активується коли миша сповзає зі стіни
                    {
                        if (x.BackColor != Color.LightSlateGray)  //перевіряємо чи не є стіна постійною
                            x.BackColor = Color.LightSkyBlue;  //повертаємоо початковий колір (поки що кращого виходу з ситуації не знайдено)
                    };
                }

                if ((string)x.Tag == "Red Dot") //прописуємо дії для гравця
                {
                    x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                        gored = true;  //змінюємо стан гравця для здійснення ходу (зараз може ходити)
                }

                if (gored == true && (string)x.Tag == "Cell")  //прописуємо дії для гральних клітинок
                {
                    x.MouseClick += (a_sender, a_args) => //активується при кліку миші
                    {
                        RedDot.Top = x.Top + 4;  //переміщуємо гравця (точку) на місце поточної обраної клатинки
                        RedDot.Left = x.Left + 4; //-||-
                        gored = false;  //змінюємо стан гравця для здійснення ходу (зараз не може ходити) PS: може але пофікшу
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
}
