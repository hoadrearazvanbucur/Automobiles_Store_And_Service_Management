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
using Bunifu.UI.WinForms;
using Automobiles_Store_BACK_END.Controllers;
using Automobiles_Store_BACK_END.Models;

namespace Automobiles_Store_FRONT_END._2_MOCKUPS
{
    public partial class Admin_Account_Iterface_Mockup_Form : Form
    {
        private Control_User c1;
        private Control_Automobile c2;
        private Control_Order c3;
        private Form login;
        public int currentId { get; set; }


        public Admin_Account_Iterface_Mockup_Form(Control_User c1, Control_Automobile c2, Control_Order c3,Form login)
        {
            InitializeComponent();
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.login = login;

            Image im1 = Image.FromFile(Application.StartupPath + @"\Images\logo.png");
            Image im2 = Image.FromFile(Application.StartupPath + @"\Images\user.png");
            Image im3 = Image.FromFile(Application.StartupPath + @"\Images\car.png");
            Image im4 = Image.FromFile(Application.StartupPath + @"\Images\search.png");
            Image im5 = Image.FromFile(Application.StartupPath + @"\Images\refresh.png");
            PctLogoLogin.BackgroundImage = im1;
            PctUsernameLogin.BackgroundImage = im2;
            PctPasswordLogin.BackgroundImage = im3;
            pictureBox1.BackgroundImage = im4;
            pictureBox2.BackgroundImage = im5;

            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - 635;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - 370;

            cb1.Text = cb1.Items[0].ToString();
            cb1.TextChanged += new EventHandler(CBUserLogin_TextChanged);

            load();
        }

        public void CBUserLogin_TextChanged(object sender, EventArgs e)
        {
            if ((sender as Guna2ComboBox).Text == "True" || (sender as Guna2ComboBox).Text == "False")
                cb1.Items.Remove("Choose");
        }

        private void BtnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void load()
        {
            BunifuDataGridView gridView = new BunifuDataGridView();
            tabel(c1, gridView);
            this.PanelAdminAutomobile.Controls.Add(gridView);
        }


        public void tabel(Control_User control, BunifuDataGridView gridView)
        {
            gridView.CellClick += gridView_CellClick;

            gridView.Name = "gridView";
            gridView.Size = new Size(1150, 250);
            gridView.Location = new Point(50, 450);

            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridView.AllowUserToResizeRows = false;
            gridView.AutoSize = false;
            gridView.ReadOnly = true;

            gridView.Theme = BunifuDataGridView.PresetThemes.Crimson;
            gridView.BackgroundColor = SystemColors.ControlLightLight;
            DataGridViewTextBoxColumn c0 = new DataGridViewTextBoxColumn();
            c0.HeaderText = "Id"; c0.Name = "Id";
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Name"; c1.Name = "nume";
            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Password"; c2.Name = "password";
            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Admin"; c3.Name = "Admin";

            gridView.Columns.AddRange(c0, c1, c2, c3);

            for (int i = 0; i < control.Lista.dimensiune(); i++)
                gridView.Rows.Add(control.Lista.obtine(i).Data.Id, control.Lista.obtine(i).Data.Name, control.Lista.obtine(i).Data.Password, (control.Lista.obtine(i).Data.Admin == 1 ? "True" : "False"));
        }

        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            int k = int.Parse(gridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            tb1.Text = c1.Lista.obtine(c1.positionId(k)).Data.Name;
            tb2.Text = c1.Lista.obtine(c1.positionId(k)).Data.Password;
            cb1.Text = c1.Lista.obtine(c1.positionId(k)).Data.Admin == 1 ? "True" : "False";

            this.currentId = k;
        }





        private void LblTitleLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Automobile_Iterface_Mockup_Form a = new Admin_Automobile_Iterface_Mockup_Form(c1, c2, c3, login);
            a.Show();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Mockup_Form l = new Login_Mockup_Form();
            l.Show();
        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            tb1.Text = "";
            tb2.Text = "";
            cb1.Items.Clear();
            cb1.Items.Add("Choose");
            cb1.Items.Add("True");
            cb1.Items.Add("False");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            int index = cb1.Text.Equals("True") == true ? 1 : 0;
            c1.adding($"{c1.generationId()}|{index}|{tb1.Text}|{tb2.Text}");
            c1.save();
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            panel.Controls.Remove(gridView);
            load();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            int index = cb1.Text.Equals("True") == true ? 1 : 0;
            c1.removal(new User($"{this.currentId}|{index}|{tb1.Text}|{tb2.Text}"));
            c1.save();
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            panel.Controls.Remove(gridView);
            load();
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            int index = cb1.Text.Equals("True") == true ? 1 : 0;
            c1.changeAdmin(this.currentId, index);
            c1.changeName(this.currentId, tb1.Text);
            c1.changePassword(this.currentId, tb2.Text);
            c1.save();
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            panel.Controls.Remove(gridView);
            load();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            panel.Controls.Remove(gridView);
            load();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Control_User c = new Control_User();
            for (int i = 0; i < c1.Lista.dimensiune(); i++)
            {
                if (c1.Lista.obtine(i).Data.Name == tbs.Text)
                    c.adding($"{c1.Lista.obtine(i).Data.Id}|{c1.Lista.obtine(i).Data.Admin}|{c1.Lista.obtine(i).Data.Name}|{c1.Lista.obtine(i).Data.Password}");
            }
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            panel.Controls.Remove(gridView);

            BunifuDataGridView gridView1 = new BunifuDataGridView();
            tabel(c, gridView1);
            this.PanelAdminAutomobile.Controls.Add(gridView1);
        }
    }
}
