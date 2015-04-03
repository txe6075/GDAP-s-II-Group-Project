using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        const int sizeX = 30;
        const int sizeY = 17;
        CustomPictureBox[,] cpb = new CustomPictureBox[sizeX, sizeY]; 

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    cpb[i, j] = new CustomPictureBox();
                    cpb[i, j].i = i;
                    cpb[i, j].j = j;
                    cpb[i, j].Size = new Size(32, 32);
                    cpb[i, j].Location = new Point((i * 32), (j * 32));
                    panel1.Controls.Add(cpb[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if(cpb[i, j].Image != Image.FromFile("Tile.png"))
                    {
                        cpb[i, j].Image = Image.FromFile("Tile.png");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // create a new file
            StreamWriter output = null;

            try
            {
                // open the file by creating StreamWriter object
                // output = new StreamWriter(fileName, true); // appends to existing file
                output = new StreamWriter(textBox1.Text + ".txt");

                // loop to write data to the file

                for (int j = 0; j < sizeY; j++)
                {
                    string toWrite = "";
                    for (int i = 0; i < sizeX; i++)
                    {
                        if (i != 0)
                            toWrite += " ";

                        toWrite += (cpb[i, j].tileNum);
                    }
                    output.WriteLine(toWrite);
                }
            }
            catch (IOException ioe){
                var result = MessageBox.Show("Invalid inputs", "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question);
            }
            finally
            {
                output.Close();  // close regardless of exceptions
            }
        }

    }


    public class CustomPictureBox : PictureBox
    {
        public int tileNum;
        public int i { get; set; }
        public int j { get; set; }

        public CustomPictureBox()
        {
            tileNum = 0;
            Visible = true;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.Zoom;
            Click += new System.EventHandler(Click_Event);
            Image = Image.FromFile("Tile.png");
        }
        private void Click_Event(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            switch(tileNum)
            {
                case 0:
                    tileNum = 1;
                    Image = Image.FromFile("Tile1.png");
                    break;
                case 1:
                    tileNum = 2;
                    Image = Image.FromFile("Tile2.png");
                    break;
                case 2:
                    tileNum = 0;
                    Image = Image.FromFile("Tile.png");
                    break;
            }
        }
    }
}
