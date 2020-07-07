using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using OfficeOpenXml;

namespace Tests
{
    public partial class Form1 : Form
    {
        public Model model = new Model();
        public string pwd;
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        public void createData(string filename)
        {
            //table
            String[,] table;

            ExcelPackage excelFile = new ExcelPackage(new FileInfo(filename));
            ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[0];

            int rows = 0, columns = 0;
            rows = worksheet.Dimension.End.Row;
            columns = worksheet.Dimension.End.Column;

            table = new string[rows, columns];

            int num;
            int index = 0;
            List<string> questions = new List<string>();
            List<List<string>> ans = new List<List<string>>();
            List<string> check_ans = new List<string>();
            //List<Dictionary<string, List<string>>> data = new List<Dictionary<string, List<string>>>();
            List<string> temp = new List<string>();
            List<string> q_for_statistics = new List<string>();
            bool isZero = true;
            string q = "";

            for (int rowInd = 1; rowInd <= rows; rowInd++)
            {
                IEnumerable<string> row = worksheet.Cells[rowInd, 1, rowInd, columns]
                    .Select(c => c.Value == null ? string.Empty : c.Value.ToString());

                List<string> list = row.ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    table[rowInd - 1, i] = Convert.ToString(list[i]);
                }

                //MessageBox.Show(table[rowInd - 1, 0].Substring(0));

                if (int.TryParse(table[rowInd - 1, 0].
                Substring(table[rowInd - 1, 0].Length - 1), out num))
                {
                    if (!isZero)
                    {
                        ans.Add(temp);
                        //MessageBox.Show(check_ans[index]);

                        questions.Add(q);
                        q_for_statistics.Add(q);
                        q = list[1];
                        index++;
                        if (questions.Count - 1 == index)
                        {
                            MessageBox.Show("error!");
                        }
                    }
                    else
                    {
                        q = list[1];
                        isZero = false;
                    }
                    //index++;
                    temp = new List<string>();
                }
                else
                {
                    //MessageBox.Show(list[1]);
                    if (list.Count == 1)
                    {
                        if (table[rowInd - 1, 0].Substring(table[rowInd - 1, 0].Length - 1) == "a")
                        {
                            //list[0] += "t";
                            //MessageBox.Show(list[0]);
                            check_ans.Add(list[0]);
                        }
                        temp.Add(list[0]);
                    }
                    else
                    {
                        if (table[rowInd - 1, 0].Substring(table[rowInd - 1, 0].Length - 1) == "a")
                        {
                            //list[1] += "t";
                            //MessageBox.Show(list[1]);
                            check_ans.Add(list[1]);
                        }
                        temp.Add(list[1]);
                    }

                }
            }

            /*for (int z = 0; z < 3; z++)
            {
                MessageBox.Show(questions[z] + '\n');
                for (int p = 0; p < ans[z].Count; p++)
                {
                    MessageBox.Show(ans[z][p] + '\n');
                }
            }*/

            //name and table to model object
            model.FIO = textBox1.Text;
            model.table = table;
            model.questions = questions;
            model.ans = ans;
            model.check_ans = check_ans;
            model.filename = filename;
            model.questions_for_statistics = q_for_statistics;
            //MessageBox.Show( model.questions_for_statistics.Count.ToString());

            //work Form2
            Form2 newForm = new Form2(model);
            newForm.Show();

            this.Hide();
        }

        public void createData_for_2_answers(string filename)
        {
            //table
            String[,] table;

            ExcelPackage excelFile = new ExcelPackage(new FileInfo(filename));
            ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[0];

            int rows = 0, columns = 0;
            rows = worksheet.Dimension.End.Row;
            columns = worksheet.Dimension.End.Column;

            table = new string[rows, columns];
            List<string> list = null;

            int num;
            int index = 0;

            List<string> questions = new List<string>();
            List<int> is_two_answers_int = new List<int>(); //tmp
            List<List<string>> ans = new List<List<string>>();
            List<List<string>> check_ans_2 = new List<List<string>>();
            List<bool> is_2_ans_question = new List<bool>();//is 2 ans?
            //List<Dictionary<string, List<string>>> data = new List<Dictionary<string, List<string>>>();
            List<string> temp = new List<string>();
            bool isZero = true;
            string q = "";

            for (int rowInd = 1; rowInd <= rows; rowInd++)
            {
                IEnumerable<string> row = worksheet.Cells[rowInd, 1, rowInd, columns]
                    .Select(c => c.Value == null ? string.Empty : c.Value.ToString());

                list = row.ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    table[rowInd - 1, i] = Convert.ToString(list[i]);
                }

                //MessageBox.Show(table[rowInd - 1, 0].Substring(0));

                if (int.TryParse(table[rowInd - 1, 0].
                Substring(table[rowInd - 1, 0].Length - 1), out num))
                {
                    if (!isZero)
                    {
                        ans.Add(temp);

                        check_ans_2.Add(new List<string>());
                        questions.Add(q);
                        q = list[1];
                        index++;
                        if (questions.Count - 1 == index)
                        {
                            MessageBox.Show("error!");
                        }
                    }
                    else
                    {
                        q = list[1];
                        isZero = false;
                        check_ans_2.Add(new List<string>());
                    }
                    //index++;
                    temp = new List<string>();
                }
                else
                {
                    if (list.Count == 1)
                    {
                        if (table[rowInd - 1, 0].Substring(table[rowInd - 1, 0].Length - 1) == "a"
                            || table[rowInd - 1, 0].Substring(table[rowInd - 1, 0].Length - 2) == "aa")
                        {
                            check_ans_2[index].Add(list[0]);
                        }
                        temp.Add(list[0]);
                    }
                    else
                    {
                        if (table[rowInd - 1, 0].Substring(table[rowInd - 1, 0].Length - 1) == "a"
                            || table[rowInd - 1, 0].Substring(table[rowInd - 1, 0].Length - 2) == "aa")
                        { 
                            check_ans_2[index].Add(list[1]);
                        }
                        temp.Add(list[1]);
                    }

                }
            }

            //add last answers
            ans.Add(temp);
            questions.Add(q);

            is_2_ans_question = new List<bool>();
            for (int i = 0; i < check_ans_2.Count; i++)
            {
                is_two_answers_int.Add(check_ans_2[i].Count);
                if (is_two_answers_int[i] == 1)
                {
                    is_2_ans_question.Add(false);
                }
                else if (is_two_answers_int[i] == 2)
                {
                    is_2_ans_question.Add(true);
                }
                else
                {
                    MessageBox.Show("error with is_2_ans_question! " + is_two_answers_int[i].ToString());
                }
            }

            //MessageBox.Show(is_2_ans_question.Count.ToString() + " " + questions.Count.ToString() + " " + check_ans_2.Count.ToString());

            //name and table to model object
            model.FIO = textBox1.Text;
            model.table = table;
            model.questions = questions;
            model.ans = ans;
            model.is_two_ans = is_two_answers_int;
            model.is_2_ans_question = is_2_ans_question;
            model.check_ans_2 = check_ans_2;
            model.filename = filename;

            //work Form6
            Form6 newForm = new Form6(model);
            newForm.Show();

            this.Hide();
        }

        public void fill_the_statistic_files(string file)
        {
            string name = model.FIO + "_" + file;
            model.filename_txt = name;

            //StreamWriter f = new StreamWriter("test.txt");
            try
            {
                using (StreamWriter f = new StreamWriter(name))
                {
                    int i = 0;
                    foreach (string q in model.questions)
                    {
                        f.WriteLine("0;0;" + model.questions[i]);
                        i++;
                    }
                    MessageBox.Show(model.questions.Count.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Файл не найден!");
            }

            /*using (FileStream fstream = new FileStream(name, FileMode.OpenOrCreate))
            {
                foreach (string q in model.questions)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("0");
                    fstream.Write
                    fstream.WriteAsync(array, 0, array.Length);
                }
                

                fstream.Close();
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pwd = AppDomain.CurrentDomain.BaseDirectory;

            label1.Left = this.Width / 2 - label1.Width / 2;//привели в центр
            label2.Left = this.Width / 2 - label2.Width / 2;//привели в центр
            textBox1.Left = this.Width / 2 - textBox1.Width / 2;//привели в центр
            button1.Left = this.Width / 2 - button1.Width / 2;//привели в центр
            button2.Left = this.Width / 2 - button2.Width / 2;//привели в центр
            button3.Left = this.Width / 2 - button3.Width / 2;//привели в центр
            button4.Left = this.Width / 2 - button4.Width / 2;//привели в центр
            button5.Left = this.Width / 2 - button5.Width / 2;//привели в центр
            button6.Left = this.Width / 2 - button6.Width / 2;//привели в центр

            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = "А.1 Основы промышленной безопасности.xlsx";

            if (!System.IO.File.Exists(pwd + filename.Substring(0, filename.Length - 4) + "txt"))
            {
                System.IO.File.Create(pwd + textBox1.Text + "_" + 
                    filename.Substring(0, filename.Length - 4) + "txt");
            }
 
            createData_for_2_answers(filename);
            fill_the_statistic_files(filename.Substring(0, filename.Length - 4) + "txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filename = "Б.1.11 Проектирование химически опасных производственных объектов.xlsx";

            if (!System.IO.File.Exists(pwd + filename.Substring(0, filename.Length - 4) + "txt"))
            {
                System.IO.File.Create(pwd + textBox1.Text + "_" +
                    filename.Substring(0, filename.Length - 4) + "txt");
            }

            createData_for_2_answers(filename);
            fill_the_statistic_files(filename.Substring(0, filename.Length - 4) + "txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filename = "Б1.28.xlsx";

            if (!System.IO.File.Exists(pwd + filename.Substring(0, filename.Length - 4) + "txt"))
            {
                System.IO.File.Create(pwd + textBox1.Text + "_" +
                    filename.Substring(0, filename.Length - 4) + "txt");
            }

            createData(filename);
            fill_the_statistic_files(filename.Substring(0, filename.Length - 4) + "txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string filename = "Б.1.29.xlsx";

            if (!System.IO.File.Exists(pwd + filename.Substring(0, filename.Length - 4) + "txt"))
            {
                System.IO.File.Create(pwd + textBox1.Text + "_" +
                    filename.Substring(0, filename.Length - 4) + "txt");
            }

            createData(filename);
            fill_the_statistic_files(filename.Substring(0, filename.Length - 4) + "txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filename = "Б7.6.xlsx";

            if (!System.IO.File.Exists(pwd + filename.Substring(0, filename.Length - 4) + "txt"))
            {
                System.IO.File.Create(pwd + textBox1.Text + "_" +
                    filename.Substring(0, filename.Length - 4) + "txt");
            }

            createData_for_2_answers(filename);
            fill_the_statistic_files(filename.Substring(0, filename.Length - 4) + "txt");
        }
    }
}
