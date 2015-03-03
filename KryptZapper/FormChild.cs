using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptZapper
{
    public partial class FormChild : Form
    {
        string ext = null; //added for the saveAs
        string justSave = null; //added for the saveAs

        public FormChild()
        {
            InitializeComponent();
        }

        public FormChild(string filename)     //constructor
        {
            InitializeComponent();
            richTextBox1.Text = filename;
            justSave = filename;
        }

        /// <summary>
        /// Saving text in the Child Form
        /// </summary>
        public void saveAs()
        {
            SaveFileDialog saveText = new SaveFileDialog();
            saveText.Filter = "Text Files | *.txt";
            string text = richTextBox1.Text;
            
            if (saveText.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.Stream fileStream = saveText.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();
                justSave = saveText.FileName;
                MessageBox.Show(justSave);
            }
        }

        /// <summary>
        /// When clicking save. test to see if file exists.  If it does overwrite it
        /// otherwise call saveAs.
        /// </summary>
        public void save()

        {
            string text = richTextBox1.Text;
            MessageBox.Show("SaveWasPressed");
            if (System.IO.File.Exists(justSave))
            {
                System.IO.File.WriteAllText(justSave, text);
                MessageBox.Show("FileExists");
                MessageBox.Show(justSave);
            }
            else
            {
                MessageBox.Show("File did not Exist");
                saveAs();
            }
        }


        public void close()
        {
            if (justSave == null)
                saveAs();
            else
                save();
            this.Dispose();
        }
    }
}
