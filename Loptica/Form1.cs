namespace Loptica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Lopta lopta;
        Random r = new Random();
        int brPogodaka = 0;
        int brPokusaja = 0;
        bool pogodjena = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
            int x = r.Next(15, ClientRectangle.Width - 15);
            int y = r.Next(15, ClientRectangle.Height - 15);

            lopta = new Lopta(new Point(x, y), 15, Color.Red);
            lopta.Boji(g);
            brPokusaja++;
            pogodjena = false;
            Text = brPogodaka + " od " + brPokusaja;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!pogodjena)
            {
                if (lopta.SadrziTacku(new Point(e.X, e.Y)))
                {
                    pogodjena = true;
                    brPogodaka++;
                    Text = brPogodaka + " od " + brPokusaja;
                }
            }
        }
    }
}