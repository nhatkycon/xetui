using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_cars_myCars : System.Web.UI.UserControl
{
    public List<Xe> MyCarsList { get; set; }
    public List<Xe> LikedCarsList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(MyCarsList!=null)
        {
            var currentCarsList = (from p in MyCarsList
                                   where p.DangLai
                                   select p).ToList();
            currentCars.DataSource = currentCarsList;
            currentCars.DataBind();

            var formerCarsList = (from p in MyCarsList
                                   where !p.DangLai
                                   select p).ToList();
            formerCars.DataSource = formerCarsList;
            formerCars.DataBind();
        }
        if(LikedCarsList!=null)
        {
            likedCars.DataSource = LikedCarsList;
            likedCars.DataBind();
        }
    }
}