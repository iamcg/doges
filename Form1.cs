using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dugs
{
    public partial class form1 : Form
    {
        Greyhound g1;
        Greyhound g2;
        Greyhound g3;
        Greyhound g4;
        Greyhound[] myDoges;

        Guy m1;
        Guy m2;
        Guy m3;
        Guy[] myGuys;

        int minBet = 5;
        int theWinner = 0;

        public form1()
        {
            InitializeComponent();
            minBet = 5;
            g1 = new Greyhound() { dogNo = 1, name = "Brutus1", StartingPosition = pictureBox2.Location, RaceTrackLength = (pictureBox1.Width - pictureBox2.Width), MyPictureBox = pictureBox2 };
            g2 = new Greyhound() { dogNo = 2, name = "Rover2", StartingPosition = pictureBox3.Location, RaceTrackLength = (pictureBox1.Width - pictureBox2.Width), MyPictureBox = pictureBox3 };
            g3 = new Greyhound() { dogNo = 3, name = "Pedro3", StartingPosition = pictureBox4.Location, RaceTrackLength = (pictureBox1.Width - pictureBox2.Width), MyPictureBox = pictureBox4 };
            g4 = new Greyhound() { dogNo = 4, name = "Cadger4", StartingPosition = pictureBox5.Location, RaceTrackLength = (pictureBox1.Width - pictureBox2.Width), MyPictureBox = pictureBox5 };

            myDoges = new Greyhound[4];
            myDoges[0] = g1;
            myDoges[1] = g2;
            myDoges[2] = g3;
            myDoges[3] = g4;

            m1 = new Guy() { Cash = 100, Mylabel = label3, MyRadioButton = joeButton, Name = "Joe" };
            m2 = new Guy() { Cash = 100, Mylabel = label4, MyRadioButton = bobButton, Name = "Bob" };
            m3 = new Guy() { Cash = 100, Mylabel = label5, MyRadioButton = alButton, Name = "Al" };
           

            myGuys = new Guy[3];
            myGuys[0] = m1;
            myGuys[1] = m2;
            myGuys[2] = m3;

          
        }


        private void button1_Click(object sender, EventArgs e)
        {
     //       if(label3.Text.Contains("placed") || label4.Text.Contains("placed") || label5.Text.Contains("placed")){
       //         MessageBox.Show("At least one bet must be placed");
         //   }
           // else{
            timer1.Start();
            //}
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Greyhound g in myDoges)
            {
                g.TakeStartingPosition();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = false;

            for (int i = 0; i < myDoges.Length; i++)
            {
                if (myDoges[i].Run() == true)
                {
                    timer1.Stop();
                    theWinner = myDoges[i].dogNo;
                    System.Diagnostics.Debug.WriteLine("Winner is " + myDoges[i].name);
                    MessageBox.Show("Dog " + myDoges[i].name + " wins");
                    foreach (Greyhound g in myDoges)
                    {
                        g.TakeStartingPosition();
                    }
                    button1.Enabled = true;
                    foreach (Guy guy in myGuys)
                    {
                        guy.MyRadioButton.Checked = false;
                        guy.Mylabel.Text = guy.Name + " has not placed a bet";
                        guy.MyBet.PayOut(theWinner);
                        //guy.Collect
                        System.Diagnostics.Debug.WriteLine(guy.Name + " now has " + guy.Cash);
                    }
                }
                // else{g

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              for(int i = 0; i < myGuys.Length; i++){
                  int stake = Convert.ToInt32(numericUpDown1.Value);
                  int dogNog = Convert.ToInt32(numericUpDown2.Value);
                if(label6.Text == "name"){
                    MessageBox.Show("Please select a guy");
                }
                else if (myGuys[i].Cash < stake || myGuys[i].Cash == 0){
                    String tmpName = myGuys[i].Name;
                    int tmpCash = myGuys[i].Cash;
                    MessageBox.Show(tmpName + " only has " + tmpCash);
                }
                else if (myGuys[i].MyRadioButton.Checked == true){
                    myGuys[i].PlaceBet(stake, dogNog);
                    myGuys[i].UpdateLabels();
                }
                }
              
        
    }

        private void joeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (joeButton.Checked)
            {
                label6.Text = "Joe";
                numericUpDown1.Maximum = m1.Cash;
            }
        }

        private void bobButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bobButton.Checked)
            {
                label6.Text = "Bob";
                numericUpDown1.Maximum = m2.Cash;
            }
        }

        private void alButton_CheckedChanged(object sender, EventArgs e)
        {
            if (alButton.Checked)
            {
                label6.Text = "Al";
                numericUpDown1.Maximum = m3.Cash;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }

}
