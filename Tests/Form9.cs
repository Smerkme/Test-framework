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
    public partial class Form9 : Form
    {
        public Model model9 = new Model();

        //for data table
        public int row { get; set; }
        public int column { get; set; }
        public DataTable dataTable { get; set; }
        public DataColumn[] dataColumn;


        public Form9(Model model)
        {
            InitializeComponent();
            this.model9 = model;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            //label text
            int ans = 0;
            foreach (bool b in model9.user_ans_bool)
            {
                if (b)
                {
                    ans++;
                }
            }
            label1.Text += ans.ToString() + " из 20";
            label1.Left = this.Left + 50;
            label1.Top = this.Bottom - 100;

            username.Left = label1.Left;
            username.Top = label1.Top + 40;
            username.Text += model9.FIO;


            //css
            button_again.Left = this.Width - button_again.Width - 50;
            button_again.Top = this.Height - button_again.Height - 50;

            button_statistic.Left = button_again.Left - button_statistic.Width - 10;
            button_statistic.Top = button_again.Top;

            dataGridView1.Width = this.Width - 30;
            dataGridView1.Height = this.Height - 150;
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);

            //data grid view
            dataTable = new DataTable();

            // ++++ add columns
            dataColumn = new DataColumn[4];
            string columnName = "";

            columnName = "Номер вопроса";
            dataColumn[0] = new DataColumn(columnName);

            columnName = "Вопрос";
            dataColumn[1] = new DataColumn(columnName);

            columnName = "Ответ пользователя";
            dataColumn[2] = new DataColumn(columnName);

            columnName = "Верный ответ";
            dataColumn[3] = new DataColumn(columnName);

            dataTable.Columns.AddRange(dataColumn);

            //dataTable to data grid view and css
            dataGridView1.DataSource = dataTable;

            //++++ add rows
            DataRow dataRow;
            string str;
            for (int i = 0; i < 20; i++)
            {
                //fill row
                dataRow = dataTable.NewRow();
                dataRow[0] = i + 1;
                dataRow[1] = model9.questions_fix[i];
                if (model9.is_2_ans_question_this_test[i])
                {
                    /*str = model9.user_ans_text_2[i][0];
                    str += '\n' + '\n';
                    str += model9.user_ans_text_2[i][1];
                    dataRow[2] = str;*/
                    dataRow[2] = "1) " + model9.user_ans_text_2[i][0] + '\n' + '\n' + "2) " + model9.user_ans_text_2[i][1];
                }
                else
                {
                    //dataRow[2] = model9.user_ans_text_2[i][0];
                    dataRow[2] = model9.user_ans_text_2[i][0];
                }
                if (!model9.user_ans_bool[i])
                {
                    if (model9.is_2_ans_question_this_test[i])
                    {
                        if (model9.ans_this_test_2[i].Contains(model9.user_ans_text_2[i][0]) ||
                        model9.ans_this_test_2[i].Contains(model9.user_ans_text_2[i][1]))
                        {
                            dataRow[3] = "1) " + model9.ans_this_test_2[i][0] + '\n' + '\n' + "2) " + model9.ans_this_test_2[i][1];
                            dataTable.Rows.Add(dataRow);
                            dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Orange;
                            dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            dataRow[3] = "1) " + model9.ans_this_test_2[i][0] + '\n' + '\n' + "2) " + model9.ans_this_test_2[i][1];
                            dataTable.Rows.Add(dataRow);
                            dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                            dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Green;
                        }
                    }
                    else
                    {
                        dataRow[3] = model9.ans_this_test_2[i][0];
                        dataTable.Rows.Add(dataRow);
                        dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Green;
                    }
                }
                else
                {
                    dataRow[3] = "";
                    dataTable.Rows.Add(dataRow);
                    dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Green;
                }
            }

            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = (dataGridView1.Width -
            dataGridView1.Columns[0].Width - dataGridView1.Columns[1].Width - 100) / 2 + 20;
            dataGridView1.Columns[3].Width = dataGridView1.Columns[2].Width - 20;
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_again_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button_statistic_Click(object sender, EventArgs e)
        {

        }
    }
}
