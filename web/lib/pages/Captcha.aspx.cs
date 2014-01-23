using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.controls;
public partial class lib_pages_Captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _capchaCode = CaptchaImage.GenerateRandomCode(CaptchaType.AlphaNumeric, 4);
        Session["capcha"] = _capchaCode;
        var c = new CaptchaImage(_capchaCode, 100, 40, "Tahoma", Color.White, Color.Red);
        Response.ClearContent();
        Response.ContentType = "image/jpeg";
        var ms = new MemoryStream();
        c.Image.Save(ms, ImageFormat.Jpeg);
        Response.OutputStream.Write(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
        ms.Close();
        Response.End();

    }
}