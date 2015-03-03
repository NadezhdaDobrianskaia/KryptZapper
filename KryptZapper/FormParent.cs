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
    public partial class FormParent : Form
    {
        string ext = null;
        string justSave = null;
        public FormParent()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog aboutPage = new AboutDialog();
            if (aboutPage.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("About worked");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild child = new FormChild(); //make a FormChild
            child.MdiParent = this;
            child.Show(); //show the child
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openFileDialogParent.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String filename = openFileDialogParent.FileName;
                string text = System.IO.File.ReadAllText(filename);
                FormChild child = new FormChild(text);
                child.MdiParent = this;
                child.Show(); //show the child    
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveText = new SaveFileDialog();
            /*if (saveText.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ext = System.IO.Path.GetExtension(saveText.FileName);

                string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
                System.IO.File.WriteAllText(@"C:Libraries\Documents\WriteText.txt", text);
                justSave = saveText.FileName;
            }*/
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            System.IO.File.WriteAllText(@"C:\BCIT-Nadia\WriteText.txt", text);
            MessageBox.Show("SaveWorked");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}
