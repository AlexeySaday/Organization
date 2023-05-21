using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organiztion
{
    public partial class Form2 : Form
    {
        public string Data { get; private set; }

        private readonly string Business;

        public Form2(string business)
        {
            InitializeComponent();
            Data = business; 
            Business = business;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var yearStr = "xxxx";
            var mothStr = "xx";
            var dayStr = "xx";
            var timeStr = "xx:xx";

            if (!this.checkBox1.Checked)
            {
                if (!int.TryParse(this.textBox1.Text, out int year) || year < DateTime.Now.Year)
                {
                    MessageBox.Show("Некорректный ввод года!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                else
                {
                    yearStr = textBox1.Text;
                }
            }
            if (!this.checkBox2.Checked)
            {
                if (!int.TryParse(this.textBox2.Text, out int month) || 1 > month || 12 < month)
                {
                    MessageBox.Show("Некорректный ввод месяца!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                else
                {
                    mothStr = textBox2.Text;
                }
            }
            if(!this.checkBox3.Checked)
            {
                if (!int.TryParse(this.textBox3.Text, out int day) || 1 > day || 31 < day)
                {
                    MessageBox.Show("Некорректный ввод дня!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                else
                {
                    dayStr = textBox3.Text;
                }
            }
            if (!this.checkBox4.Checked)
            {
                if (!Regex.IsMatch(textBox4.Text, "^\\d{2}:\\d{2}$") ||
                    (!int.TryParse(textBox4.Text.Split(':').First(), out int hour) || hour < 0 || hour > 23 ||
                    (!int.TryParse(textBox4.Text.Split(':').Last(), out int minute) || minute < 0 || minute > 59)))
                {
                    MessageBox.Show("Некорректный ввод времени!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
                else
                {
                    timeStr = textBox4.Text;
                }
            }
            Data = $"{Business} (Дата:{dayStr}:{mothStr}:{yearStr} и Время:{timeStr})";
            Close();
        }
    }
}
