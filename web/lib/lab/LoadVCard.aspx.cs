using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_lab_LoadVCard : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        var vcard = MemberDal.UpdateVcard(DAL.con(), "sspa");
        rendertext(vcard);

    }
}