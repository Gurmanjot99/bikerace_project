using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bikerace_project
{
    public class Race
    {
        Random rd = new Random();
        // method to speed up  the bike speed to win into the race
        public int speed() {
            int spd = rd.Next(1, 40);
            return spd;
        }
    }
}
