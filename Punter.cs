using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    public abstract class Punter // punter abstract class 
    {
        public string Name;
        public Bet bet;
        public int Cash;
        public bool busted;
        public Label statusLabel, MaximumBet;

        public abstract void setPunterName();

        public Punter(Bet bet, Label MaximumBet, int Cash, Label statusLabel)   // punter class 
        {
            this.bet = bet;
            this.Cash = Cash;
            this.MaximumBet = MaximumBet;
            this.statusLabel = statusLabel;
            if (this.statusLabel != null)
                this.statusLabel.ForeColor = System.Drawing.Color.Black;

        }

        public void UpdateLabels()  // update labels 
        {
            if (bet == null)
            {
                statusLabel.Text = String.Format("{0} hasn't placed any bets", Name); // message box 
            }

            else
            {
                statusLabel.Text = bet.GetDescription();
            }
            if (Cash == 0)
            {
                busted = true;
                statusLabel.Text = String.Format("BUSTED!");
                statusLabel.ForeColor = System.Drawing.Color.Red;

            }
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", Cash);
        }


        public void ClearBet()  // clear all bet amoun t 
        { 
            bet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int Horse)
        {
            if (Amount <= Cash)
            {
                bet = new Bet(Amount, Horse, this);
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            Cash += bet.Pay(Winner);
        }



    }
}
