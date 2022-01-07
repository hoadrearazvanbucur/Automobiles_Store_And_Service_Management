using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automobiles_Store_BACK_END.Models;
using Automobiles_Store_BACK_END.Controllers;
using Bunifu.UI.WinForms;
using Guna.UI2.WinForms;

namespace Automobiles_Store_FRONT_END._2_MOCKUPS
{
    public partial class User_Interface_Mockup_Form : Form
    {
        private Control_User c1;
        private Control_Automobile c2;
        private Control_Order c3;
        private Control_Automobile new3;
        private Form login;
        public int currentId { get; set; }
        public int currentAutomobileId { get; set; }



        public User_Interface_Mockup_Form(Control_User c1, Control_Automobile c2, Control_Order c3, Form login, int currentId)
        {
            InitializeComponent();
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
            this.login = login;
            this.new3 = new Control_Automobile();
            this.currentId = currentId;

            this.StartPosition = FormStartPosition.Manual;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - 635;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - 370;

            label4.Text = "Customer name: " + c1.Lista.obtine(c1.positionId(this.currentId)).Data.Name;
            guna2TextBox5.ReadOnly = true;
            guna2TextBox1.ReadOnly = true;

            Image im1 = Image.FromFile(Application.StartupPath + @"\Images\logo.png");
            PctLogoLogin.BackgroundImage = im1;
            BunifuDataGridView gridView1 = new BunifuDataGridView();
            BunifuDataGridView gridView2 = new BunifuDataGridView();
            BunifuDataGridView gridView3 = new BunifuDataGridView();
            tabel1(c3, gridView1);
            tabel2(c2, gridView2);
            tabel3(new3, gridView3);
            guna2Panel1.Controls.Add(gridView1);
            guna2Panel4.Controls.Add(gridView2);
            guna2Panel3.Controls.Add(gridView3);
        }


        public void tabel1(Control_Order control, BunifuDataGridView gridView)
        {
            gridView.CellClick += gridView_CellClick1;

            gridView.Name = "gridView1";
            gridView.Size = new Size(580, 300);
            gridView.Location = new Point(15, 13);


            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridView.AllowUserToResizeRows = false;
            gridView.AutoSize = false;
            gridView.ReadOnly = true;

            gridView.Theme = BunifuDataGridView.PresetThemes.Crimson;
            gridView.BackgroundColor = SystemColors.ControlLightLight;
            DataGridViewTextBoxColumn c0 = new DataGridViewTextBoxColumn();
            c0.HeaderText = "Id"; c0.Name = "Id";
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Nr. Products"; c1.Name = "brand";
            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Price"; c5.Name = "price";
            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Nr. Quantity"; c6.Name = "amount";
            gridView.Columns.AddRange(c0, c1, c6, c5);
            for (int i = 0; i < control.getOrderList(this.currentId).dimensiune(); i++)
            {
                int quantity = 0;
                double price = 0;
                for (int j = 0; j < control.getOrderList(this.currentId).obtine(i).Data.OrderSize; j++)
                {
                    price += c2.Lista.obtine(c2.positionId(control.getOrderList(this.currentId).obtine(i).Data.Automobile_ID[j])).Data.Price * control.getOrderList(this.currentId).obtine(i).Data.Amounts[j];
                    quantity += control.getOrderList(this.currentId).obtine(i).Data.Amounts[j];
                }
                gridView.Rows.Add(control.Lista.obtine(i).Data.Id, control.Lista.obtine(i).Data.OrderSize, quantity, price);
            }
        }
        private void gridView_CellClick1(object sender, DataGridViewCellEventArgs e)
        {
            Panel panel = null;
            Panel panel2 = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "guna2Panel1")
                        panel2 = control as Guna2Panel;
            foreach (Control control in panel2.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView1")
                        gridView = control as BunifuDataGridView;
            MessageBox.Show(gridView.Rows[e.RowIndex].Cells[0].Value.ToString());
        }


        public void tabel2(Control_Automobile control, BunifuDataGridView gridView)
        {
            gridView.CellClick += gridView_CellClick2;

            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridView.AllowUserToResizeRows = false;
            gridView.AutoSize = false;
            gridView.ReadOnly = true;
            gridView.Name = "gridView2";

            gridView.Size = new Size(580, 300);
            gridView.Location = new Point(15, 13);

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
            c4.HeaderText = "Km"; c4.Name = "kilometres";
            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Price"; c5.Name = "price";
            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Amount"; c6.Name = "amount";
            gridView.Columns.AddRange(c0, c1, c2, c3, c4, c5, c6);

            for (int i = 0; i < control.Lista.dimensiune(); i++)
                gridView.Rows.Add(control.Lista.obtine(i).Data.Id, control.Lista.obtine(i).Data.Brand, control.Lista.obtine(i).Data.Model, control.Lista.obtine(i).Data.Color, control.Lista.obtine(i).Data.Km, control.Lista.obtine(i).Data.Price, control.Lista.obtine(i).Data.Amount);
        }
        private void gridView_CellClick2(object sender, DataGridViewCellEventArgs e)
        {
            Panel panel = null;
            Panel panel2 = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "guna2Panel4")
                        panel2 = control as Guna2Panel;
            foreach (Control control in panel2.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView2")
                        gridView = control as BunifuDataGridView;
            this.currentAutomobileId = int.Parse(gridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            guna2TextBox1.Text = c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Brand;
            guna2TextBox5.Text = c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Price.ToString();
            guna2TextBox2.Text = "1";
        }


        public void tabel3(Control_Automobile control, BunifuDataGridView gridView)
        {

            gridView.Name = "gridView3";
            gridView.Size = new Size(433, 204);
            gridView.Location = new Point(15, 12);


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
            DataGridViewTextBoxColumn c5 = new DataGridViewTextBoxColumn();
            c5.HeaderText = "Price"; c5.Name = "price";
            DataGridViewTextBoxColumn c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Amount"; c6.Name = "amount";
            gridView.Columns.AddRange(c0, c1, c2, c5, c6);

            for (int i = 0; i < control.Lista.dimensiune(); i++)
                gridView.Rows.Add(control.Lista.obtine(i).Data.Id, control.Lista.obtine(i).Data.Brand, control.Lista.obtine(i).Data.Model, control.Lista.obtine(i).Data.Price, control.Lista.obtine(i).Data.Amount);
        }

        private void BtnExitLogin_Click(object sender, EventArgs e)
        {
            c1.save();
            c2.save();
            c3.save();
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.new3.adding($"{this.currentAutomobileId}|{c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Km}|{int.Parse(guna2TextBox2.Text)}|{int.Parse(guna2TextBox5.Text)}|{c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Brand}|{c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Model}|{c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Color}");
            c2.changeAmount(this.currentAutomobileId, c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Amount - int.Parse(guna2TextBox2.Text));
            Panel panel = null;
            Panel panel2 = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "guna2Panel3")
                        panel2 = control as Guna2Panel;
            foreach (Control control in panel2.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView3")
                        gridView = control as BunifuDataGridView;
            panel2.Controls.Remove(gridView);
            double k = double.Parse(label9.Text);
            label9.Text = (k + double.Parse(guna2TextBox5.Text)).ToString();
            BunifuDataGridView gridView3 = new BunifuDataGridView();
            tabel3(new3, gridView3);
            guna2Panel3.Controls.Add(gridView3);


            panel2 = null;
            gridView = null;
            foreach (Control control in panel.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "guna2Panel4")
                        panel2 = control as Guna2Panel;
            foreach (Control control in panel2.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView2")
                        gridView = control as BunifuDataGridView;
            panel2.Controls.Remove(gridView);
            BunifuDataGridView gridView2 = new BunifuDataGridView();
            tabel2(c2, gridView2);
            guna2Panel4.Controls.Add(gridView2);


        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            Panel panel = null;
            Panel panel2 = null;
            BunifuDataGridView gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "guna2Panel1")
                        panel2 = control as Guna2Panel;
            foreach (Control control in panel2.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView1")
                        gridView = control as BunifuDataGridView;
            string auto = "", amou = "";
            for (int i = 0; i < this.new3.Lista.dimensiune() - 1; i++)
            {
                auto += this.new3.Lista.obtine(i).Data.Id + ",";
                amou += this.new3.Lista.obtine(i).Data.Amount + ",";
            }
            auto += this.new3.Lista.obtine(this.new3.Lista.dimensiune() - 1).Data.Id + ",";
            amou += this.new3.Lista.obtine(this.new3.Lista.dimensiune() - 1).Data.Amount + ",";
            c3.adding($"{c3.generationId()}|{this.currentId}|{this.new3.Lista.dimensiune()}|{auto}|{amou}");
            panel2.Controls.Remove(gridView);
            this.new3 = new Control_Automobile();
            BunifuDataGridView gridView1 = new BunifuDataGridView();
            tabel1(c3, gridView1);
            guna2Panel1.Controls.Add(gridView1);

            panel = null;
            panel2 = null;
            gridView = null;
            foreach (Control control in this.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "PanelAdminAutomobile")
                        panel = control as Guna2Panel;
            foreach (Control control in panel.Controls)
                if ((control is Guna2Panel))
                    if ((control as Guna2Panel).Name == "guna2Panel3")
                        panel2 = control as Guna2Panel;
            foreach (Control control in panel2.Controls)
                if ((control is BunifuDataGridView))
                    if ((control as BunifuDataGridView).Name == "gridView3")
                        gridView = control as BunifuDataGridView;
            panel2.Controls.Remove(gridView);
            BunifuDataGridView gridView3 = new BunifuDataGridView();
            tabel3(new3, gridView3);
            guna2Panel3.Controls.Add(gridView3);

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            int k = int.Parse(c2.Lista.obtine(c2.positionId(this.currentAutomobileId)).Data.Price.ToString()), k1;
            if (guna2TextBox2.Text != "")
                k1 = int.Parse(guna2TextBox2.Text);
            else
                k1 = 0;
            guna2TextBox5.Text = (k * k1).ToString();

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            c1.save();
            c2.save();
            c3.save();
            this.Hide();
            Login_Mockup_Form a = new Login_Mockup_Form();
            a.Show();
        }
    }
}
