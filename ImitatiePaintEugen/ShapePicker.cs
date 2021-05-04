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
    public partial class ShapePicker : Form
    {
        public ShapePicker()
        {
            InitializeComponent();
        }

        private void ShapePicker_Load(object sender, EventArgs e)
        {
            button1.Image = new Bitmap("imaginiForme/circle.png");
            button2.Image = new Bitmap("imaginiForme/rectangle.png");
            button3.Image = new Bitmap("imaginiForme/free-form.png");
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Form1.formaSpeciala = 3; // free-form
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Form1.formaSpeciala = 2; // dreptunghi
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Form1.formaSpeciala = 1; // cerc
            this.Close();
        }
    }
}
