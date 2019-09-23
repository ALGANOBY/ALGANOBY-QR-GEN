using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MessagingToolkit;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec.Data;

namespace ALGANOBY_QR_GEN
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager a = MaterialSkin.MaterialSkinManager.Instance;
            a.AddFormToManage(this);
            a.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            a.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green900, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.Amber900, MaterialSkin.Accent.Purple700, MaterialSkin.TextShade.WHITE);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == string.Empty)
            {
                MessageBox.Show("Text Is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Choose { QR Resolution... 1,2,3.etc... }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessagingToolkit.QRCode.Codec.QRCodeEncoder en = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                    en.QRCodeScale = Convert.ToInt32(comboBox1.Text);
                    pictureBox1.Image = en.Encode(materialSingleLineTextField1.Text);
                }
            }
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Not Found Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SaveFileDialog save = new SaveFileDialog() { Filter = "Jpeg|*.jpg", Title = "SAVE QR IMAGE...." })
                {
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap bit = (Bitmap)pictureBox1.Image;
                        bit.Save(save.FileName);
                        MessageBox.Show("Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }
            }
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog() { Title = "CHOOSE IMAGE QR",Filter="Image(*.png, *.png)|*.png;*.jpg" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Load(open.FileName);
                }
            }
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Not Found Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessagingToolkit.QRCode.Codec.QRCodeDecoder de = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                materialSingleLineTextField2.Text = de.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            }
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
