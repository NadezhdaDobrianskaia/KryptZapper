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

/* Purpose: This program allows users to encrypt and decrypt messages composed of text only.
 *          The encrypted data can also be emailed to another user and decrypted at the receiving end.
 * Authors: Nadia Dobrianskaia, Rosanna Wubs, Becky Zhou
 * Prototype Version: 1.0
 * Date: Feb 03, 2015
 */
namespace KryptZapper
{
    public partial class FormParent : Form
    {

        Form thisChild;

        public FormParent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// shows about dialog box that will outline krytzapper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog aboutPage = new AboutDialog();
            if (aboutPage.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("About worked");
            }
        }

        /// <summary>
        /// opens a new mdi child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChild child = new FormChild(); //make a FormChild
            child.MdiParent = this;
            child.Show(); //show the child
        }

        /// <summary>
        /// opens an exisiting text file in a mdi child form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// saves the current mdi child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// casecades MDI child forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// tiles MDI child forms vertically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// tiles MDI child form horizontally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// exits application and prompts user about saving child forms before exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// encrypts the text in the current MDI chiild form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void encrypt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Encrypting document");
            thisChild = this.ActiveMdiChild;
            FormChild child = (FormChild)thisChild;
            child.EncryptChild();
        }

        /// <summary>
        /// will decrypt a message...for now it prints a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decrypt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Decrypting document");
            thisChild = this.ActiveMdiChild;
            FormChild child = (FormChild)thisChild;
            child.DecryptChild();
        }

        /// <summary>
        /// will email an encrypted message...for now it prints a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void email_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Emailing document");
            thisChild = this.ActiveMdiChild;
            FormChild child = (FormChild)thisChild;
            try
            {
                child.EmailChild();
            }
            catch(NullReferenceException nre)
            {
                Console.WriteLine("An exception is caught", nre);
            }
            
        }

        /// <summary>
        /// loads FormParent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormParent_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosingParentForm(object sender, FormClosingEventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// handles toolStrip clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
