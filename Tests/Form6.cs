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
    public partial class Form6 : Form
    {
        //is 2 ans (bool) for buttons
        public bool is_two = false;

        //list for checked checkbox with 2 ans
        public List<int> change_cb = new List<int>(2);

        public List<List<int>> rb_2 = new List<List<int>>(20);
        public List<List<string>> user_ans_text_2 = new List<List<string>>(20);
        public List<List<string>> ans_this_test_2 = new List<List<string>>(20);

        public Model model6;
        public int question_number = 1;
        public List<bool> user_ans_bool = new List<bool>(20);
        public List<string> user_ans_text = new List<string>(20);
        public List<string> ans_this_test = new List<string>(20);
        public List<bool> is_2_ans_question_this_test = new List<bool>(20);
        public Random r = new Random();
        public string is_question = "";
        public int x = 0;
        public bool is_two_answers = false;

        //for fixing by user
        public List<string> questions_fix = new List<string>();
        public List<List<string>> answers_fix = new List<List<string>>();

        //which rb is checked?
        public List<int> rb = new List<int>();

        public void func(int number)
        {
            change_cb = new List<int>(2);
            x = r.Next(model6.questions.Count - 1);
            //int x = 0;
            label_question.Text = model6.questions[x];
            label1.Text = "Вопрос " + number.ToString();

            is_two = model6.is_2_ans_question[x];
            is_2_ans_question_this_test.Add(is_two);
            //MessageBox.Show(is_2_ans_question_this_test[is_2_ans_question_this_test.Count - 1].ToString());

            model6.ans_this_test_2.Add(model6.check_ans_2[x]);

            int ans_ind = 0;
            int i = 1;
            int num = 0;

            //List<string> answers = new List<string>();

            //loop
            /*while (!int.TryParse(model6.table[i, 0].
                Substring(model6.table[i, 0].Length - 1), out num))
            {
                answers.Add(model6.table[i, 1]);
                i++;
                ans_ind++;
            }*/

            i = 0;
            for (int k = model6.ans[x].Count - 1; k > 0; k--)
            {
                int j = r.Next(k + 1);
                // обменять значения data[j] и data[i]
                var temp = model6.ans[x][j];
                model6.ans[x][j] = model6.ans[x][k];
                model6.ans[x][k] = temp;
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
            //is_true_ans = model6.ans[x];
            //is_question = model6.questions[x];

            //fill form2
            if (i < model6.ans[x].Count)
            {
                label2.Text = model6.ans[x][i];
                i++;
            }

            if (i < model6.ans[x].Count)
            {
                label3.Text = model6.ans[x][i];
                i++;
            }

            if (i < model6.ans[x].Count)
            {
                label4.Text = model6.ans[x][i];
                i++;
            }
            else
            {
                checkBox3.Visible = false;
                label4.Visible = false;
            }

            if (i < model6.ans[x].Count)
            {
                label5.Text = model6.ans[x][i];
                i++;
            }
            else
            {
                checkBox4.Visible = false;
                label5.Visible = false;
            }

            if (i < model6.ans[x].Count)
            {
                label6.Text = model6.ans[x][i];
                i++;
            }
            else
            {
                checkBox5.Visible = false;
                label6.Visible = false;
            }

            if (i < model6.ans[x].Count)
            {
                label7.Text = model6.ans[x][i];
                i++;
            }
            else
            {
                checkBox6.Visible = false;
                label7.Visible = false;
            }

            //adding values to fixing Lists
            questions_fix.Add(model6.questions[x]);
            answers_fix.Add(model6.ans[x]);

            //is_two = model6.is_2_ans_question[x];

            model6.questions.RemoveAt(x);
            model6.ans.RemoveAt(x);
            //model6.check_ans_2.RemoveAt(x);
            model6.is_2_ans_question.RemoveAt(x);
        }
        public Form6(Model model)
        {
            InitializeComponent();
            this.model6 = model;

            this.KeyPreview = true;
            //this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            //this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
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

            //work func
            func(question_number);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox_for_two_ans_Click(object sender, EventArgs e)
        {
            if (!is_two)
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

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public List<int> temp_rb;
        public List<string> temp_user_ans_text;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!is_two)
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
                        user_ans_bool.Add(model6.check_ans_2[x].Contains(label2.Text));
                        temp_rb.Add(1);
                        temp_user_ans_text.Add(label2.Text);
                    }

                    else if (checkBox2.Checked)
                    {
                        user_ans_bool.Add(model6.check_ans_2[x].Contains(label3.Text));
                        temp_rb.Add(2);
                        temp_user_ans_text.Add(label3.Text);
                    }

                    else if (checkBox3.Checked)
                    {
                        user_ans_bool.Add(model6.check_ans_2[x].Contains(label4.Text));
                        temp_rb.Add(3);
                        temp_user_ans_text.Add(label4.Text);
                    }

                    else if (checkBox4.Checked)
                    {
                        user_ans_bool.Add(model6.check_ans_2[x].Contains(label5.Text));
                        temp_rb.Add(4);
                        temp_user_ans_text.Add(label5.Text);
                    }

                    else if (checkBox5.Checked)
                    {
                        user_ans_bool.Add(model6.check_ans_2[x].Contains(label6.Text));
                        temp_rb.Add(5);
                        temp_user_ans_text.Add(label6.Text);
                    }

                    else if (checkBox6.Checked)
                    {
                        user_ans_bool.Add(model6.check_ans_2[x].Contains(label7.Text));
                        temp_rb.Add(6);
                        temp_user_ans_text.Add(label7.Text);
                    }

                    rb_2.Add(temp_rb);
                    user_ans_text_2.Add(temp_user_ans_text);

                    /*for (int i = 0; i < user_ans_text_2[user_ans_text_2.Count - 1].Count; i++)
                    {
                        MessageBox.Show(user_ans_text_2[user_ans_text_2.Count - 1][i].ToString());
                    }*/

                    ans_this_test_2.Add(model6.check_ans_2[x]);
                    model6.check_ans_2.RemoveAt(x);

                    if (question_number < 20)
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox4.Checked = false;
                        checkBox5.Checked = false;
                        checkBox6.Checked = false;
                        question_number++;
                        func(question_number);
                    }
                    else
                    {
                        model6.user_ans_bool = user_ans_bool;
                        model6.answers_fix = answers_fix;
                        model6.questions_fix = questions_fix;
                        model6.rb_2 = rb_2;
                        model6.ans_this_test = ans_this_test;
                        model6.ans_this_test_2 = ans_this_test_2;
                        model6.user_ans_text_2 = user_ans_text_2;
                        model6.is_2_ans_question_this_test = is_2_ans_question_this_test;

                        //show last form
                        Form7 form7 = new Form7(model6);
                        form7.Show();

                        this.Hide();
                    }


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
                    user_ans_bool.Add(true);
                    //check ans after press next question
                    if (checkBox1.Checked)
                    { 
                        user_ans_bool[question_number-1] &= model6.check_ans_2[x].Contains(label2.Text);
                        temp_rb.Add(1);
                        temp_user_ans_text.Add(label2.Text);
                    }

                    if (checkBox2.Checked)
                    {
                        user_ans_bool[question_number - 1] &= model6.check_ans_2[x].Contains(label3.Text);
                        temp_rb.Add(2);
                        temp_user_ans_text.Add(label3.Text);
                    }

                    if (checkBox3.Checked)
                    {
                        user_ans_bool[question_number - 1] &= model6.check_ans_2[x].Contains(label4.Text);
                        temp_rb.Add(3);
                        temp_user_ans_text.Add(label4.Text);
                    }

                    if (checkBox4.Checked)
                    {
                        user_ans_bool[question_number - 1] &= model6.check_ans_2[x].Contains(label5.Text);
                        temp_rb.Add(4);
                        temp_user_ans_text.Add(label5.Text);
                    }

                    if (checkBox5.Checked)
                    {
                        user_ans_bool[question_number - 1] &= model6.check_ans_2[x].Contains(label6.Text);
                        temp_rb.Add(5);
                        temp_user_ans_text.Add(label6.Text);
                    }

                    if (checkBox6.Checked)
                    {
                        user_ans_bool[question_number - 1] &= model6.check_ans_2[x].Contains(label7.Text);
                        temp_rb.Add(6);
                        temp_user_ans_text.Add(label7.Text);
                    }

                    rb_2.Add(temp_rb);
                    user_ans_text_2.Add(temp_user_ans_text);

                    /*for (int i = 0; i < user_ans_text_2[user_ans_text_2.Count - 1].Count; i++)
                    {
                        MessageBox.Show(user_ans_text_2[user_ans_text_2.Count - 1][i].ToString());
                    }*/

                    ans_this_test_2.Add(model6.check_ans_2[x]);
                    model6.check_ans_2.RemoveAt(x);

                    if (question_number < 20)
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = false;
                        checkBox4.Checked = false;
                        checkBox5.Checked = false;
                        checkBox6.Checked = false;
                        question_number++;
                        func(question_number);
                    }
                    else
                    {
                        model6.user_ans_bool = user_ans_bool;
                        model6.answers_fix = answers_fix;
                        model6.questions_fix = questions_fix;
                        model6.rb_2 = rb_2;
                        model6.ans_this_test = ans_this_test;
                        model6.ans_this_test_2 = ans_this_test_2;
                        model6.user_ans_text_2 = user_ans_text_2;
                        model6.is_2_ans_question_this_test = is_2_ans_question_this_test;

                        //show last form
                        Form7 form7 = new Form7(model6);
                        form7.Show();

                        this.Hide();
                    }
                }
            }
        }
    }
}
