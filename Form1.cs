using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    public partial class Form1 : Form
    {
        Horse[] Horses = new Horse[4];  // horse class four horses

        PunterFactory pFactory = new PunterFactory(); // all players from punter factory class

        Punter[] punters = new Punter[3]; // punter class for clear , update and player dertails 
        public Form1()
        {
            InitializeComponent();
            SetupRaceTrack(); // track
        }

        private void SetupRaceTrack()
        {
            Horse.StartingPosition1 = Horse1.Right - racetrack.Left;
            Horse.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            Horses[0] = new Horse() { HorsePictureBox = Horse1 };
            Horses[1] = new Horse() { HorsePictureBox = Horse2 };
            Horses[2] = new Horse() { HorsePictureBox = Horse3 };
            Horses[3] = new Horse() { HorsePictureBox = Horse4 };

            punters[0] = pFactory.getPunter("Arun", MaximumBet, txtArun); //getting Arun object from factory class
            punters[1] = pFactory.getPunter("Yogesh", MaximumBet, txtYogesh); //getting Yogesh object from factory class
            punters[2] = pFactory.getPunter("Shivam", MaximumBet, txtShivam); //getting Shivam object from factory class


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels(); // update details 
            }
        }

        private void btnrace_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningHorse;
            btnrace.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < Horses.Length; i++)
                {
                    if (Horse.Run(Horses[i]))
                    {
                        winningHorse = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - Horse #" + winningHorse); // message box show that you win 
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningHorse); //give double amount to all who've won or deduce betted amount
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Horse Horse in Horses)
                        {
                            Horse.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  //stop punters from betting if they run out of cash
                string message = "Do you want to Play Again?";
                string title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    Close();
                }

            }
            btnrace.Enabled = true; //enable race button 
        }

        private void btnBets_Click(object sender, EventArgs e)  // bet button 
        {
            int PunterNum = 0;  // radio button check that 

            if (rbtnArun.Checked)
            {
                PunterNum = 0;
            }
            if (rbtnYogesh.Checked)
            {
                PunterNum = 1;
            }
            if (rbtnShivam.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)BettingAmount.Value, (int)HNumber.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void rbtnArun_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[0].Cash);  //  maximun bet amount 
        }

        private void rbtnYogesh_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[1].Cash);
        }

        private void rbtnShivam_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[2].Cash);
        }
        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = string.Format("Maximum Bet: ${0}", Cash);
        }

    }
}
