using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form7 : Form
    {
        public Model model7 = new Model();
        public Form7(Model model)
        {
            InitializeComponent();
            this.model7 = model;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            res.Visible = true;
            button1.Visible = true;

            //css
            button1.Left = this.Width - button1.Width - 50;
            button1.Top = this.Height - button1.Height - 50;

            //answers buttons
            question_1.Left = res.Left + res.Width + 10;
            question_1.Top = res.Top;

            question_2.Left = question_1.Left + question_1.Width + 5;
            question_2.Top = res.Top;

            question_3.Left = question_2.Left + question_2.Width + 5;
            question_3.Top = res.Top;

            question_4.Left = question_3.Left + question_3.Width + 5;
            question_4.Top = res.Top;

            question_5.Left = question_4.Left + question_4.Width + 5;
            question_5.Top = res.Top;

            question_6.Left = question_5.Left + question_5.Width + 5;
            question_6.Top = res.Top;

            question_7.Left = question_6.Left + question_6.Width + 5;
            question_7.Top = res.Top;

            question_8.Left = question_7.Left + question_7.Width + 5;
            question_8.Top = res.Top;

            question_9.Left = question_8.Left + question_8.Width + 5;
            question_9.Top = res.Top;

            question_10.Left = question_9.Left + question_9.Width + 5;
            question_10.Top = res.Top;

            question_11.Left = question_10.Left + question_10.Width + 5;
            question_11.Top = res.Top;

            question_12.Left = question_11.Left + question_11.Width + 5;
            question_12.Top = res.Top;

            question_13.Left = question_12.Left + question_12.Width + 5;
            question_13.Top = res.Top;

            question_14.Left = question_13.Left + question_13.Width + 5;
            question_14.Top = res.Top;

            question_15.Left = question_14.Left + question_14.Width + 5;
            question_15.Top = res.Top;

            question_16.Left = question_15.Left + question_15.Width + 5;
            question_16.Top = res.Top;

            question_17.Left = question_16.Left + question_16.Width + 5;
            question_17.Top = res.Top;

            question_18.Left = question_17.Left + question_17.Width + 5;
            question_18.Top = res.Top;

            question_19.Left = question_18.Left + question_18.Width + 5;
            question_19.Top = res.Top;

            question_20.Left = question_19.Left + question_19.Width + 5;
            question_20.Top = res.Top;
        }

        private void question_1_Click(object sender, EventArgs e)
        {
            //show last form
            Form8 form8 = new Form8(int.Parse(((Button)sender).Text) - 1, model7);
            form8.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int plus = 0;
            int i = 1;

            //off questions buttons
            question_1.Visible = false;
            question_2.Visible = false;
            question_3.Visible = false;
            question_4.Visible = false;
            question_5.Visible = false;
            question_6.Visible = false;
            question_7.Visible = false;
            question_8.Visible = false;
            question_9.Visible = false;
            question_10.Visible = false;
            question_11.Visible = false;
            question_12.Visible = false;
            question_13.Visible = false;
            question_14.Visible = false;
            question_15.Visible = false;
            question_16.Visible = false;
            question_17.Visible = false;
            question_18.Visible = false;
            question_19.Visible = false;
            question_20.Visible = false;

            //statistics


            //show last form
            Form9 form9 = new Form9(model7);
            form9.Show();

            this.Hide();

            this.Hide();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
