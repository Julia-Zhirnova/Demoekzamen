using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Приятный_шелест.Enitities
{
    partial class AGENT
    {
        public byte[] Logo
        {
            get
            {
                if(!string.IsNullOrEmpty(PHOTOPATH) && !string.IsNullOrWhiteSpace(PHOTOPATH))
                {
                    return File.ReadAllBytes(Environment.CurrentDirectory + PHOTOPATH.Trim());
                }
                else
                {
                    return File.ReadAllBytes(Environment.CurrentDirectory + @"\agents\picture.png");
                }
            }
        }
        public int SaleCount
        {
            get
            {
               return SALECONTRACT.Count(c => c.DATE.Date.Year == DateTime.Now.Date.Year);
            }
        }
        public int PriorityCount
        {
            get
            {
                var primority = AGENTHISTORY.LastOrDefault();
                if(primority != null)
                {
                    return primority.PRIORITY;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int Discount
        {
            get
            {
                int sale = Convert.ToInt32(SALECONTRACT.Sum(c => c.GOOD.MINPRICE * c.COUNT));
                if (sale >= 0 && sale < 10000)
                {
                    return 0; 
                }
                else if (sale > 10000 && sale < 50000)
                {
                    return 5;
                }
                else if (sale > 50000 && sale < 150000)
                {
                    return 10;
                }
                else if (sale > 150000 && sale < 500000)
                {
                    return 20;
                }
                else
                {
                    return 25;
                }
            }
        }
        public string Background
        {
            get
            {
                if(Discount >= 25)
                {
                    return "Green";
                }
                else
                {
                    return "White";
                }
            }
        }
        public string DirectorFullName
        {
            get
            {
                return DIRECTORLASTNAME + " " + DIRECTORFIRSTNAME + " " + DIRECTORMIDDLENAME;
            }
        }
    }
}
