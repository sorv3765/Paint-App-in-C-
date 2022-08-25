using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rivas_Assign4
{
    public partial class Color : Form
    {
        Graphics g;                                       //class for methods of drawing lines
        Pen p = new Pen(System.Drawing.Color.Black, 1);   //like a brush with color and the width of the brush
        Point startPoint = new Point(0, 0);               //define begin point
        Point endPoint = new Point(0, 0);                 //define the end point
        int a = 0;

       // bool drawing = false;

        public Color()
        {
            InitializeComponent();
        }


        //Color Dialog click button
        private void colorButton_Click(object sender, EventArgs e)
        {
            //show the color dialog
            DialogResult result = colorDialog1.ShowDialog();

            // see if user pressed ok.
            if(result == DialogResult.OK)
            {
                //Set pen to the selected color
                p.Color = colorDialog1.Color;
            }
        }


        //this is an event handling when you click the mouse down the LINE will be drawn
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            if (e.Button == MouseButtons.Left)
                a = 1;
        }      
        
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            a = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (a == 1)                          //while the mouse is down
            {
                endPoint = e.Location;           //when this is at the end of a moving line putting new location
                g = this.CreateGraphics();                //will tell to draw on this form
                g.DrawLine(p, startPoint, endPoint);    //will draw a line with pen from starting to ending point
            }

            startPoint = endPoint;        //new point will be the endpoint as new line will begin
        }

        //Change drawing pen color to selected color in panel
        private void Change_Color(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            p.Color = pb.BackColor;
        }

        //When pencil option is selected, pen thckness will be set to corresponding UpDown value
        private void pencilRadioButton_CheckedChanged(object sender, EventArgs e)
        {            
            p.Width = (float)pencilThickness.Value;            
        }
        
        private void pencilThickness_ValueChanged(object sender, EventArgs e)
        {
            //If pencil option is still selected...
            if (pencilRadioButton.Checked)
                p.Width = (float)pencilThickness.Value;  //change pencil thickness
        }

        //When paint brush option is selected, pen thckness will be set to corresponding UpDown value
        private void brushRadioButton_CheckedChanged(object sender, EventArgs e)
        {            
            p.Width = (float)brushThickness.Value;
        }

        private void brushThickness_ValueChanged(object sender, EventArgs e)
        {
            //If paint brush option is still selected...
            if (brushRadioButton.Checked)                
                p.Width = (float)brushThickness.Value;  //change paint brush thickness
        }

        //Set paint color to background color
        private void eraserRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            p.Color = BackColor;
            p.Width = 18;
        }        
    }    
}
