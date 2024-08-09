using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMONIC.Airlines
{
    public partial class Users
    {
        public int Age
        {
            get
            {
                if (Birthdate != null) return DateTime.Now.Year - Birthdate.Value.Year;
                return 0;
            }
        }
    }
    public partial class Schedules
    {
        public decimal BusinessPrice => EconomyPrice * 1.35M;
        public decimal FirstClassPrice => BusinessPrice * 1.30M;
    }
    
}
