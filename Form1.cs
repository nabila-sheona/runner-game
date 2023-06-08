using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace runner_game
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpspeed = 12;
        int force = 15;
        int sscore = 0;
        int ddistance = 0;
        int obstaclespeed = 5;
        Random random = new Random();
        int position;
        bool isgameover = false;
        public Form1()
        {
            InitializeComponent();
            // Create a SoundPlayer instance
            SoundPlayer player = new SoundPlayer();

            // Set the path to your background music file
            player.SoundLocation = "D:\\freshman summer\\runner game\\Resources\\Aurora_-_Runaway_CeeNaija.com_.wav";

            // Play the music
            player.PlayLooping();
            gamereset();

        }

        private void timeevent(object sender, EventArgs e)
        {
            avatar.Top += jumpspeed;
            obstacle1.Left -= obstaclespeed;
            obstacle2.Left -= obstaclespeed;
            score.Text = "Score: " + sscore;




            if (obstacle1.Left < -100)
            {

               
                obstacle1.Left = random.Next(300, 1200);
                // pipebottom.Top += 30;
                //pipebottom.Top -= 50;
                //&& pipespeed>13

                sscore++;
                score.Text = "Score: " + sscore;
            }

           

            if (obstacle2.Left < -130)
            {
               
                obstacle2.Left = obstacle1.Left+ random.Next(300, 1200);
                sscore++;
                score.Text = "Score: " + sscore;

            }


            ddistance++;
            distance.Text = "Distance: " + ddistance;

            if (jumping==true && force < 0)
            {
                jumping = false;
            }

            if (jumping==true)
            {
                jumpspeed = -12;
                force -= 1;
            }
            else
            {
                
                jumpspeed = 12;
            }
            
            if(avatar.Top>229  && jumping == false)
            {
                force = 25;
                avatar.Top = 230;
                jumpspeed = 0;
            }
    

            if (avatar.Bounds.IntersectsWith(obstacle1.Bounds) || avatar.Bounds.IntersectsWith(obstacle2.Bounds))
            {

                // we stop the timer
                gametimer.Stop();
                score.Text = "Score: " + sscore;
                // change the t rex image to the dead one
                avatar.Image = Properties.Resources.dead;
                // show press r to restart on the score text label
                score.Text += "  Press R to restart";
                isgameover = true;
            }


            if (ddistance > 1200)
            {
                obstaclespeed = 8;
            }
            else if (ddistance > 2200)
            {
                obstaclespeed=10;
            }
            

            
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Space && jumping==false)
            {
                jumping = true;
            }
            

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            
            if (jumping==true)
            {
                jumping = false;
            }


            if (e.KeyCode == Keys.R && isgameover==true)
            {
                gamereset();
            }


        }
        private void gamereset()
        {
           
            force = 15;
            jumpspeed = 0;
            jumping = false;
            sscore = 0;
            ddistance = 0;
            obstaclespeed = 5;
            score.Text = "Score: " + sscore;
            distance.Text = "Distance: 0";
            avatar.Image = Properties.Resources.running;
            isgameover = false;
            avatar.Top = 230;

           
                    // generate a random number in the position integer between 600 and 1000
                    position =random.Next(500,800);
                    // change the obstacles left position to a random location begining of the game
                    obstacle1.Left =position;
            obstacle2.Left = random.Next(600, 1000);               
            
            gametimer.Start();
        }

        private void score_Click(object sender, EventArgs e)
        {

        }
    }

}
