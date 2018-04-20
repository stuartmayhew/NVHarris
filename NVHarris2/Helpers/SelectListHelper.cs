using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVHarris2.Models;
using System.Data.SqlClient;
namespace NVHarris2.Helpers
{
    public static class SelectListHelper
    {
        public static List<ComboBoxItem> GetEmployeeList()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            ComboBoxItem cbItem = new ComboBoxItem();
            cbItem = new ComboBoxItem();
            cbItem.strValue = "Show All";
            cbItem.key = "Show All Employees";
            items.Add(cbItem);
            string sql = "SELECT EmployeeID,FullName FROM Employee WHERE EmployeeID IN (SELECT empID FROM vw_ChangeLog) ORDER BY FullName ";
            using (clsDataGetter dg = new clsDataGetter(CommonProcs.WCompanyConnStr))
            {
                System.Data.SqlClient.SqlDataReader dr = dg.GetDataReader(sql);
                while (dr.Read())
                {
                    cbItem = new ComboBoxItem();
                    cbItem.strValue = dr[0].ToString();
                    cbItem.key = dr[1].ToString();
                    items.Add(cbItem);
                }
                dg.KillReader(dr);
            }
            return items;
        }


    }


}
