using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography; //provides variety of tools to help with encryption and with decryption
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace KryptZapper
{
    public partial class ChildFormPicture : Form
    {
        // private Bitmap BitMapImage;
        private Image NewImage;
        private Image OpenedImage;
        int load = 0;
        string ext = null;
        string justSave = null;

        //---------------------RSA fields
        private RSACryptoServiceProvider rsa;
        String MyEncryptedText = "";
        private static string _privateKey;
        private static string _publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        //-------------------end RSA fields

        public ChildFormPicture(Image i, string w)     //constructor
        {
            InitializeComponent();
            OpenedImage = i;
            pictureBox1.Image = i;
            load = 1;
            justSave = w;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
         //   base.OnPaint(e);
            //if (load == 0)
                //e.Graphics.DrawImage(BitMapImage, new Point(0, 0));
           // else
           //     e.Graphics.DrawImage(OpenedImage, new Point(0, 0));
        }

        /*
        public void saveAs()
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            ImageFormat format = ImageFormat.Png;
            saveImage.Filter = "Images|*.png;*.bmp;*.jpg";
            if (saveImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ext = System.IO.Path.GetExtension(saveImage.FileName);
                using (Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height))
                {
                    pictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                    pictureBox.Image.Save("ext");
                    bmp.Save(saveImage.FileName);
                    justSave = saveImage.FileName;
                }
                pictureBox.Image = OpenedImage;
            }
        }

        public void save()
        {
            if (System.IO.File.Exists(justSave)) 
            { 
                MessageBox.Show("FileExists");   
                using (Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height))
                {
                    pictureBox.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                    pictureBox.Image.Save(justSave);
                    bmp.Save(justSave);
                }
            pictureBox.Image = OpenedImage;
            }
            else
                saveAs();
        }

        private void FormChild_Load(object sender, EventArgs e)
        {

        }
         
        public void FormChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogSaveChild close = new DialogSaveChild();

            if (close.ShowDialog() == DialogResult.OK)
            {
                if (justSave == null)
                    saveAs();
                else
                    save();
            }
        }

         
    }

         */
        /// <summary>
        /// Closing a child picture form
        /// </summary>
        public void close()
        {
           // if (justSave == null)
               // saveAs();
            //else
               // save();
            this.Dispose();
        }

        ///////--------------------------RSA Encryption / Decryption


        public string ImageToBase64(Image image,  System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public Bitmap ConvertByteToImage(byte[] bytes)
        {
            return (new Bitmap(Image.FromStream(new MemoryStream(bytes))));
        }

        public byte[] ConvertImageToByte(Image My_Image)
        {
            MemoryStream m1 = new MemoryStream();
            new Bitmap(My_Image).Save(m1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] header = new byte[] { 255, 216 };
            header = m1.ToArray();
            return (header);
        }

        public string encrypttwo(string imageToEncrypt)
        {
            string hex = imageToEncrypt;
            char[] ar = hex.ToCharArray();
            String c = "";
            //progressBar1.Maximum = ar.Length;
            for (int i = 0; i < ar.Length; i++)
            {
                Application.DoEvents();
             //   progressBar1.Value = i;
                if (c == "")
                    c = c + RSAalgorithm.BigMod(ar[i], 7,33);//RSA_E, n);
                else
                    c = c + "-" + RSAalgorithm.BigMod(ar[i], 7,33);//RSA_E, n);
            }
            return c;
        } 


        private void button1_Click(object sender, EventArgs e)
        {
            var rsa = new RSACryptoServiceProvider();
             Image myImage = pictureBox1.Image;
             //byte[] myBytes = ConvertImageToByte(myImage);
             //_privateKey = rsa.ToXmlString(true);
            // _publicKey = rsa.ToXmlString(false);
             string imageString = ImageToBase64(myImage, System.Drawing.Imaging.ImageFormat.Jpeg);
             String c = encrypttwo(imageString);
             MessageBox.Show(imageString);
             MessageBox.Show(c);
             string d = decrypttwo(c);
             byte[] db = library.DecodeHex(c);
             if (db != null) {
                 Bitmap myBitMap = library.ConvertByteToImage(db);
             } 
            MessageBox.Show(d);

            //Image second = Base64ToImage(d);
            pictureBox1.Image = null;//second;
            

        }
       // int prime1 = 3, prime2 = 11;
        //int n = RSAalgorithm.n_value(prime1,prime2);

        public string decrypttwo(String imageToDecrypt)
        {
            char[] ar = imageToDecrypt.ToCharArray();
            int i = 0, j = 0;
            string c = "", dc = "";
            //progressBar2.Maximum = ar.Length;
            try
            {
                for (; i < ar.Length; i++)
                {
                    Application.DoEvents();
                    c = "";
              //      progressBar2.Value = i;
                    for (j = i; ar[j] != '-'; j++)
                        c = c + ar[j];
                    i = j;
                    try
                    {
                        int xx = Convert.ToInt16(c);
                        dc = dc + ((char)RSAalgorithm.BigMod(xx, 3, 33)).ToString();//d, n)).ToString();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Can't convert char to int");
                    }
                    
                }
            }
            catch (Exception ex) { }
            return dc;
        } 


        /// <summary>
        /// encrypts messages
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Encrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            try
            {

                //var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(_publicKey);
                var dataToEncrypt = _encoder.GetBytes(data);
                var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
                var length = encryptedByteArray.Count();
                var item = 0;
                var sb = new StringBuilder();
            
                foreach (var x in encryptedByteArray)
                {
                    item++;
                    sb.Append(x);

                    if (item < length)
                        sb.Append(",");
                }

                return sb.ToString();

            }
            catch (CryptographicException exe)
            {
                MessageBox.Show("did not work");
                return null;
            }
            //return null; 
            
        }

        /// <summary>
        /// grabs text from MDI child and stores it in a string
        /// </summary>
        public void EncryptChild(object sender, EventArgs e)
        {

           // if (nadiaUserControlPicture.ButtonEncryptedClick)
            //  {
          //      nadiaUserControl1_NadiaEncryption_Click(sender, e);
          //  }
            /* string text = richTextBox1.Text;
             MyEncryptedText = Encrypt(text);
             richTextBox1.Text = MyEncryptedText;*/
        }

        public void DecryptChild(object sender, EventArgs e)
        {
           // if (nadiaUserControlPicture.ButtonDecryptedClick)
                  nadiaUserControl1_NadiaDecryption_Click(sender, e);
            /*string text = richTextBox1.Text;
            MyEncryptedText = Decrypt(text);
            richTextBox1.Text = MyEncryptedText;
            */
        }
        private string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        private void nadiaUserControl1_NadiaDecryption_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Problem method 2");

        }

        private void nadiaUserControl1_NadiaEncryption_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Problem method 1");
           

        }

        private void nadiaUserControlPicture_NadiaEncryption_Click(object sender, EventArgs e)
        {
            // _privateKey = nadiaUserControl1.PrivateKey;
            _publicKey = nadiaUserControlPicture.PublicKey;
            MessageBox.Show(_publicKey);
            Image myImage = pictureBox1.Image;
            string imageString = ImageToBase64(myImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            string text = imageString;
            //MessageBox.Show("RSA // Text to encrypt: " + text);
            MyEncryptedText = Encrypt(text);
            Image second = null;//Base64ToImage(MyEncryptedText);
            pictureBox1.Image = second;
            //richTextBox1.Text = MyEncryptedText;
            // richTextBox1.ReadOnly = true;
        }

        private void nadiaUserControlPicture_NadiaDecryption_Click(object sender, EventArgs e)
        {
            //DecryptChild();
           // _privateKey = nadiaUserControlPicture.PrivateKey;
            _privateKey = nadiaUserControlPicture.PrivateKey;
                Image myImage = pictureBox1.Image;
            string text =  ImageToBase64(myImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            MyEncryptedText = Decrypt(text);
            Image second = Base64ToImage(MyEncryptedText);
            pictureBox1.Image = second;


        }


        //------------end RSA algorythm

        class library
        {
            public static byte[] DecodeHex(string hextext)
            {
                String[] arr = hextext.Split('-');
                byte[] array = new byte[arr.Length];

                try
                {
                    for (int i = 0; i < arr.Length; i++)
                        array[i] = Convert.ToByte(arr[i],16);
                    return array;
                }
                catch (FormatException e)
                {
                    MessageBox.Show(String.Format("The format of '{0}' is invalid.", arr));
                }

                return null;
                    
                
               
            }

            public static bool IsPrime(int number)
            {
                if (number < 2) return false;
                if (number % 2 == 0) return (number == 2);
                int root = (int)Math.Sqrt((double)number);
                for (int i = 3; i <= root; i += 2)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }

            public static Bitmap ConvertByteToImage(byte[] bytes)
            {
                //return (new Bitmap(Image.FromStream(new MemoryStream(bytes))));
                MemoryStream ms = new MemoryStream(bytes);
                try {
                Image returnImage = Image.FromStream(ms);
                return new Bitmap(returnImage);
                 }catch(Exception exe){
                 MessageBox.Show("Problem");
                }
                return null;
            }

            public static byte[] ConvertImageToByte(Image My_Image)
            {
                MemoryStream m1 = new MemoryStream();
                new Bitmap(My_Image).Save(m1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] header = new byte[] { 255, 216 };
                header = m1.ToArray();
                return (header);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        class RSAalgorithm
        {
            public static long square(long a)
            {
                return (a * a);
            }

            public static long BigMod(int b, int p, int m) //b^p%m=?
            {
                if (p == 0)
                    return 1;
                else if (p % 2 == 0)
                    return square(BigMod(b, p / 2, m)) % m;
                else
                    return ((b % m) * BigMod(b, p - 1, m)) % m;
            }

            public static int n_value(int prime1, int prime2)
            {
                return (prime1 * prime2);
            }

            public static int cal_phi(int prime1, int prime2)
            {
                return ((prime1 - 1) * (prime2 - 1));
            }

            public static Int32 cal_privateKey(int phi, int e, int n)
            {
                int d = 0;
                int RES = 0;

                for (d = 1; ; d++)
                {
                    RES = (d * e) % phi;
                    if (RES == 1) break;
                }
                return d;
            }
        }

    }
}
