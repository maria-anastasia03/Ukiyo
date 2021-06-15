using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class CheckOut
    {
        ReservationClass c = new ReservationClass();

        public string cekout()
        {
            string teks = c.LengthStay;
            bool isParsable = GetIsParsable(out int number, teks);
            int price;
            string expanse;

            if (isParsable = true)
            {
                price = Convert.ToInt32(teks);
            }
                
            else
                return "LengthStay has to be an integer";

            if (c.TypeRoom == "Standard")
            {
                price = 1000000 * number;
            }

            else if (c.TypeRoom == "Deluxe")
            {
                price = 2000000 * number;
            }

            else if (c.TypeRoom == "Suite")
            {
                price = 3000000 * number;
            }

            else if (c.TypeRoom == "Executive")
            {
                price = 4000000 * number;
            }

            else
            {
                price = 5000000 * number;
            }

            expanse = Convert.ToString(price);
            return expanse;
        }

        private static bool GetIsParsable(out int number, string teks)
        {
            return Int32.TryParse(teks, out number);
        }
    }
    
}
