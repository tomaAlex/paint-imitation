using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImitatiePaintEugen
{
    public partial class ImageOptions : Form
    {
        private Form1 mainForm = null;

        public ImageOptions(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void ImageOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form1.pictureWidth = int.Parse(textBox1.Text);
                Form1.pictureHeight = int.Parse(textBox2.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("format incorect...");
            }
            Form1.pictureBoxDinamic.Width = Form1.pictureWidth;
            Form1.pictureBoxDinamic.Height = Form1.pictureHeight;
            this.mainForm.clearGraphic();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void ImageOptions_Load(object sender, EventArgs e)
        {
            MessageBox.Show("apasa 'ENTER' pentru finalizare");
        }
    }
}
