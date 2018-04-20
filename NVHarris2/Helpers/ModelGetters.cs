using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVHarris2.Models;

namespace NVHarris2.Helpers
{
    public static class ModelGetters
    {
        public static List<Contact> GetContacts()
        {
            string sql = "SELECT * FROM Contacts ";
            return new ReaderToModel<Contact>().CreateList(sql);
        }
    }
}
