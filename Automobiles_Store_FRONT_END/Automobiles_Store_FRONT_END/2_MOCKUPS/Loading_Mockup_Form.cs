using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automobiles_Store_FRONT_END._2_MOCKUPS
{
    public partial class Loading_Mockup_Form : Form
    {
        public Timer timer;
        private int value;

        public Loading_Mockup_Form()
        {
            InitializeComponent();
            Image im = Image.FromFile(Application.StartupPath + @"\Images\logo.png");
            pictureBox1.BackgroundImage = im;
            load();
        }

        public void load()
        {
            this.timer= new Timer();
            this.timer.Interval = 40;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value = this.value;
            label1.Text = $"Loading Modules ...   {this.value}%";
            if (this.value == 100)
            {
                this.timer.Stop();
                this.Hide();
                Login_Mockup_Form f = new Login_Mockup_Form();
                f.Show();
            }
            this.value += 1;
        }
    }
}
