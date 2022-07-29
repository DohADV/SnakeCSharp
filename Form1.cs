namespace Snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox tabla = new PictureBox();
        PictureBox Snake = new PictureBox();
        PictureBox Mancare = new PictureBox();
        PictureBox[] Coada = new PictureBox[1001];
        int dx = 1, dy = 0, cl = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            tabla.Width = tabla.Height = 500;
            tabla.BackColor = Color.Green;
            tabla.Location = new Point(30, 30);
            this.Location = new Point(50, 50);
            this.Width = this.Height = 600;
            this.Controls.Add(tabla);
            Snake.Width = Snake.Height = 18;
            Snake.Location = new Point(100, 100);
            Snake.BackColor = Color.White;
            tabla.Controls.Add(Snake);
            Mancare.Width= Mancare.Height = 18;
            Mancare.Location = new Point(300, 400);
            Mancare.BackColor = Color.Red;
            tabla.Controls.Add(Mancare);
            timer1.Start();
        }
        private void Form1_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                dx = -1;
                dy = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                dx = 1;
                dy = 0;
            }
            if (e.KeyCode == Keys.Up)
            {
                dx = 0;
                dy = -1;
            }
            if (e.KeyCode == Keys.Down)
            {
                dx = 0;
                dy = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = cl; i >= 2; --i)
            {
                Coada[i].Location =  Coada[i - 1].Location;
            }
            if(cl>0) Coada[1].Location = Snake.Location;
            Snake.Location = new Point(Snake.Location.X + dx * 20, Snake.Location.Y + dy * 20);
            for (int i = 1; i <= cl; ++i)
            {
                if (Snake.Location == Coada[i].Location) timer1.Stop();
            }
            if (Snake.Location == Mancare.Location)
            {
                Random random = new Random();
                int x1 = random.Next(24) * 20;
                int y1 = random.Next(24) * 20;
                Mancare.Location = new Point(x1, y1);
                Coada[++cl] = new PictureBox();
                Coada[cl].BackColor = Color.White;
                Coada[cl].Location = Snake.Location;
                Coada[cl].Width = Coada[cl].Height = 18;
                tabla.Controls.Add(Coada[cl]);
            }
            int x = Snake.Location.X;
            int y = Snake.Location.Y;
            if (x >= 500)
            {
                x = 0;
            }
            else if (x < 0)
            {
                x = 480;
            }
            if (y > 500)
            {
                y = 0;
            }
            else if (y < 0)
            {
                y = 480;
            }
            Snake.Location = new Point(x, y);
        }
    }
}