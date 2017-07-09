using Judge;
using Judge.Checkers;
using Judge.Executors;
using Judge.Logger;
using Judge.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace JudgeTool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public string root = "E:\\Judge\\";
        public JudgeProcess jp;

        public MainWindow()
        {
            InitializeComponent();
            choseList.SelectedIndex = 0;
            jp = new JudgeProcess(root);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resultList.Items.Clear();

            string code = new TextRange(content.Document.ContentStart, content.Document.ContentEnd).Text;
            Submit submit = new Submit(code, choseList.SelectionBoxItem.ToString());

            Problem sum = new Problem(new ExecutingOptions(TimeSpan.FromSeconds(5), new MemorySpan(256 * 1024 * 1024)));
            sum.Tests = new List<TestCase> {
                new TestCase("5 5", "10"),
                new TestCase("3 9", "12"),
                new TestCase("3 6", "9"),
                new TestCase("5 5", "10"),
                new TestCase("3 9", "12"),
                new TestCase("3 6", "9")
            };

            jp.Run(sum, submit);

            foreach (var result in jp.GetProtocolCurrentTest().Results.Values)
            {
                string info = String.Format("Verdict:{0}\tMemory:{1}KB\tExecuting Time:{2}s\tExitCode:{3}", result.Verdict,
                    result.UsedMemory.TotalKilobytes, result.UsedTime.TotalSeconds, result.ExitCode);
                resultList.Items.Add(info);
            }

        }
    }
}
