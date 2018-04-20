using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVHarris.Models;

namespace NVHarris.Helpers
{
    public static class ModelGetters
    {
        public static List<Contact> GetContacts()
        {
            string sql = "SELECT * FROM Contacts ";
            return new ReaderToModel<Contact>().CreateList(sql);
        }

        public static List<Portfolio> GetPortfolioList()
        {
            string sql = "SELECT * FROM Portfolio ";
            return new ReaderToModel<Portfolio>().CreateList(sql);
        }

        public static Portfolio GetPortfolio(int PortID)
        {
            string sql = "SELECT * FROM Portfolio WHERE PortID = " + PortID;
            return new ReaderToModel<Portfolio>().CreateModel(sql);
        }
    }
}
