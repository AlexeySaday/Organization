using System;
using System.Linq;
using System.Windows.Forms; 

namespace Organiztion
{
    public partial class EditForm : Form
    {
        public string EditedItem { get; private set; }

        public EditForm(string currentItem)
        {
            InitializeComponent();
            EditedItem = currentItem;
            textBox1.Text = currentItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditedItem = textBox1.Text;
            Close();
        } 

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Split('(').Last().Contains("Время") && textBox1.Text.Split('(').Last().StartsWith("Дата"))
            {
                EditedItem = textBox1.Text;
                MessageBox.Show("Дата уже заполнена!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else
            { 
                var form2 = new Form2(textBox1.Text); 
                form2.ShowDialog(); 
                EditedItem = form2.Data; 
            } 
            Close();
        }
    } 
}
