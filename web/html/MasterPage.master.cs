﻿using System;
using System.Linq;
using System.Web;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class html_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        promotedCars.List = XeDal.PromotedTop.Take(5).ToList();
        //testing mode
        var input = Request["k"];
        if(!string.IsNullOrEmpty(input))
        {
            Session["key"] = input;
        }
        var key = Session["key"];
        if(key == null)
        {
            //Response.ClearContent();
            //Response.Write(string.Format("<h1>Tesing</h1><hr/>Requested IP:{0}<br/>Date:{1}<hr/>{2}", Request.UserHostAddress, DateTime.Now, Request.UserAgent));
            //Response.End();
        }
    }
}
