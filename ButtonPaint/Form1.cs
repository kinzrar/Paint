using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
namespace Paint
{
    public partial class Form1 : Form
    {
        Button button_counting;
        public Form1() { InitializeComponent();  }

        struct BrushButton  
        {
            public static int x = 0;   public static int y = 0;
            public static int squeezedX = 0; public static int squeezedY = 0;
            public static bool isReleas = true;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            BrushButton.squeezedX = e.X;  BrushButton.squeezedY = e.Y;  BrushButton.isReleas = false;

            button_counting = new Button
            {
                Location = new Point(BrushButton.squeezedX, BrushButton.squeezedY),
                Size = new Size(BrushButton.x, BrushButton.y)
            };

            this.Controls.Add(button_counting);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)  {    BrushButton.isReleas = true; }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!BrushButton.isReleas)
            {
                int new_loc_x = 0;
                int new_loc_y = 0;

                if (button_counting != null)
                {

                    if (e.X - BrushButton.squeezedX > 0)
                    {
                        BrushButton.x = e.X - BrushButton.squeezedX;
                        new_loc_x = BrushButton.squeezedX;
                    }
                    else

                    {
                        new_loc_x = e.X;
                        BrushButton.x = Math.Abs(BrushButton.squeezedX - e.X);
                    }

                    if (e.Y - BrushButton.squeezedY > 0)
                    {
                        BrushButton.y = e.Y - BrushButton.squeezedY;
                        new_loc_y = BrushButton.squeezedY;
                    }

                    else
                    {
                        new_loc_y = e.Y;
                        BrushButton.y = Math.Abs(BrushButton.squeezedY - e.Y);
                    }
                }
                button_counting.Size = new Size(BrushButton.x, BrushButton.y);
                button_counting.Location = new Point(new_loc_x, new_loc_y);
            }
        }
    }
}
