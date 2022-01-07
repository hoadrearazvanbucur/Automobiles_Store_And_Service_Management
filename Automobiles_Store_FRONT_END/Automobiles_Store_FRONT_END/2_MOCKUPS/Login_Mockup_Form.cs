using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automobiles_Store_BACK_END.Controllers;
using Guna.UI2.WinForms;

namespace Automobiles_Store_FRONT_END._2_MOCKUPS
{
    public partial class Login_Mockup_Form : Form
    {
        public Login_Mockup_Form()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - 770/2;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - 420/2;
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TBUsernameLogin.Text != "" && TBPasswordLogin.Text != "" && CBUserLogin.Text != "Choose the user")
            {
                Control_User c1 = new Control_User();
                Control_Automobile c2 = new Control_Automobile();
                Control_Order c3 = new Control_Order();
                c1.load();
                c2.load();
                c3.load();
                int ok = 0;
                if (c1.login_exist(TBUsernameLogin.Text, TBPasswordLogin.Text) == true && c1.getAdmin(TBUsernameLogin.Text, TBPasswordLogin.Text) == 1 && CBUserLogin.Text == "Administrator")
                {
                    Admin_Automobile_Iterface_Mockup_Form a = new Admin_Automobile_Iterface_Mockup_Form(c1,c2,c3,this);
                    this.Hide();
                    a.Show();
                    ok = 1;
                }
                if (c1.login_exist(TBUsernameLogin.Text, TBPasswordLogin.Text) == true && c1.getAdmin(TBUsernameLogin.Text, TBPasswordLogin.Text) == 0 && CBUserLogin.Text == "Customer")
                {
                    User_Interface_Mockup_Form u = new User_Interface_Mockup_Form(c1,c2,c3,this,c1.getId(TBUsernameLogin.Text,TBPasswordLogin.Text));
                    this.Hide();
                    u.Show();
                    ok = 1;
                }
                if(ok==0)
                    MessageBox.Show("This account doesn't exist");
            }
            else
                MessageBox.Show("Do not leave loose boxes!");
        }
    }
}
