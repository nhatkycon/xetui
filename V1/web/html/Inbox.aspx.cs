using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_Inbox : LoggedPage
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