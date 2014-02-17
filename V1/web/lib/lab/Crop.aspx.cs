using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using Image = System.Web.UI.WebControls.Image;

public partial class lib_lab_Crop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         var x = Request["x"];
        var y= Request["y"];
        var x1= Request["x1"];
        var y1= Request["y1"];
        var w= Request["w"];
        var h= Request["h"];
        var fileName = Server.MapPath("~/lib/lab/mercedes.jpg");
        var cropRect = new Rectangle(Convert.ToInt32(x), Convert.ToInt32(y), Convert.ToInt32(w), Convert.ToInt32(h));
        var src = new Bitmap(fileName);
        var format = src.RawFormat;
        var codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
        var mimeType = codec.MimeType;
        var imgFormat = new ImageFormat(codec.FormatID);


        var cropted = CropBitmapBetter(src, cropRect);
        Response.ClearContent();
        Response.ContentType = mimeType;
        cropted.Save(Response.OutputStream, ImageFormat.Jpeg);
        Response.End();

    }
    public Bitmap CropBitmap(Bitmap bitmap, Rectangle rect)
    {
        var cropped = bitmap.Clone(rect, bitmap.PixelFormat);
        return cropped;
    }
    public Bitmap CropBitmapBetter(Bitmap bitmap, Rectangle rect)
    {
        // An empty bitmap which will hold the cropped image
        var bmp = new Bitmap(rect.Width, rect.Height);
        bitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
        Graphics g = Graphics.FromImage(bmp);

        // Draw the given area (section) of the source image
        // at location 0,0 on the empty bitmap (bmp)
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(bitmap, 0, 0, rect, GraphicsUnit.Pixel);
        g.Dispose();
        return bmp;
        //var bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);

        //bmp.SetResolution(300, 300);

        //Graphics graphics = Graphics.FromImage(bmp);

        //graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //graphics.DrawImage(bitmap, new Rectangle(0,0, rect.Width,rect.Height), rect.X,rect.Y,rect.Width,rect.Height,GraphicsUnit.Pixel);

        //graphics.Dispose();

        //return bmp;
    }

}