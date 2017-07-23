using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Standardized_Exam_System
{
    public partial class Form2 : Form
    {
        string qq = Question.q0;
        Boolean b1_flag = true;
        int YiZuo = 0, DaDui = 0;

        int rowIndex;
        OleDbConnection con;
        DataSet ds;
        OleDbDataAdapter adapter;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "简体中文";
            string database = @"..\..\..\Resources\d1.mdb";
            string conStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            con = new OleDbConnection(conStr + database);
            con.Open();
            
            string sql = "SELECT * FROM " + qq;
            adapter = new OleDbDataAdapter(sql, con);
            ds = new DataSet();
            adapter.Fill(ds, qq);
            rowIndex = 0;
            labelQues.Text = ds.Tables[qq].Rows[rowIndex][1].ToString();
            radioButton1.Text = ds.Tables[qq].Rows[rowIndex][2].ToString();
            radioButton2.Text = ds.Tables[qq].Rows[rowIndex][3].ToString();
            radioButton3.Text = ds.Tables[qq].Rows[rowIndex][4].ToString();
            radioButton4.Text = ds.Tables[qq].Rows[rowIndex][5].ToString();

            labelFen.Text = "0";
            labelMiao.Text = "0";
            labelFenLast.Text = "10";
            labelMiaoLast.Text = "0";
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int min = Int32.Parse(labelFen.Text);
            int sec = Int32.Parse(labelMiao.Text);
            sec++;
            if (sec == 60)
            {
                min++;
                labelFen.Text = min.ToString();
                labelMiao.Text = "0";
                if (min == 10)
                {
                    timer1.Enabled = false;
                    groupBox3.Enabled = false;
                    button1.Enabled = false;
                    pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\0.png");
                    MessageBox.Show("考试时间到！请停止答题\n你的得分是: " + labelScore.Text, "提示");
                    return;
                }
            }
            sec = sec % 60;
            labelMiao.Text = sec.ToString();
            labelFenLast.Text = (9 - min).ToString();
            labelMiaoLast.Text = (60 - sec).ToString();

            if (min == 0)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\100.png"); }
            if (min == 1)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\90.png"); }
            if (min == 2)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\80.png"); }
            if (min == 3)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\70.png"); }
            if (min == 4)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\60.png"); }
            if (min == 5)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\50.png"); }
            if (min == 6)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\40.png"); }
            if (min == 7)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\30.png"); }
            if (min == 8)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\20.png"); }
            if (min == 9)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\10.png"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false; button2.Text = "开始计时";
                groupBox3.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true; button2.Text = "暂停计时";
                button1.Enabled = true;
                if (button1.Text.ToString().Equals("提交本题"))
                {
                    groupBox3.Enabled = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Bitcoin");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bitcoin.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("项目名：C#实现标准化考试系统\n作者：李根\n学号：20151308062", "关于作者");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b1_flag == true) // 按钮为提交时的方法
            {
                // 判断是否正确
                if (radioButton1.Checked)
                {
                    MessageBox.Show("你的选择是: A, 正确答案是: " + ds.Tables[qq].Rows[rowIndex][6].ToString());
                    if (ds.Tables[qq].Rows[rowIndex][6].ToString().Equals("A"))
                    { DaDui++; }
                }
                else if (radioButton2.Checked)
                {
                    MessageBox.Show("你的选择是: B, 正确答案是: " + ds.Tables[qq].Rows[rowIndex][6].ToString());
                    if (ds.Tables[qq].Rows[rowIndex][6].ToString().Equals("B"))
                    { DaDui++; }
                }
                else if (radioButton3.Checked)
                {
                    MessageBox.Show("你的选择是: C, 正确答案是: " + ds.Tables[qq].Rows[rowIndex][6].ToString());
                    if (ds.Tables[qq].Rows[rowIndex][6].ToString().Equals("C"))
                    { DaDui++; }
                }
                else if (radioButton4.Checked)
                {
                    MessageBox.Show("你的选择是: D, 正确答案是: " + ds.Tables[qq].Rows[rowIndex][6].ToString());
                    if (ds.Tables[qq].Rows[rowIndex][6].ToString().Equals("D"))
                    { DaDui++; }
                }
                else
                {
                    MessageBox.Show("你还没有选择！");
                    return;
                }
                YiZuo++;
                labelYiZuo.Text = (YiZuo).ToString();
                labelShengYu.Text = (10 - YiZuo).ToString();
                labelRightAnswer.Text = (DaDui).ToString();
                labelScore.Text = (DaDui*10).ToString();
                button1.Text = "下一题";
                b1_flag = false;
                groupBox3.Enabled = false;
            }
            else // 按钮为下一题时的方法
            {
                groupBox3.Enabled = true;
                rowIndex++;
                if (rowIndex == 10)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("考试结束，你的得分是" + labelScore.Text);
                    Close();
                }
                else
                {
                    labelQues.Text = ds.Tables[qq].Rows[rowIndex][1].ToString();
                    radioButton1.Text = ds.Tables[qq].Rows[rowIndex][2].ToString();
                    radioButton2.Text = ds.Tables[qq].Rows[rowIndex][3].ToString();
                    radioButton3.Text = ds.Tables[qq].Rows[rowIndex][4].ToString();
                    radioButton4.Text = ds.Tables[qq].Rows[rowIndex][5].ToString();
                    button1.Text = "提交本题";
                    b1_flag = true;
                }
            }

        }
    }
}
