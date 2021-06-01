using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HorseRace;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        PunterFactory pFactory = new PunterFactory();
        Punter Arun;
        Horse[] Horses = new Horse[2];

        [TestMethod]
        public void TestWinnerOutcome()
        {
            Horse.StartingPosition1 = 0;
            Horse.RacetrackLength1 = 50;
            int BettingAmount = 45;
            int HorseNumber = 1;
            int expectedWin = 90;
            int expectedLose = 0;
            Horses[0] = new Horse() { HorsePictureBox = null };
            Horses[1] = new Horse() { HorsePictureBox = null };
            Arun = pFactory.getPunter("Arun", null, null);
            Arun.Cash = BettingAmount;
            Arun.PlaceBet((int)BettingAmount, HorseNumber);

            bool nowin = true;
            int win = -1;
            while (nowin)
            {
                for (int i = 0; i < Horses.Length; i++)
                {
                    if (Horse.Run(Horses[i]))
                    {
                        win = i + 1;
                        Arun.Collect(win);
                        nowin = false;

                    }
                }
            }
            if (Arun.bet.HorseNum == win)
            {
                Assert.AreEqual(expectedWin, Arun.Cash, "Account not credited correctly");
            }
            if (Arun.bet.HorseNum != win)
            {
                Assert.AreEqual(expectedLose, Arun.Cash, "Account not debited correctly");

            }
        }
    }

}
