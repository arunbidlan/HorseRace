using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRace
{
    public class PunterFactory   // punter factory class 
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "arun":
                    p = new Arun(null, MaximumBet, 50, bet);  // Player
                    break;

                case "yogesh":
                    p = new Yogesh(null, MaximumBet, 50, bet);
                    break;

                case "shivam":
                    p = new Shivam(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.setPunterName();
            return p;
        }
        public class Arun : Punter  // player calass in punter 
        {
            public Arun(Bet MyBet, Label MaximumBet, int Cash, Label MyLabel) : base(MyBet, MaximumBet, Cash, MyLabel)
            {
            }

            public override void setPunterName()
            {
                Name = "Arun";
            }
        }
        public class Yogesh : Punter
        {
            public Yogesh(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
            {
            }

            public override void setPunterName()
            {
                Name = "Yogesh";
            }
        }
        public class Shivam : Punter
        {
            public Shivam(Bet bet, Label MaximumBet, int Cash, Label label) : base(bet, MaximumBet, Cash, label)
            {
            }

            public override void setPunterName()
            {
                Name = "Shivam";
            }
        }
    }
}