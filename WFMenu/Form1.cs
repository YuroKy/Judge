using Judge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Judge.Checkers;

namespace WFMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task executing = new Task(() =>
            {
                string root = "E:\\Judge\\";
                FileFactory factory = new FileFactory("E:\\Judge\\");

                string code = textBox1.Text;
                string language = comboBox1.Text;
                Submit submit = new Submit(code, language);
                Problem sum = new Problem();
                sum.Tests = new List<TestCase> {
                new TestCase("5 5", "10"),
                new TestCase("3 9", "12"),
                new TestCase("3 6", "9"),
                new TestCase("5 5", "10"),
                new TestCase("3 9", "12"),
                new TestCase("3 6", "9")
            };
                IChecker checker = new StringChecker();
                Judger judger = new Judger(factory,checker);
                judger.Judge(submit, new ExecutingOptions(5, 1000));

                string current = "";
                this.textBox2.Text = "";
                foreach (var result in judger.Assessment(judger.BuildedFileName + ".exe", sum))
                {
                    current = String.Format("\nStatus:{0}     Memory:{1}     Execution Time:{2}", result.Verdict, result.Memory.ToString(), result.Time.ToString()); // 
                    this.textBox2.Text = textBox2.Text + current;
                }
            });
            executing.Start();

        }
    }
}
