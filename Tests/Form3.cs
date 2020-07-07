using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form3 : Form
    {
        public Model model3 = new Model();
        public Form3(Model model)
        {
            InitializeComponent();
            this.model3 = model;
        }

        private void Form3_Load(object sender, EventArgs e)
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

            button1.Visible = false;

            //statistics
            List<int> num_ans = new List<int>();
            List<int> num_true_ans = new List<int>();
            List<string> questions_this_test = new List<string>();
            int num;
            StreamReader f = new StreamReader(model3.filename_txt);
            while (!f.EndOfStream)
            {
                string[] s = f.ReadLine().Split(';');
                if (int.TryParse(s[0], out num)) {
                    num_ans.Add(int.Parse(s[0]));
                }
                if (int.TryParse(s[1], out num)) {
                    num_true_ans.Add(int.Parse(s[1]));
                }
                questions_this_test.Add(s[2]);
                //MessageBox.Show(s[2]);
            }

            int x;
            int count = 0;

            for (int ind = 0; ind < num_ans.Count; ind++)
            {
                //MessageBox.Show(questions_this_test[ind]);
                if (model3.questions_this_test_statistics.Contains(model3.questions_for_statistics[ind]))
                {
                    count++;
                    x = model3.questions_this_test_statistics.IndexOf(model3.questions_for_statistics[ind]);
                    num_ans[ind]++;
                    if (model3.user_ans_bool[x])
                    {
                        num_true_ans[ind]++;
                    }
                    else
                    {
                        num_true_ans[ind]--;
                    }
                }
            }
            MessageBox.Show(count.ToString());
            f.Close();

            FileStream fs = new FileStream(model3.filename_txt, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
            MessageBox.Show(num_ans.Count.ToString() + " " + num_true_ans.Count.ToString() + " " +
                model3.questions_for_statistics.Count.ToString());
            for (int ind = 0; ind < num_ans.Count; ind++)
            {
                sr.WriteLine(num_ans[ind].ToString() + ";" + num_true_ans[ind].ToString() +
                    ";" + model3.questions_for_statistics[ind]);
            }

            //show last form
            Form5 form5 = new Form5(model3);
            form5.Show();

            this.Hide();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void question_1_Click(object sender, EventArgs e)
        {
            //show last form
            Form4 form4 = new Form4(int.Parse(((Button)sender).Text) - 1, model3);
            form4.Show();

            this.Hide();
        }

    }
}
