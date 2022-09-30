namespace N_Body_Sim
{
    public partial class N_Body_Sim : Form
    {
        public float zoom = 1f;
        public N_Body_Sim()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(N_Body_Sim_Paint);
        }

        private void N_Body_Sim_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void N_Body_Sim_Paint(object? sender, PaintEventArgs e)
        {
            Graphics fg;
            Bitmap buffer = new Bitmap(Width, Height);
            fg = CreateGraphics();
            Graphics g = Graphics.FromImage(buffer);
            Pen pen = new Pen(Color.White, 2);
            PointF img = new PointF(0, 0);
            fg.Clear(BackColor);
            bool running = true;
            while (running)
            {
                g.Clear(BackColor);
                foreach(var Object in Calc.Objects)
                {
                    g.DrawEllipse(pen, Object.x / zoom + Width / 2, Object.y / zoom + Height / 2, 1, 1);
                }
                BackgroundImage = buffer;
                fg.DrawImage(buffer, img);
               
            
            }
        }

        private void N_Body_Sim_Load(object sender, EventArgs e)
        {

        }
        private void N_Body_Sim_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue > e.NewValue)
            {
                zoom = zoom / 2;
            }
            else            
            {
                zoom = zoom * 2;
            }
        }
    }
}