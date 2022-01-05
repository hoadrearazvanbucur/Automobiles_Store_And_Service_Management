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

        private void label4_Click(object sender, EventArgs e)
        {
            //50 450
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public Control_Automobile c;

        public void test()
        {
            c = new Control_Automobile();
            c.adding($"{c.generationId()}|123|234|99|Mercedes|S Klass|Maro");
            c.adding($"{c.generationId()}|123|234|99|Mercedes|S Klass|Maro");
            c.adding($"{c.generationId()}|1243|2324|991|Mercewdes|S Klawss|Marodwa");
            BunifuDataGridView gridView = new BunifuDataGridView();
            tabel(c, gridView);
            this.PanelAdminAutomobile.Controls.Add(gridView);
        }


        public void tabel(Control_Automobile control, BunifuDataGridView gridView)
        {
            gridView.Size = new Size(1150, 250);
            gridView.Location = new Point(50, 450);

            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.DefaultCellStyle = dataGridViewCellStyle1;

            //aa
            gridView.Theme = BunifuDataGridView.PresetThemes.Crimson;
            gridView.BackgroundColor = SystemColors.ControlLightLight;
            gridView.Columns.AddRange(
    new DataGridViewTextBoxColumn()
    {
        HeaderText = "Brand",
        Name = "brand"
    },
    new DataGridViewTextBoxColumn()
    {
        HeaderText = "Model",
        Name = "model"
    },
    new DataGridViewTextBoxColumn()
    {
        HeaderText = "Color",
        Name = "color"
    },
    new DataGridViewTextBoxColumn()
    {
        HeaderText = "Km",
        Name = "km"
    },
    new DataGridViewTextBoxColumn()
    {
        HeaderText = "Price",
        Name = "price"
    },
        new DataGridViewTextBoxColumn()
        {
            HeaderText = "Amount",
            Name = "amount"
        }
    );
            for(int i=0;i<control.Lista.dimensiune();i++)
            {
                gridView.Rows.Add(control.Lista.obtine(i).Data.Brand, control.Lista.obtine(i).Data.Model, control.Lista.obtine(i).Data.Color, control.Lista.obtine(i).Data.Km, control.Lista.obtine(i).Data.Price, control.Lista.obtine(i).Data.Amount);
            }

        }

    }
}
