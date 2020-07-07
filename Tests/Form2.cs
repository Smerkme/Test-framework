using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Tests
{
    public partial class Form2 : Form
    {
        public Model model2;
        public int question_number = 1;
        public List<bool> user_ans_bool = new List<bool>(20);
        public List<string> user_ans_text = new List<string>(20);
        public List<string> ans_this_test = new List<string>(20);
        public List<string> questions_this_test_statistics = new List<string>();
        public Random r = new Random();
        public string is_question = "";
        public int x = 0;

        //for fixing by user
        public List<string> questions_fix = new List<string>();
        public List<List<string>> answers_fix = new List<List<string>>();

        //which rb is checked?
        public List<int> rb = new List<int>();

        public void func(int number)
        {
            x = r.Next(model2.questions.Count - 1);
            //int x = 0;
            label_question.Text = model2.questions[x];
            questions_this_test_statistics.Add(model2.questions[x]);
            label1.Text = "Вопрос " + number.ToString();

            int ans_ind = 0;
            int i = 1;
            int num = 0;

            //List<string> answers = new List<string>();

            //loop
            /*while (!int.TryParse(model2.table[i, 0].
                Substring(model2.table[i, 0].Length - 1), out num))
            {
                answers.Add(model2.table[i, 1]);
                i++;
                ans_ind++;
            }*/

            i = 0;
            for (int k = model2.ans[x].Count - 1; k > 0; k--)
            {
                int j = r.Next(k + 1);
                // обменять значения data[j] и data[i]
                var temp = model2.ans[x][j];
                model2.ans[x][j] = model2.ans[x][k];
                model2.ans[x][k] = temp;
            }

            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            checkBox5.Visible = true;
            checkBox6.Visible = true;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            //check answers
            //is_true_ans = model2.ans[x];
            //is_question = model2.questions[x];

            //fill form2
            if (i < model2.ans[x].Count)
            {
                label2.Text = model2.ans[x][i];
                i++;
            }

            if (i < model2.ans[x].Count)
            {
                label3.Text = model2.ans[x][i];
                i++;
            }

            if (i < model2.ans[x].Count)
            {
                label4.Text = model2.ans[x][i];
                i++;
            }
            else
            {
                checkBox3.Visible = false;
                label4.Visible = false;
            }

            if (i < model2.ans[x].Count)
            {
                label5.Text = model2.ans[x][i];
                i++;
            }
            else
            {
                checkBox4.Visible = false;
                label5.Visible = false;
            }

            if (i < model2.ans[x].Count)
            {
                label6.Text = model2.ans[x][i];
                i++;
            }
            else
            {
                checkBox5.Visible = false;
                label6.Visible = false;
            }

            if (i < model2.ans[x].Count)
            {
                label7.Text = model2.ans[x][i];
                i++;
            }
            else
            {
                checkBox6.Visible = false;
                label7.Visible = false;
            }

            //adding values to fixing Lists
            questions_fix.Add(model2.questions[x]);
            answers_fix.Add(model2.ans[x]);

            model2.questions.RemoveAt(x);
            model2.ans.RemoveAt(x);
        }
        public Form2(Model model)
        {
            InitializeComponent();
            this.model2 = model;

            this.KeyPreview = true;
            //this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            //this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            //css
            button1.Left = this.Width - button1.Width - 50;
            button1.Top = this.Height - button1.Height - 50;

            checkBox1.Left = label1.Left;
            checkBox1.Top = label1.Top + checkBox1.Height + 100;
            label2.Left = checkBox1.Left + checkBox1.Width + 10;
            label2.Top = checkBox1.Top;

            checkBox2.Left = label1.Left;
            checkBox2.Top = checkBox1.Top + checkBox2.Height + 70;
            label3.Left = checkBox2.Left + checkBox2.Width + 10;
            label3.Top = checkBox2.Top;

            checkBox3.Left = label1.Left;
            checkBox3.Top = checkBox2.Top + checkBox3.Height + 70;
            label4.Left = checkBox3.Left + checkBox3.Width + 10;
            label4.Top = checkBox3.Top;

            checkBox4.Left = label1.Left;
            checkBox4.Top = checkBox3.Top + checkBox4.Height +70;
            label5.Left = checkBox4.Left + checkBox4.Width + 10;
            label5.Top = checkBox4.Top;

            checkBox5.Left = label1.Left;
            checkBox5.Top = checkBox4.Top + checkBox5.Height + 70;
            label6.Left = checkBox5.Left + checkBox5.Width + 10;
            label6.Top = checkBox5.Top;

            checkBox6.Left = label1.Left;
            checkBox6.Top = checkBox5.Top + checkBox6.Height + 70;
            label7.Left = checkBox6.Left + checkBox6.Width + 10;
            label7.Top = checkBox6.Top;

            //work func
            func(question_number);
            question_number++;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!checkBox1.Checked) && (!checkBox2.Checked) &&
                (!checkBox3.Checked) && (!checkBox4.Checked) &&
                (!checkBox5.Checked) && (!checkBox6.Checked))
            {
                MessageBox.Show("Пожалуйста, выберите ответ!");
            }
            else
            {
                //MessageBox.Show(model2.check_ans[x]);

                //check ans after press next question
                if (checkBox1.Checked)
                {
                    user_ans_bool.Add(label2.Text == model2.check_ans[x]);
                    rb.Add(1);
                    user_ans_text.Add(label2.Text);
                }

                else if (checkBox2.Checked)
                {
                    user_ans_bool.Add(label3.Text == model2.check_ans[x]);
                    rb.Add(2);
                    user_ans_text.Add(label3.Text);
                }

                else if (checkBox3.Checked)
                {
                    user_ans_bool.Add(label4.Text == model2.check_ans[x]);
                    rb.Add(3);
                    user_ans_text.Add(label4.Text);
                }

                else if (checkBox4.Checked)
                {
                    user_ans_bool.Add(label5.Text == model2.check_ans[x]);
                    rb.Add(4);
                    user_ans_text.Add(label5.Text);
                }

                else if (checkBox5.Checked)
                {
                    user_ans_bool.Add(label6.Text == model2.check_ans[x]);
                    rb.Add(5);
                    user_ans_text.Add(label6.Text);
                }

                else if (checkBox6.Checked)
                {
                    user_ans_bool.Add(label7.Text == model2.check_ans[x]);
                    rb.Add(6);
                    user_ans_text.Add(label7.Text);
                }

                ans_this_test.Add(model2.check_ans[x]);
                model2.check_ans.RemoveAt(x);

                //should we get next question?
                if (question_number <= 20)
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    func(question_number);
                    question_number++;
                }
                else
                {
                    model2.user_ans_bool = user_ans_bool;
                    model2.answers_fix = answers_fix;
                    model2.questions_fix = questions_fix;
                    model2.rb = rb;
                    model2.ans_this_test = ans_this_test;
                    model2.user_ans_text = user_ans_text;
                    model2.questions_this_test_statistics = questions_this_test_statistics;

                    //show last form
                    Form3 form3 = new Form3(model2);
                    form3.Show();

                    this.Hide();
                }
            }

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            foreach (CheckBox c in this.Controls.OfType<CheckBox>())
            {
                c.Checked = false;
            }
            CheckBox cb = (CheckBox)sender;
            cb.Checked = true;
        }
    }
}
