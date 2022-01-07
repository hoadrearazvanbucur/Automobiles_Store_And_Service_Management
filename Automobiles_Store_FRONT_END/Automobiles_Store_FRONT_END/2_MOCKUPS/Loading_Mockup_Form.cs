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
            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - 570/2;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - 320/2;
            load();
        }

        public void load()
        {
            this.timer= new Timer();
            this.timer.Interval = 35;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();

            Image im = Image.FromFile(Application.StartupPath + @"\Images\logo.png");
            PctLogoLoading.BackgroundImage = im;
        }

        public void timer_Tick(object sender, EventArgs e)
        {    
            LblLoadingModuleLoading.Text = $"Loading modules...  {PBLoading.Value = this.value}%";
            if (this.value == 100)
            {
                this.timer.Stop();
                Login_Mockup_Form l = new Login_Mockup_Form();
                this.Hide();
                l.Show();
            }
            this.value += 1;
        }
    }
}
