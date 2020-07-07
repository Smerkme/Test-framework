using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Tests
{
    public class Model
    {
        //main
        public string FIO;
        public string filename;
        public string filename_txt;
        public String[,] table;
        public List<string> questions;
        public List<List<string>> ans; //answers
        public List<string> check_ans; //true answer for all questions for 1 ans tests
        public List<string> ans_this_test; // 20 answers for this test
        public List<bool> user_ans_bool; //is user answer true? 
        public List<string> user_ans_text;
        public List<string> questions_for_statistics;
        public List<string> questions_this_test_statistics;

        //for fixing answers by user
        public List<string> questions_fix;
        public List<List<string>> answers_fix;

        //which chechbox is checked?
        public List<int> rb;

        //list for 2 ans test
        public List<List<string>> ans_two;
        public List<int> is_two_ans;
        public List<bool> is_2_ans_question;
        public List<List<string>> check_ans_2; //true answer for all questions for 2 ans tests
        public List<List<string>> ans_this_test_2 = new List<List<string>>(20); // 20 answers for this test for 2 ans tests
        public List<List<int>> rb_2;
        public List<List<string>> user_ans_text_2;
        public List<bool> is_2_ans_question_this_test;
    }
}
