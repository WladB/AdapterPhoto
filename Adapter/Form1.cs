using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                BMP bMP = new BmpAdapter(openFileDialog1.FileName);
                saveFileDialog1.ShowDialog();

              if (saveFileDialog1.FileName != "")
                {
                    bMP.ToBmp(saveFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show("Місце для зберігання файлу не обране");
                }
            }
            else {
                MessageBox.Show("Файл для конвертування не обраний");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
            {
            JPEG jpg = new JpegAdapter(openFileDialog1.FileName);
            saveFileDialog1.ShowDialog();
              if (saveFileDialog1.FileName != "")
                {
                    jpg.ToJpeg(saveFileDialog1.FileName);
                }
                else
                {
                        MessageBox.Show("Місце для зберігання файлу не обране");
                }
                }
            else
            {
                MessageBox.Show("Файл для конвертування не обраний");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "openFileDialog1")
            {
            PNG png = new PngAdapter(openFileDialog1.FileName);
            saveFileDialog1.ShowDialog();
              if (saveFileDialog1.FileName != "")
                {
                    png.ToPng(saveFileDialog1.FileName);
                }
                else 
                {
                    MessageBox.Show("Місце для зберігання файлу не обране");
                }
            }
            else
            {
                MessageBox.Show("Файл для конвертування не обраний");
            }
        }
    }
    public class BMP
    {
   
        public virtual void ToBmp(string filePath)
        {
           
        }

    }
    public class JPEG
    {
        public virtual void ToJpeg(string filePath)
        {

        }
    }
    public class PNG
    {
        public virtual void ToPng(string filePath)
        {

        }
    }

    class BmpAdapter : BMP
    {
        private readonly Bitmap File;
        
        public BmpAdapter(string filePath)
        {
            this.File = new Bitmap(filePath);
        }
        public override void ToBmp(string filePath)
        {
            File.Save(filePath, ImageFormat.Bmp);
        }
    }
    class JpegAdapter : JPEG
    {
        private readonly Bitmap File;

        public JpegAdapter(string filePath)
        {
            this.File = new Bitmap(filePath);
        }
        public override void ToJpeg(string filePath)
        {
            File.Save(filePath, ImageFormat.Jpeg);
        }
    }
    class PngAdapter : PNG
    {
        private readonly Bitmap File;

        public PngAdapter(string filePath)
        {
            this.File = new Bitmap(filePath);
        }
        public override void ToPng(string filePath)
        {
            File.Save(filePath, ImageFormat.Png);
        }
    }
}
