using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bikerace_project
{
    public partial class Form2 : Form
    {
        public int Name1=0,Name2=0,Name3=0;
        public int Bike = 0,Bike1=0, Bike2 = 0, Bike3 = 0, Bike4 = 0;
        public int Bet1 = 0, Bet2 = 0, Bet3 = 0;
        public int BikeWinner=0;
        public int budget1 = 100, budget2 =110 , budget3 =120;
        //array oject of the class
        Player[] player_Task = null;
        //object of class to give the race 
        Race speed = new Race();

        private void ready_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Move the Bikes and find the winner 
            if (bikePB1.Left < 710)
            {
                bikePB1.Left = bikePB1.Left + speed.speed();
            }
            else {
                BikeWinner = 1;
                timer1.Enabled = false;
                resetGame();

            }

            if (BikePB2.Left < 710)
            {
                BikePB2.Left = BikePB2.Left + speed.speed();
            }
            else
            {
                BikeWinner = 2;
                timer1.Enabled = false;
                resetGame();
            }

            if (BikePB3.Left < 710)
            {
                BikePB3.Left = BikePB3.Left + speed.speed();
            }
            else
            {
                BikeWinner = 3;
                timer1.Enabled = false;
                resetGame();
            }

            if (BikePB4.Left < 710)
            {
                BikePB4.Left = BikePB4.Left + speed.speed();
            }
            else
            {
                BikeWinner = 4;
                
                timer1.Enabled = false;
                resetGame();
            }



            

        }

        public void resetGame() {
            //if player one participate in the bet 
            if (Bike1>0) {
                if (!player_Task[0].Name.Equals(""))
                {
                    budget1 = player_Task[0].result(BikeWinner);
                    sukhi_pl.Text = "Sukhi has " + budget1;

                }
            }
            //if player two participate in the bet 
            if (Bike2>0) {
                if (!player_Task[1].Name.Equals(""))
                {
                    budget2 = player_Task[1].result(BikeWinner);
                    robi_pl.Text = "Robi has " + budget2;
                }
            }

            //if player three participate in the bet 
            if (Bike3>0) {

                if (!player_Task[2].Name.Equals(""))
                {
                    budget3 = player_Task[2].result(BikeWinner);
                    pawan_pl.Text = "Pawan has " + budget3;
                }
            }

            //show the winner bike 
            MessageBox.Show("Winner Bike is "+BikeWinner);
            //reset the player name 
            Name1 = 0;
            Name2 = 0;
            Name3 = 0;
            //reset the bikes
            Bike1 = 0;
            Bike2 = 0;
            Bike3 = 0;
            Bike4 = 0;
            //reset the bet amount
            Bike = 0;Bet1 = 0;Bet2 = 0;Bet3 = 0;
            BikeWinner = 0;
            //reset the images of bike 
            bikePB1.Left = 0;
            BikePB2.Left = 0;
            BikePB3.Left = 0;
            BikePB4.Left = 0;
            //reset the chart of better 
            bike1.Checked = false; bike2.Checked = false; bike3.Checked = false; bike4.Checked = false;
            sukhi_pl.Checked = false;robi_pl.Checked = false;pawan_pl.Checked = false;
            bet_textbox.Text = "";
            ready_btn.Enabled = false;
            player_Task = new Player[3];
            sukhi_mes.Text= "Sukhi has bet this on this Bike";
            robi_mess.Text = "Robi has bet this on this Bike";
            pawan_mess.Text = "Pawan has bet this on this Bike";
        }
        

        private void robi_pl_CheckedChanged(object sender, EventArgs e)
        {
            if (robi_pl.Checked == true)
            {
                Name2 = 1;
            }
        }

        public Form2()
        {
            InitializeComponent();
            player_Task = new Player[3];
        }

        private void pawan_pl_CheckedChanged(object sender, EventArgs e)
        {
            if (pawan_pl.Checked == true)
            {
                Name3 = 1;
            }

        }

        private void lock_btn_Click(object sender, EventArgs e)
        {
            //set the board to display which player how much set the amount on which bike in the race
            if (Name1 == 1 && Bike > 0 && Bike < 5) {
                //when first player interested into the bet 
                if (Convert.ToInt32(bet_textbox.Text) < budget1 && Convert.ToInt32(bet_textbox.Text) <= 50)
                {
                    player_Task[0] = new Player("Sukhi", Bike, Convert.ToInt32(bet_textbox.Text), budget1);
                    Bike1 = Bike;
                    Bet1 = Convert.ToInt32(bet_textbox.Text);
                    sukhi_mes.Text = "Sukhi select " + Bike + " with " + Bet1;
                    //start the race
                    ready_btn.Enabled = true;
                    Name1 = 0;
                }
                else {
                    MessageBox.Show("Amount must be les then 50 ");
                }
                

            } if (Name2 == 1 && Bike > 0 && Bike < 5) {
                //when 2nd player interested into the bet 
          
                if (Convert.ToInt32(bet_textbox.Text) < budget2 && Convert.ToInt32(bet_textbox.Text) <=50)
                {
                    player_Task[1] = new Player("robi", Bike, Convert.ToInt32(bet_textbox.Text), budget2);
                    Bike2 = Bike;
                    Bet2 = Convert.ToInt32(bet_textbox.Text);

                    robi_mess.Text = "robi select " + Bike + " with " + Bet2;
                    ready_btn.Enabled = true;
                    Name2 = 0;
                }
                else
                {
                    MessageBox.Show("Amount must be les then 50 ");
                }
               
            }
             if (Name3 == 1 && Bike > 0 && Bike < 5) {
                //when 3rd player interested into the bet 
                if (Convert.ToInt32(bet_textbox.Text) < budget3 && Convert.ToInt32(bet_textbox.Text) <=50)
                {
                    player_Task[2] = new Player("Pawan", Bike, Convert.ToInt32(bet_textbox.Text), budget3);
                    Bike3 = Bike;
                    Bet3 = Convert.ToInt32(bet_textbox.Text);

                    pawan_mess.Text = "Pawan select " + Bike + " with " + Bet3;
                    ready_btn.Enabled = true;
                    Name3 = 0;
                }
                else
                {
                    MessageBox.Show("Amount must be les then 50 ");
                }



            }
            if(Name1==0 && Name2 == 0 && Name3 == 0 && Bike==0) {
                MessageBox.Show("Select the Player and Bike to set the Bet then you can start the race");
            }
            Bike = 0;
        }

        private void bike1_CheckedChanged(object sender, EventArgs e)
        {
            if (bike1.Checked==true) {
                Bike = 1;
            }
        }

        private void bike2_CheckedChanged(object sender, EventArgs e)
        {
            if (bike2.Checked == true)
            {
                Bike = 2;
            }
        }

        private void bike3_CheckedChanged(object sender, EventArgs e)
        {
            if (bike3.Checked == true)
            {
                Bike = 3;
            }
        }

        private void bike4_CheckedChanged(object sender, EventArgs e)
        {
            if (bike4.Checked == true)
            {
                Bike = 4;
            }
        }

        private void sukhi_pl_CheckedChanged(object sender, EventArgs e)
        {
            if (sukhi_pl.Checked==true) {
                Name1 = 1;
            }
        }
    }
}
