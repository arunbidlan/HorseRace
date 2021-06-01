using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
   public class Bet   // bet  ]class 
    {
        public int Amount;
        public int HorseNum;
        public Punter Bettor;

        public Bet(int Amount, int HorseNum, Punter Bettor)
        {
            this.Amount = Amount;
            this.HorseNum = HorseNum;
            this.Bettor = Bettor;
        }

        public string GetDescription() // all the messages 
        {
            string description = "";

            if (Amount > 0)
            {
                description = string.Format("{0} bets {1} on Horse #{2}",
                    Bettor.Name, Amount, HorseNum);
            }
            else
            {
                description = string.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return description;
        }

        public int Pay(int Winner)
        {
            if (HorseNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
