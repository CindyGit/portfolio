using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderMgtServer
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindOrderList();
            }
        }

        private void BindOrderList()
        {
            DataTable dt = _core._dal.Order.GetOrder();
            gvOrder.DataSource = dt;
            gvOrder.DataBind();
        }

        protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             Control ctl = null;
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 DataRowView drv = (DataRowView)e.Row.DataItem;

                 ctl = e.Row.FindControl("lnkOrderID");
                 if (ctl != null)
                 {
                     LinkButton lnkOrderID = (LinkButton)ctl;
                     lnkOrderID.Text = drv["OrderID"].ToString();
                 }
                 ctl = e.Row.FindControl("lbCustomer");
                 if (ctl != null)
                 {
                     Label lbCustomer = (Label)ctl;
                     lbCustomer.Text = drv["CompanyName"].ToString();
                 }
                 ctl = e.Row.FindControl("lbSales");
                 if (ctl != null)
                 {
                     Label lbSales = (Label)ctl;
                     lbSales.Text = drv["EmpName"].ToString();
                 }
             }
        }

        protected void lnkOrderID_Click(object sender, EventArgs e)
        {

        }
    }
}