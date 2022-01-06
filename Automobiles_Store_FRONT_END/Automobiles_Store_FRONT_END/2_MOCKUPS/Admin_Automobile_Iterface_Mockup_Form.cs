﻿using Automobiles_Store_BACK_END.Controllers;
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
        public Admin_Automobile_Iterface_Mockup_Form()
        {
            InitializeComponent();

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

            test();
        }

        private void BtnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Control_Automobile c;

        public void test()
        {
            c = new Control_Automobile();
            c.adding($"{c.generationId()}|1|234|99|Mercedes|S Klass|Maro");
            c.adding($"{c.generationId()}|2|234|99|Mercedes|S Klass|Maro");
            c.adding($"{c.generationId()}|3|2324|991|Mercewdes|S Klawss|Marodwa");
            c.adding($"{c.generationId()}|4|2324|991|Mercewdes|S Klawss|Marodwa");

            BunifuDataGridView gridView = new BunifuDataGridView();
            tabel(c, gridView);
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
            MessageBox.Show(gridView.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
