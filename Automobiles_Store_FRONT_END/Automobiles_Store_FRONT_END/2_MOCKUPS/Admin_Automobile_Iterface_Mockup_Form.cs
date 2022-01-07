using Automobiles_Store_BACK_END.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;
using Automobiles_Store_BACK_END.Models;

namespace Automobiles_Store_FRONT_END._2_MOCKUPS
{
    public partial class Admin_Automobile_Iterface_Mockup_Form : Form
    {
        private Control_User c1;
        private Control_Automobile c2;
        private Control_Order c3;
        private Form login;
        public int currentId{get; set;}

        public Admin_Automobile_Iterface_Mockup_Form(Control_User c1, Control_Automobile c2, Control_Order c3,Form login)
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

            load();
        }

        private void BtnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void load()
        {
            BunifuDataGridView gridView = new BunifuDataGridView();
            tabel(c2, gridView);
            this.PanelAdminAutomobile.Controls.Add(gridView);
        }


        public void tabel(Control_Automobile control, BunifuDataGridView gridView)
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
            c1.HeaderText = "Brand"; c1.Name = "brand";
            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Model"; c2.Name = "model";
            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Color"; c3.Name = "color";
            DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
            c4.HeaderText = "Kilometres"; c4.Name = "kilometres";
            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Price"; c5.Name = "price";
            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Amount"; c6.Name = "amount";
            gridView.Columns.AddRange(c0,c1,c2,c3,c4,c5,c6);
            
            for(int i=0;i<control.Lista.dimensiune();i++)
                gridView.Rows.Add(control.Lista.obtine(i).Data.Id, control.Lista.obtine(i).Data.Brand, control.Lista.obtine(i).Data.Model, control.Lista.obtine(i).Data.Color, control.Lista.obtine(i).Data.Km, control.Lista.obtine(i).Data.Price, control.Lista.obtine(i).Data.Amount);
        }

        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Panel panel = null;
            BunifuDataGridView gridView = null;
            foreach(Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView")
                        gridView = control as BunifuDataGridView;
            int k = int.Parse(gridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            tb1.Text = c2.Lista.obtine(c2.positionId(k)).Data.Brand;
            tb2.Text = c2.Lista.obtine(c2.positionId(k)).Data.Model;
            tb3.Text = c2.Lista.obtine(c2.positionId(k)).Data.Color;
            tb4.Text = c2.Lista.obtine(c2.positionId(k)).Data.Km.ToString();
            tb5.Text = c2.Lista.obtine(c2.positionId(k)).Data.Price.ToString();
            tb6.Text = c2.Lista.obtine(c2.positionId(k)).Data.Amount.ToString();
            this.currentId = k;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Account_Iterface_Mockup_Form a = new Admin_Account_Iterface_Mockup_Form(c1,c2,c3,login);
            a.Show();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Mockup_Form l = new Login_Mockup_Form();
            l.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TileButton4_Click(object sender, EventArgs e)
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            c2.adding($"{c2.generationId()}|{tb4.Text}|{tb6.Text}|{tb5.Text}|{tb1.Text}|{tb2.Text}|{tb3.Text}");
            c2.save();
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
            c2.removal(new Automobile($"{this.currentId}|{tb4.Text}|{tb6.Text}|{tb5.Text}|{tb1.Text}|{tb2.Text}|{tb3.Text}"));
            c2.save();
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
            c2.changeBrand(this.currentId, tb1.Text);
            c2.changeModel(this.currentId, tb2.Text);
            c2.changeColor(this.currentId, tb3.Text);
            c2.changeKm(this.currentId, int.Parse(tb4.Text));
            c2.changePrice(this.currentId, int.Parse(tb5.Text));
            c2.changeAmount(this.currentId, int.Parse(tb6.Text));
            c2.save();
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
            Control_Automobile c = new Control_Automobile();
            for(int i=0;i<c2.Lista.dimensiune();i++)
            {
                if (c2.Lista.obtine(i).Data.Brand == tbs.Text)
                    c.adding($"{c2.Lista.obtine(i).Data.Id}|{c2.Lista.obtine(i).Data.Km}|{c2.Lista.obtine(i).Data.Amount}|{c2.Lista.obtine(i).Data.Price}|{c2.Lista.obtine(i).Data.Brand}|{c2.Lista.obtine(i).Data.Model}|{c2.Lista.obtine(i).Data.Color}");
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
