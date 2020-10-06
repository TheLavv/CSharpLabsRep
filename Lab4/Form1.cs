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
using System.Diagnostics;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> word_list = new List<string>();
            Stopwatch extime = new Stopwatch();
            string fileContent;
            string filePath;
            string[] strs;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Текстовый файл|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                extime.Start();
                filePath = openFile.FileName;
                textBox2.Text = filePath.Split('\\').Last();
                fileContent = File.ReadAllText(filePath);
                strs = fileContent.Split();
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!word_list.Contains(strs[i]))
                        word_list.Add(strs[i]);
                }
            }
            extime.Stop();
            textBox1.Text = extime.ElapsedMilliseconds.ToString();
        }

    }
}
