using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptZapper
{
    public partial class FormParent : Form
    {

        Form thisChild;  

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
                MessageBox.Show(filename);
                string text = System.IO.File.ReadAllText(filename);
                FormChild child = new FormChild(filename, text); //filename is the path
                child.MdiParent = this;
                child.Text = filename;
                child.Show(); //show the child    
            }
        }


        /// <summary>
        /// When the saveAs.. is clicked from the menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            thisChild = this.ActiveMdiChild;
            if (thisChild != null)
            {
                FormChild child = (FormChild)thisChild;
                child.saveAs();
            }
            else
                MessageBox.Show("Must Have at least one file opened");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisChild = this.ActiveMdiChild;
            if (thisChild != null)
            {
                FormChild child = (FormChild)thisChild;
                child.save();
            }
            else
                MessageBox.Show("Must Have at least one file opened");
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thisChild = this.ActiveMdiChild;
            while (thisChild != null)
            {
                FormChild child = (FormChild)thisChild;
                DialogSaveChild close = new DialogSaveChild();
                if (close.ShowDialog() == DialogResult.OK)
                {
                    child.close();
                }
                else
                {
                    child.Dispose();
                }
                thisChild = this.ActiveMdiChild;
            }
            
            Application.Exit();
        }

        string Encrypted;
        private void encrypt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Encrypting document");
            thisChild = this.ActiveMdiChild;
            FormChild child = (FormChild)thisChild;
            child.EncryptChild();


        }

        private void toolStripDecryptButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Decrypting document");
            thisChild = this.ActiveMdiChild;
            FormChild child = (FormChild)thisChild;
            child.DecryptChild();
        }

        private void toolStripEmailButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Emailing document");
        }

        private void FormParent_Load(object sender, EventArgs e)
        {

        }

        private void ClosingParentForm(object sender, FormClosingEventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripDecryptButton_Click_1(object sender, EventArgs e)
        {
            {
                MessageBox.Show("Decrypting document");
                thisChild = this.ActiveMdiChild;
                FormChild child = (FormChild)thisChild;
                child.DecryptChild();
            }
        }
    }
}
