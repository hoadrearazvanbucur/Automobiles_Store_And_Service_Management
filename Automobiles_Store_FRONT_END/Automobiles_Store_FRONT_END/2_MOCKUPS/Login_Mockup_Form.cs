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
            load();
        }
        public void load()
        {
            CBUserLogin.Text = CBUserLogin.Items[0].ToString();
            CBUserLogin.TextChanged += new EventHandler(CBUserLogin_TextChanged);

            Image im1 = Image.FromFile(Application.StartupPath + @"\Images\logo.png");
            Image im2 = Image.FromFile(Application.StartupPath + @"\Images\user.png");
            Image im3 = Image.FromFile(Application.StartupPath + @"\Images\locked.png");
            PctLogoLogin.BackgroundImage = im1;
            PctUsernameLogin.BackgroundImage = im2;
            PctPasswordLogin.BackgroundImage = im3;
        }

        public void CBUserLogin_TextChanged(object sender, EventArgs e)
        {
            if ((sender as Guna2ComboBox).Text == "Administrator" || (sender as Guna2ComboBox).Text == "Customer")
                CBUserLogin.Items.Remove("Choose the user");
        }

        private void BtnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
