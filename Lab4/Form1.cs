﻿using System;
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
using Lab5;

namespace Lab4
{
    public partial class Form1 : Form
    {
        List<string> word_list = new List<string>();
        List<string> result_list = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            word_list.Clear();
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
                    if (!word_list.Contains(strs[i]) && (strs[i] != " ") && (strs[i].Length > 0))
                        word_list.Add(strs[i]);
                }
            }
            extime.Stop();
            textBox1.Text = extime.ElapsedMilliseconds.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch extime = new Stopwatch();
            extime.Start();
            Random rnd = new Random();
            bool flag = false;
            button2.BackColor = Color.FromArgb(rnd.Next(0, 255),rnd.Next(0, 255), rnd.Next(0, 255));
            button2.ForeColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            if (radioButton1.Checked == true)
            {
                for (int i = 0; i < word_list.Count; i++)
                {
                    if (word_list[i].Contains(textBox3.Text))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            else
            {
                int max_dist = int.Parse(textBox5.Text);
                for (int i = 0; i < word_list.Count; i++)
                {
                    if (LevDistance.VagnerCalculation(word_list[i], textBox3.Text) <= max_dist)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag && !listBox1.Items.Contains(textBox3.Text))
            {
                listBox1.BeginUpdate();
                listBox1.Items.Add(textBox3.Text);
                listBox1.EndUpdate();
            }
            extime.Stop();
            textBox4.Text = extime.ElapsedMilliseconds.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label6.Visible = true;
                textBox5.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label6.Visible = false;
                textBox5.Visible = false;
            }
        }
    }
}