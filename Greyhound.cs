using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace dugs
{
    public class Greyhound
    {
        public Point StartingPosition;
        public int RaceTrackLength;
        public PictureBox MyPictureBox;
        public int Location = 0;
        public Random Randomizer;
        public string name;
        public int dogNo;

        public bool Run()
        {
            Randomizer = new Random();
            Location = StartingPosition.X;
            if (MyPictureBox.Location.X <= RaceTrackLength)
            {
                Point p = MyPictureBox.Location;
                System.Threading.Thread.Sleep(5);
                int distance = Randomizer.Next(1, 5);
                p.X += distance;
                Location += distance;
                
                MyPictureBox.Location = p;
                
                //System.Diagnostics.Debug.WriteLine("name" + name + "location: " + MyPictureBox.Location + " Distance: " + distance + " Length: " + RaceTrackLength + "start" + Location);
                return false;
            }
            return true;
            
    
        }

        public void TakeStartingPosition()
        {
            MyPictureBox.Location = StartingPosition;
        }

    }
}
