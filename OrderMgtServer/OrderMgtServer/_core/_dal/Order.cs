using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OrderMgtServer._core._dal
{
    public class Order
    {
        #region 取得訂單資料 Order
        /// <summary> 
        /// 取得訂單資料 Order
        /// </summary>
        public static DataTable GetOrder()
        {
            DataTable dt = null;
            try
            {
                SQLHandler sql = new SQLHandler();
                sql._sql = @"
select o.*,c.CompanyName,EmpName=e.FirstName+e.LastName 
from Orders o
Left Join Customers c on c.CustomerID=o.CustomerID 
Left Join Employees e on e.EmployeeID=o.EmployeeID 
order by o.OrderDate";
                sql._type = CommandType.Text;
                dt = sql.ExecuteGetDataTable();
            }
            catch (Exception ex)
            {
                _core.Common.WriteLogFile(string.Format("(Order.GetOrder)Error={0} ", ex.Message.ToString()));
            }
            return dt;
        }

        #endregion
    }
}