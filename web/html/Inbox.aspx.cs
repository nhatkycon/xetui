using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Inbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con=DAL.con())
        {
            var rooms = PmRoomDal.SelectByUser(con, Security.Username, 20, null);
            RoomList.List = rooms;
        }
    }
}