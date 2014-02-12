using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dugs
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            return Bettor.ToString();
            
        }

        public int PayOut(int Winner)
        {
            System.Diagnostics.Debug.WriteLine(Winner);
            if (this.Dog == Winner)
            {
                System.Diagnostics.Debug.WriteLine("bettor " + Bettor.Name + " " + (Bettor.Cash + Amount).ToString());
                Bettor.Cash = Bettor.Cash + Amount;
                return Bettor.Cash + Amount;
            }
            else if (this.Dog != Winner)
            {
                System.Diagnostics.Debug.WriteLine("bettor " + Bettor.Name + " " + (Bettor.Cash - Amount).ToString());
                Bettor.Cash = Bettor.Cash - Amount;
                return Bettor.Cash - Amount;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("ppppp" + Winner.ToString());
                return 99999999;
            }

        }
    }
}
