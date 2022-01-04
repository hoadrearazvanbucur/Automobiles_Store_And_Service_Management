using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Automobiles_Store_FRONT_END._2_MOCKUPS
{
    public partial class Login_Mockup_Form : Form
    {
        public Login_Mockup_Form()
        {
            InitializeComponent();
            guna2TileButton1.Cursor = Cursors.Hand;
        }


        private void Login_Mockup_Form_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.Text = guna2ComboBox1.Items[0].ToString();
            guna2ComboBox1.TextChanged += new EventHandler(test);
            Image im1 = Image.FromFile(Application.StartupPath + @"\Images\logo.png");
            Image im2 = Image.FromFile(Application.StartupPath + @"\Images\userLogin.png");
            Image im3 = Image.FromFile(Application.StartupPath + @"\Images\lockedLogin.png");
            pictureBox1.BackgroundImage = im1;
            pictureBox3.BackgroundImage = im3;
            pictureBox4.BackgroundImage = im2;
        }

        public void test(object sender, EventArgs e)
        {
            if ((sender as Guna2ComboBox).Text == "Admin" || (sender as Guna2ComboBox).Text == "User")
            {
                guna2ComboBox1.Items.Remove("Choose");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
