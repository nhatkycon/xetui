using System;
using ServiceStack.Redis;
using docsoft.entities;

public partial class lib_ui_blog_templates_homeItem : System.Web.UI.UserControl
{
    public Blog Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}