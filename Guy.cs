using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dugs
{
    public class Guy
    {
        public String Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label Mylabel;

        public void UpdateLabels()
        {
            Mylabel.Text = Name + " bets " + MyBet.Amount + " on " + MyBet.Dog;
        }

        public void ClearBet()
        {
            //meh stub
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            MyBet = new Bet() { Bettor = this, Amount = Amount, Dog = Dog };
            //System.Diagnostics.Debug.WriteLine("Amount is " + Amount + " Dog is " + Dog + " Bettor is " + Name);
            //System.Diagnostics.Debug.WriteLine(MyBet);
            return true;
        }

        public void Collect(int Winner)
        {
            this.Cash = this.Cash + MyBet.PayOut(Winner);
            System.Diagnostics.Debug.WriteLine(this.Cash + "   " + MyBet.PayOut(Winner));
        }
    }

    }

