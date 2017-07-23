using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standardized_Exam_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text == "")
            { MessageBox.Show("你还没有输入学号！", "提示"); }
            else if (comboBox1.Text == "")
            { MessageBox.Show("你还没有选择考试题目！", "提示"); }
            else
            {
                if (comboBox1.Text == "网络科技")
                { Question.q0 = Question.q1; }
                if (comboBox1.Text == "世界地理")
                { Question.q0 = Question.q2; }
                if (comboBox1.Text == "全球历史")
                { Question.q0 = Question.q3; }
                new Form2().Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"..\..\..\Resources\1.png");
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox1.BackgroundImage = Image.FromFile(@"..\..\..\Resources\login.jpg");
                MessageBox.Show("登录成功！", "提示");
            }
        }
    }

    public class Question
    {
        public static string q1 = "Questions4";
        public static string q2 = "Questions5";
        public static string q3 = "Questions6";
        public static string q0;
    }
}
