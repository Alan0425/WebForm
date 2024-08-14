using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ado objTravel = new Ado();
        DataTable dtbTravel = new DataTable();

        dtbTravel = objTravel.GetTable();

        LV_OneDay.DataSource = dtbTravel;

        LV_OneDay.DataBind();
    }
}