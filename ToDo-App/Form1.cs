using Organiztion;
using System; 
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ToDo_App
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
            string path = Directory.GetCurrentDirectory() + @"\..\..\" + "Data.txt";
            FileStream filestream ;
            try
            {
                filestream = new FileStream(path, FileMode.Open);
            }
            catch (Exception)
            {
                MessageBox.Show("Информация удалена!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamReader reader = new StreamReader(filestream);
            while (reader.Peek() > 0)
            {
                List.Items.Add(reader.ReadLine());
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(richTextBox1.Text) || String.IsNullOrWhiteSpace(richTextBox1.Text)))
            {

                List.Items.Add(richTextBox1.Text);
                string path = Directory.GetCurrentDirectory() + @"\..\..\"+"Data.txt";
                FileStream filestream ;
                if (File.Exists(path))
                 filestream = new FileStream(path, FileMode.Append);
                else
                {
                    MessageBox.Show("Файл удален!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             
                StreamWriter writer = new StreamWriter(filestream);
                writer.WriteLine(richTextBox1.Text);
                writer.Close();
            }

            else
            {
                MessageBox.Show("Путой ввод!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            richTextBox1.Text = String.Empty;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            if (List.SelectedItem != null)
            {
                EditForm editForm = new EditForm(List.SelectedItem.ToString());
                editForm.ShowDialog();
                if (!String.IsNullOrEmpty(editForm.EditedItem))
                {
                    List.Items[List.SelectedIndex] = editForm.EditedItem;
                    UpdateFile();
                }
            }
        }

        private void UpdateFile()
        {
            string path = Directory.GetCurrentDirectory() + @"\..\..\" + "Data.txt";
            File.WriteAllLines(path, List.Items.Cast<string>());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (List.SelectedItem != null)
            {
                List.Items.Remove(List.SelectedItem);
                UpdateFile();
            }
        } 

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortList();
        }

        private void SortList()
        {
            List.Sorted = true;
            UpdateFile();
            List.Sorted = false;
        }
    }
}
