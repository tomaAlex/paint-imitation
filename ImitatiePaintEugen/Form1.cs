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
    public partial class Form1 : Form
    {

        public static int pictureWidth = 494, pictureHeight = 450;

        public Form1()
        {
            InitializeComponent();

        }

        int buton_selectat = 0;
        ImageOptions imageOptions;
        public static bool imageOptionsPornit = false;
        float razaPencil = 0.25f;
        bool seDeseneaza = false;
        int mouseX, mouseY, mouseX_anterior, mouseY_anterior;
        float xStanga, yStanga, xDreapta, yDreapta;
        bool arieSelectata = false;
        Color pencilColor = Color.Red;
        public static Graphics g;
        public static Graphics reprezentareCerc;
        Button detectCombinationOfKeys = new Button();
        public static PictureBox pictureBoxDinamic = new PictureBox();
        Timer timerSecondClear = new Timer();
        int Form1Width = 656;
        int Form1Height = 558;
        Bitmap bitmapToOpen;
        bool bitmapHaveToBeOpened = false;
        bool listeningForClcik = false;
        public static int formaSpeciala = 0;
        float xEllipse_stanga, yEllipse_stanga, xEllipse_dreapta, yEllipse_dreapta;
        float xRectangle_stanga, yRectangle_stanga, xRectangle_dreapta, yRectangle_dreapta;

        public void clearGraphic()
        {
            int deltaWidth = pictureBox1.Width - pictureWidth;
            int deltaHeight = pictureBox1.Height - pictureHeight;

            Form1Width -= deltaWidth;
            Form1Height -= deltaHeight;

            this.Width = Form1Width;
            this.Height = Form1Height;

            pictureBox1.Width = pictureWidth;
            pictureBox1.Height = pictureHeight;

            textBox2.Top = pictureBox1.Height + 5 + pictureBox1.Location.Y;

            pictureBoxDinamic.Visible = false;
            g = pictureBoxDinamic.CreateGraphics();
            g.FillRectangle(Brushes.White, 0, 0, pictureWidth, pictureHeight);
            pictureBoxDinamic.Visible = true;

            g = pictureBox1.CreateGraphics();
            g.FillRectangle(Brushes.White, 0, 0, pictureWidth, pictureHeight);
            timerSecondClear.Enabled = true;
        }

        private void timerSecondClear_Tick(object sender, EventArgs e)
        {
            clearGraphic();
            timerSecondClear.Enabled = false;
            //g = Graphics.FromImage(bitmapToOpen);
            if (bitmapHaveToBeOpened == true)
            {
                pictureBox1.Image = bitmapToOpen;
                bitmapHaveToBeOpened = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timerSecondClear.Interval = 50;
            timerSecondClear.Enabled = false;
            timerSecondClear.Tick += timerSecondClear_Tick;

            pictureBoxDinamic.Top = pictureBox1.Top;
            pictureBoxDinamic.Left = pictureBox1.Left;
            pictureBoxDinamic.Visible = true;

            pictureBox2.BackColor = Color.LightGray;
            reprezentareCerc = pictureBox2.CreateGraphics();
            Pen pen = new Pen(Brushes.DarkBlue);
            reprezentareCerc.DrawEllipse(pen, new RectangleF((pictureBox2.Width - razaPencil) / 2, (pictureBox2.Height - razaPencil) / 2, razaPencil, razaPencil));

            textBox1.Text = razaPencil.ToString();
            button6.BackColor = pencilColor;
            g = pictureBox1.CreateGraphics();
            button1.Image = new Bitmap("imaginiButoane/11_UNSELECTED.jpg");
            button2.Image = new Bitmap("imaginiButoane/12_UNSELECTED.jpg");
            button3.Image = new Bitmap("imaginiButoane/21_UNSELECTED.jpg");
            button4.Image = new Bitmap("imaginiButoane/22_UNSELECTED.jpg");
            button5.Image = new Bitmap("imaginiButoane/31_UNSELECTED.jpg");

            this.Controls.Add(pictureBoxDinamic);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // selecteaza buton Free-Form Select
            button1.Image = new Bitmap("imaginiButoane/11_SELECTED.jpg");
            button2.Image = new Bitmap("imaginiButoane/12_UNSELECTED.jpg");
            button3.Image = new Bitmap("imaginiButoane/21_UNSELECTED.jpg");
            button4.Image = new Bitmap("imaginiButoane/22_UNSELECTED.jpg");
            button5.Image = new Bitmap("imaginiButoane/31_UNSELECTED.jpg");
            buton_selectat = 1;
            ShapePicker shapePicker = new ShapePicker();
            shapePicker.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // selecteaza buton Select
            button1.Image = new Bitmap("imaginiButoane/11_UNSELECTED.jpg");
            button2.Image = new Bitmap("imaginiButoane/12_SELECTED.jpg");
            button3.Image = new Bitmap("imaginiButoane/21_UNSELECTED.jpg");
            button4.Image = new Bitmap("imaginiButoane/22_UNSELECTED.jpg");
            button5.Image = new Bitmap("imaginiButoane/31_UNSELECTED.jpg");
            buton_selectat = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // selectaza buton Eraser
            button1.Image = new Bitmap("imaginiButoane/11_UNSELECTED.jpg");
            button2.Image = new Bitmap("imaginiButoane/12_UNSELECTED.jpg");
            button3.Image = new Bitmap("imaginiButoane/21_SELECTED.jpg");
            button4.Image = new Bitmap("imaginiButoane/22_UNSELECTED.jpg");
            button5.Image = new Bitmap("imaginiButoane/31_UNSELECTED.jpg");
            buton_selectat = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // selecteaza buton Fill With Color
            button1.Image = new Bitmap("imaginiButoane/11_UNSELECTED.jpg");
            button2.Image = new Bitmap("imaginiButoane/12_UNSELECTED.jpg");
            button3.Image = new Bitmap("imaginiButoane/21_UNSELECTED.jpg");
            button4.Image = new Bitmap("imaginiButoane/22_SELECTED.jpg");
            button5.Image = new Bitmap("imaginiButoane/31_UNSELECTED.jpg");
            buton_selectat = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // selecteaza buton Pencil
            button1.Image = new Bitmap("imaginiButoane/11_UNSELECTED.jpg");
            button2.Image = new Bitmap("imaginiButoane/12_UNSELECTED.jpg");
            button3.Image = new Bitmap("imaginiButoane/21_UNSELECTED.jpg");
            button4.Image = new Bitmap("imaginiButoane/22_UNSELECTED.jpg");
            button5.Image = new Bitmap("imaginiButoane/31_SELECTED.jpg");
            buton_selectat = 5;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // se creeaza un nou proiect
            imageOptions = new ImageOptions(this);
            imageOptions.Show();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // se incearca executarea unei actiuni pe pictureBox1
            if (buton_selectat == 5 && seDeseneaza==true)
            {
                Brush brush = new SolidBrush(pencilColor);
                g.FillEllipse(brush, e.X - razaPencil/2, e.Y - razaPencil/2, razaPencil, razaPencil);
            }
            if (buton_selectat == 4)
            {
                Brush brush = new SolidBrush(pencilColor);
                g.FillRectangle(brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
        }

        void maresteRaza()
        {
            razaPencil += 0.25f;
            textBox1.Text = razaPencil.ToString();
            Pen pen = new Pen(Brushes.DarkBlue);
            reprezentareCerc.FillRectangle(Brushes.LightGray, new RectangleF(0, 0, pictureBox2.Width, pictureBox2.Height));
            reprezentareCerc.DrawEllipse(pen, new RectangleF((pictureBox2.Width - razaPencil) / 2, (pictureBox2.Height - razaPencil) / 2, razaPencil, razaPencil));
        }

        void micsoreazaRaza()
        {
            if (razaPencil - 0.25 >= 0)
            {
                razaPencil -= 0.25f;
                textBox1.Text = razaPencil.ToString();
                Pen pen = new Pen(Brushes.DarkBlue);
                reprezentareCerc.FillRectangle(Brushes.LightGray, new RectangleF(0, 0, pictureBox2.Width, pictureBox2.Height));
                reprezentareCerc.DrawEllipse(pen, new RectangleF((pictureBox2.Width - razaPencil) / 2, (pictureBox2.Height - razaPencil) / 2, razaPencil, razaPencil));
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (seDeseneaza == true)
            {
                mouseX_anterior = mouseX;
                mouseY_anterior = mouseY;
                mouseX = e.X;
                mouseY = e.Y;
                Pen pen;
                if (buton_selectat == 5)
                {
                    // se incearca desenarea cu pencil
                    pen = new Pen(pencilColor, razaPencil);
                    g.DrawLine(pen, mouseX_anterior, mouseY_anterior, mouseX, mouseY);
                }
                else if (buton_selectat == 3)
                {
                    // se incearca stergerea
                    pen = new Pen(Brushes.White, razaPencil);
                    g.DrawLine(pen, mouseX_anterior, mouseY_anterior, mouseX, mouseY);
                }
            }
            textBox2.Text = e.X.ToString() + ", " + e.Y.ToString() + " px";
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (buton_selectat == 3 || buton_selectat == 5)
            {
                // se incearca desenarea pe graficul pcitureBox1
                seDeseneaza = true;
                mouseX = e.X;
                mouseY = e.Y;
                mouseX_anterior = mouseX;
                mouseY_anterior = mouseY;
            }
            else if (buton_selectat == 2)
            {
                if (listeningForClcik == false)
                {
                    // slecteaza subgraficul graficului proiect
                    arieSelectata = true;
                    xStanga = e.X;
                    yStanga = e.Y;
                }
                else
                {
                    // aici trebuie sa fie lipita portiunea de imagine care a fost decupata
                    g.DrawImage(pictureBoxDinamic.Image, new Point(e.X, e.Y));
                }
            }
            else if (buton_selectat == 1)
            {
                if (formaSpeciala == 1)
                {
                    xEllipse_stanga = e.X;
                    yEllipse_stanga = e.Y;
                }
                else if (formaSpeciala == 2)
                {
                    xRectangle_stanga = e.X;
                    yRectangle_stanga = e.Y;
                }
                else if (formaSpeciala == 3)
                {
                    formaSpeciala = 0;
                }
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // incercarea desenarii s-a oprit
            seDeseneaza = false;
            if(arieSelectata)
            {
                xDreapta = e.X;
                yDreapta = e.Y;
                //Bitmap bitmap = new Bitmap();
                arieSelectata = false;
                Bitmap bitmap = DrawControlToBitmap(pictureBox1);
                float widthOfRectangle = Math.Abs(xDreapta - xStanga);
                float heightOfRectangle = Math.Abs(yDreapta - yStanga);
                Rectangle rectangle = new Rectangle((int)xStanga, (int)yStanga, (int)widthOfRectangle, (int)heightOfRectangle);
                System.Drawing.Imaging.PixelFormat format = bitmap.PixelFormat;
                Bitmap cloneBitmap = bitmap.Clone(rectangle, format);
                g.FillRectangle(Brushes.White, rectangle);
                pictureBoxDinamic.Visible = true;
                pictureBoxDinamic.Location = rectangle.Location;
                pictureBoxDinamic.Width = (int)widthOfRectangle;
                pictureBoxDinamic.Height = (int)heightOfRectangle;
                pictureBoxDinamic.Image = cloneBitmap;
                //g.DrawImage(pictureBoxDinamic.Image, pictureBoxDinamic.Location);
                listeningForClcik = true;
            }
            if (formaSpeciala == 1)
            {
                xEllipse_dreapta = e.X;
                yEllipse_dreapta = e.Y;
                Pen pen = new Pen(pencilColor, razaPencil);
                g.DrawEllipse(pen, new RectangleF(xEllipse_stanga, yEllipse_stanga, Math.Abs(xEllipse_dreapta - xEllipse_stanga), Math.Abs(yEllipse_dreapta - yEllipse_stanga)));
                formaSpeciala = 0;
            }
            else if (formaSpeciala == 2)
            {
                xRectangle_dreapta = e.X;
                yRectangle_dreapta = e.Y;
                Pen pen = new Pen(pencilColor, razaPencil);
                g.DrawRectangle(pen, new Rectangle((int)xRectangle_stanga, (int)yRectangle_stanga, (int)Math.Abs(xRectangle_stanga - xRectangle_dreapta), (int)Math.Abs(yRectangle_stanga - yRectangle_dreapta)));
                formaSpeciala = 0;
            }
            else if (formaSpeciala == 3)
            {
                formaSpeciala = 0;
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // user alege o culoare
            colorDialog1.ShowDialog();
            pencilColor = colorDialog1.Color;
            button6.BackColor = pencilColor;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // culoare pentru pen
            colorDialog1.ShowDialog();
            pencilColor = colorDialog1.Color;
            button6.BackColor = pencilColor;
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void Button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void Button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void Button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            this.Width = Form1Width;
            this.Height = Form1Height;
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }

        private void FlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // se roteste graficul
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, g);
            bitmap = DrawControlToBitmap(pictureBox1);
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            g.DrawImage(bitmap,0,0);
            //MessageBox.Show("s-a rotit");
        }

        private Bitmap DrawControlToBitmap(Control control)
        {
            if (control == pictureBox1)
            {
                Bitmap bitmap = new Bitmap(control.Width - 2, control.Height - 2);
                Graphics graphics = Graphics.FromImage(bitmap);
                Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
                graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
                return bitmap;
            }
            else
            {
                Bitmap bitmap = new Bitmap(control.Width, control.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
                graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
                return bitmap;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // se salveaza imagine
            Bitmap bitmap = DrawControlToBitmap(pictureBox1);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG File (*.png)|*.png|JPEG File (*.jpeg)|*.jpeg|ICON File (*.ico)|*.ico|BITMAP File (*.bmp)|*.bmp|ALL FILES (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FilterIndex == 1)
                {
                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (dialog.FilterIndex == 2)
                {
                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (dialog.FilterIndex == 3)
                {
                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Icon);
                }
                else if (dialog.FilterIndex == 4)
                {
                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else if (dialog.FilterIndex == 5)
                {
                    bitmap.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            //bitmap.Save("imagine1.png", System.Drawing.Imaging.ImageFormat.Png);
            //System.Diagnostics.Process.Start("imagine1.png");
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // se deschide imagine
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bitmapToOpen = new Bitmap(dialog.FileName);
                pictureWidth = bitmapToOpen.Width;
                pictureHeight = bitmapToOpen.Height;
                //g = Graphics.FromImage(bitmapToOpen);
                bitmapHaveToBeOpened = true;
                clearGraphic();
            }
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox2.Text = "";
            this.Cursor = Cursors.Default;
        }

        private void Button3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyCode == 221) maresteRaza();
            else if ((char)e.KeyCode == 219) micsoreazaRaza();
            //MessageBox.Show(razaPencil.ToString());
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // modifica din tasatura razaPencil
            try
            {
                razaPencil = float.Parse(textBox1.Text);
                Pen pen = new Pen(Brushes.DarkBlue);
                reprezentareCerc.FillRectangle(Brushes.LightGray, new RectangleF(0, 0, pictureBox2.Width, pictureBox2.Height));
                reprezentareCerc.DrawEllipse(pen, new RectangleF((pictureBox2.Width - razaPencil) / 2, (pictureBox2.Height - razaPencil) / 2, razaPencil, razaPencil));
            }
            catch (System.FormatException)
            {
                MessageBox.Show("format incorect...");
            }
        }

        private void RotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearGraphic();
        }

        private void s(object sender, EventArgs e)
        {

        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((char)e.KeyCode == 221) maresteRaza();
            else if ((char)e.KeyCode == 219) micsoreazaRaza();
            if (e.Control && e.KeyCode == Keys.N && e.Shift)
            {
                newToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.C && e.Shift)
            {
                clearGraphic();
            }
            else if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.O && e.Shift)
            {
                OpenToolStripMenuItem_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.R && e.Shift)
            {
                FlipToolStripMenuItem_Click(sender, e);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            // inutil, momentan
        }
    }
}
