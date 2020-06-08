using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bikerace_project
{
    public class Player
    {
        public String Name { get; set; }
        public int Bike { get; set; }
        public int Amount { get; set; }
        public int Budget { get; set; }

        public Player() {
                
        }
        //Paramterized constructor of the class 
       public Player(String name,int bike,int amount,int budget) {
            if (amount <= budget)
            {
                Name = name;
                Bike = bike;
                Amount = amount;
                Budget = budget;
            }
            else {
                MessageBox.Show("You didn't have sufficient Balance ");
            }
        }

        public int result(int winner) {
            if (Bike == winner)
            {
                Budget = Budget + Amount;
            }
            else {
                Budget = Budget - Amount;
            }
            return Budget;
        }



    }
}
