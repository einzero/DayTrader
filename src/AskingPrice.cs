using System;
using System.Collections.Generic;

namespace DayTrader
{
    class Asking
    {
        public int Price;
        public int Quantity;
    };

    class AskingPrice
    {
        public AskingPrice(DateTime time)
        {
            Time = time;
        }

        public DateTime Time;
        public float Nav;
        public List<Asking> Sell = new List<Asking>();
        public List<Asking> Buy = new List<Asking>();
    }
}
