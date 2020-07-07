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
    public partial class Form8 : Form
    {
        public Model model8 = new Model();

        //list for checked checkbox with 2 ans
        public List<int> change_cb = new List<int>(2);

        public string question = "";
        public List<string> answers = new List<string>();
        public int index = 0;
        public Form8(int index, Model model)
        {
            InitializeComponent();
            this.model8 = model;
            this.index = index;
            this.question = model8.questions_fix[index];
            this.answers = model8.answers_fix[index];
        }

        public void f()
        {
            int i = 0;
            change_cb = model8.rb_2[index];
            label_question.Text = question;
            label1.Text = "Вопрос " + (index + 1).ToString();

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
            //is_true_ans = model8.ans[x];
            //is_question = model8.questions[x];

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

        private void Form8_Load(object sender, EventArgs e)
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

            //checkBoxs
            if (model8.rb_2[index].Contains(1))
            {
                checkBox1.Checked = true;
            }

            if (model8.rb_2[index].Contains(2))
            {
                checkBox2.Checked = true;
            }

            if (model8.rb_2[index].Contains(3))
            {
                checkBox3.Checked = true;
            }

            if (model8.rb_2[index].Contains(4))
            {
                checkBox4.Checked = true;
            }

            if (model8.rb_2[index].Contains(5))
            {
                checkBox5.Checked = true;
            }

            if (model8.rb_2[index].Contains(6))
                {
                checkBox6.Checked = true;
            }


            //add question and answers to form
            f();
        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public List<int> temp_rb;
        public List<string> temp_user_ans_text;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!model8.is_2_ans_question_this_test[index])
            {
                this.temp_rb = new List<int>();
                this.temp_user_ans_text = new List<string>();

                if ((!checkBox1.Checked) && (!checkBox2.Checked) &&
                    (!checkBox3.Checked) && (!checkBox4.Checked) &&
                    (!checkBox5.Checked) && (!checkBox6.Checked))
                {
                    MessageBox.Show("Пожалуйста, выберите ответ!");
                }
                else
                {
                    //check ans after press next question
                    if (checkBox1.Checked)
                    {
                        model8.user_ans_bool[index] = model8.ans_this_test_2[index].Contains(label2.Text);
                        temp_rb.Add(1);
                        temp_user_ans_text.Add(label2.Text);
                    }

                    else if (checkBox2.Checked)
                    {
                        model8.user_ans_bool[index] = model8.ans_this_test_2[index].Contains(label3.Text);
                        temp_rb.Add(2);
                        temp_user_ans_text.Add(label3.Text);
                    }

                    else if (checkBox3.Checked)
                    {
                        model8.user_ans_bool[index] = model8.ans_this_test_2[index].Contains(label4.Text);
                        temp_rb.Add(3);
                        temp_user_ans_text.Add(label4.Text);
                    }

                    else if (checkBox4.Checked)
                    {
                        model8.user_ans_bool[index] = model8.ans_this_test_2[index].Contains(label5.Text);
                        temp_rb.Add(4);
                        temp_user_ans_text.Add(label5.Text);
                    }

                    else if (checkBox5.Checked)
                    {
                        model8.user_ans_bool[index] = model8.ans_this_test_2[index].Contains(label6.Text);
                        temp_rb.Add(5);
                        temp_user_ans_text.Add(label6.Text);
                    }

                    else if (checkBox6.Checked)
                    {
                        model8.user_ans_bool[index] = model8.ans_this_test_2[index].Contains(label7.Text);
                        temp_rb.Add(6);
                        temp_user_ans_text.Add(label7.Text);
                    }

                    model8.rb_2[index] = temp_rb;
                    model8.user_ans_text_2[index] = temp_user_ans_text;

                    //show last form
                    Form7 form7 = new Form7(model8);
                    form7.Show();

                    this.Hide();


                }
            }
            else
            {
                this.temp_rb = new List<int>();
                this.temp_user_ans_text = new List<string>();
                int tmp = 0;
                foreach (CheckBox c in this.Controls.OfType<CheckBox>())
                {
                    if (c.Checked)
                    {
                        tmp++;
                    }
                }
                if (tmp != 2)
                {
                    MessageBox.Show("Пожалуйста, выберите 2 ответа!");
                }
                else
                {
                    //check ans after press next question
                    if (checkBox1.Checked)
                    {
                        model8.user_ans_bool[index] = true;
                        model8.user_ans_bool[index] &= model8.ans_this_test_2[index].Contains(label2.Text);
                        temp_rb.Add(1);
                        temp_user_ans_text.Add(label2.Text);
                    }

                    if (checkBox2.Checked)
                    {
                        model8.user_ans_bool[index] = true;
                        model8.user_ans_bool[index] &= model8.ans_this_test_2[index].Contains(label3.Text);
                        temp_rb.Add(2);
                        temp_user_ans_text.Add(label3.Text);
                    }

                    if (checkBox3.Checked)
                    {
                        model8.user_ans_bool[index] = true;
                        model8.user_ans_bool[index] &= model8.ans_this_test_2[index].Contains(label4.Text);
                        temp_rb.Add(3);
                        temp_user_ans_text.Add(label4.Text);
                    }

                    if (checkBox4.Checked)
                    {
                        model8.user_ans_bool[index] = true;
                        model8.user_ans_bool[index] &= model8.ans_this_test_2[index].Contains(label5.Text);
                        temp_rb.Add(4);
                        temp_user_ans_text.Add(label5.Text);
                    }

                    if (checkBox5.Checked)
                    {
                        model8.user_ans_bool[index] = true;
                        model8.user_ans_bool[index] &= model8.ans_this_test_2[index].Contains(label6.Text);
                        temp_rb.Add(5);
                        temp_user_ans_text.Add(label6.Text);
                    }

                    if (checkBox6.Checked)
                    {
                        model8.user_ans_bool[index] = true;
                        model8.user_ans_bool[index] &= model8.ans_this_test_2[index].Contains(label7.Text);
                        temp_rb.Add(6);
                        temp_user_ans_text.Add(label7.Text);
                    }

                    model8.rb_2[index] = temp_rb;
                    model8.user_ans_text_2[index] = temp_user_ans_text;

                    //show last form
                    Form7 form7 = new Form7(model8);
                    form7.Show();

                    this.Hide();
                }
            }
        }

        private void checkBox_for_two_ans_Click(object sender, EventArgs e)
        {
            if (!model8.is_2_ans_question_this_test[index])
            {
                foreach (CheckBox c in this.Controls.OfType<CheckBox>())
                {
                    c.Checked = false;
                }
                CheckBox cb = (CheckBox)sender;
                cb.Checked = true;
            }
            else
            {
                int tmp;
                if (change_cb.Count == 0)
                {
                    foreach (CheckBox c in this.Controls.OfType<CheckBox>())
                    {
                        c.Checked = false;
                    }
                    CheckBox cb2 = ((CheckBox)sender);
                    cb2.Checked = true;
                    try
                    {
                        tmp = int.Parse(((CheckBox)sender).Name.Substring(((CheckBox)sender).Name.Length - 1));
                        change_cb.Add(tmp);
                    }
                    catch
                    {
                        MessageBox.Show("Error with int.parse with change_cb.Count == 0!");
                    }

                }
                else if (change_cb.Count == 1)
                {
                    foreach (CheckBox c in this.Controls.OfType<CheckBox>())
                    {
                        c.Checked = false;
                    }
                    CheckBox cb2 = ((CheckBox)sender);
                    cb2.Checked = true;
                    if (change_cb[0] == 1)
                    {
                        checkBox1.Checked = true;
                    }

                    else if (change_cb[0] == 2)
                    {
                        checkBox2.Checked = true;
                    }

                    else if (change_cb[0] == 3)
                    {
                        checkBox3.Checked = true;
                    }

                    else if (change_cb[0] == 4)
                    {
                        checkBox4.Checked = true;
                    }

                    else if (change_cb[0] == 5)
                    {
                        checkBox5.Checked = true;
                    }

                    else if (change_cb[0] == 6)
                    {
                        checkBox6.Checked = true;
                    }

                    try
                    {
                        tmp = int.Parse(((CheckBox)sender).Name.Substring(((CheckBox)sender).Name.Length - 1));
                        change_cb.Add(tmp);
                    }
                    catch
                    {
                        MessageBox.Show("Error with int.parse with change_cb.Count == 1!");
                    }
                }
                else if (change_cb.Count == 2)
                {
                    foreach (CheckBox c in this.Controls.OfType<CheckBox>())
                    {
                        c.Checked = false;
                    }
                    CheckBox cb2 = ((CheckBox)sender);
                    cb2.Checked = true;
                    try
                    {
                        tmp = int.Parse(cb2.Name.Substring(cb2.Name.Length - 1));
                        if (change_cb[1] != tmp)
                        {
                            change_cb[0] = change_cb[1];
                            change_cb[1] = tmp;
                        }
                        //MessageBox.Show(change_cb[0].ToString() + " " + change_cb[1].ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Error with int.parse with change_cb.Count == 2!");
                    }

                    if (change_cb.Contains(1))
                    {
                        checkBox1.Checked = true;
                    }

                    if (change_cb.Contains(2))
                    {
                        checkBox2.Checked = true;
                    }

                    if (change_cb.Contains(3))
                    {
                        checkBox3.Checked = true;
                    }

                    if (change_cb.Contains(4))
                    {
                        checkBox4.Checked = true;
                    }

                    if (change_cb.Contains(5))
                    {
                        checkBox5.Checked = true;
                    }

                    if (change_cb.Contains(6))
                    {
                        checkBox6.Checked = true;
                    }
                }
            }
        }
    }
}
