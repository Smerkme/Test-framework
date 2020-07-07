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
    public partial class Form4 : Form
    {
        public Model model4 = new Model();
        public string question = "";
        public List<string> answers = new List<string>();
        public int index = 0;
        public Form4(int index, Model model)
        {
            InitializeComponent();

            this.KeyPreview = true;

            this.index = index;
            this.model4 = model;
            this.question = model4.questions_fix[index];
            this.answers = model4.answers_fix[index];
        }

        public void f()
        {
            int i = 0;

            label_question.Text = question;
            label1.Text = "Вопрос " + (index+1).ToString();

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
            //is_true_ans = model4.ans[x];
            //is_question = model4.questions[x];

            //fill form2
            if (i < answers.Count)
            {
                label2.Text = answers[i];
                i++;
            }

            if (i < answers.Count)
            {
                label3.Text = answers[i];
                i++;
            }

            if (i < answers.Count)
            {
                label4.Text = answers[i];
                i++;
            }

            if (i < answers.Count)
            {
                label5.Text = answers[i];
                i++;
            }
            else
            {
                checkBox4.Visible = false;
                label5.Visible = false;
            }

            if (i < answers.Count)
            {
                label6.Text = answers[i];
                i++;
            }
            else
            {
                checkBox5.Visible = false;
                label6.Visible = false;
            }

            if (i < answers.Count)
            {
                label7.Text = answers[i];
                i++;
            }
            else
            {
                checkBox6.Visible = false;
                label7.Visible = false;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
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
            checkBox4.Top = checkBox3.Top + checkBox4.Height + 70;
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

            //checkBoxes
            if (model4.rb[index] == 1)
            {
                checkBox1.Checked = true;
            } 

            else if (model4.rb[index] == 2)
            {
                checkBox2.Checked = true;
            }

            else if (model4.rb[index] == 3)
            {
                checkBox3.Checked = true;
            }

            else if (model4.rb[index] == 4)
            {
                checkBox4.Checked = true;
            }

            else if (model4.rb[index] == 5)
            {
                checkBox5.Checked = true;
            }

            else if (model4.rb[index] == 6)
            {
                checkBox6.Checked = true;
            }


                //add question and answers to form
                f();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
                    model4.user_ans_bool[index] = label2.Text == model4.ans_this_test[index];
                    model4.rb[index] = 1;
                    model4.user_ans_text[index] = label2.Text;
                }

                else if (checkBox2.Checked)
                {
                    model4.user_ans_bool[index] = label3.Text == model4.ans_this_test[index];
                    model4.rb[index] = 2;
                    model4.user_ans_text[index] = label3.Text;
                }

                else if (checkBox3.Checked)
                {
                    model4.user_ans_bool[index] = label4.Text == model4.ans_this_test[index];
                    model4.rb[index] = 3;
                    model4.user_ans_text[index] = label4.Text;
                }

                else if (checkBox4.Checked)
                {
                    model4.user_ans_bool[index] = label5.Text == model4.ans_this_test[index];
                    model4.rb[index] = 4;
                    model4.user_ans_text[index] = label5.Text;
                }

                else if (checkBox5.Checked)
                {
                    model4.user_ans_bool[index] = label6.Text == model4.ans_this_test[index];
                    model4.rb[index] = 5;
                    model4.user_ans_text[index] = label6.Text;
                }

                else if (checkBox6.Checked)
                {
                    model4.user_ans_bool[index] = label7.Text == model4.ans_this_test[index];
                    model4.rb[index] = 6;
                    model4.user_ans_text[index] = label7.Text;
                }

                //show last form
                Form3 form3 = new Form3(model4);
                form3.Show();

                this.Hide();
            }
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
