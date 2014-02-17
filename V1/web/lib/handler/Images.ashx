<%@ WebHandler Language="C#" Class="Xetui.HttpHandler.ImagesHandler" %>

using System;
using System.IO;
using System.Web;
using linh.controls;
namespace Xetui.HttpHandler
{
    public class ImagesHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var path = context.Request["path"];
            var w = context.Request["w"];
            var h = context.Request["h"];
            var m = context.Request["m"];
            if(string.IsNullOrEmpty(path))
                return;
            if(path.IndexOf("lib/js/") > 0) return;
            path = context.Server.MapPath(@"~\" + path);
            if(!File.Exists(path))
                return;
            var img = new ImageProcess(path, path);
            if(!string.IsNullOrEmpty(w))
            {
                img.Resize(Convert.ToInt32(w));
                if(!string.IsNullOrEmpty(h))
                {
                    img.Crop(Convert.ToInt32(w), Convert.ToInt32(h));
                }
                if (Convert.ToInt32(w) > 320)
                {
                    if(string.IsNullOrEmpty(m))
                    {
                        var watermark = context.Server.MapPath("~/lib/css/web/xetui-logo/watermark.png");
                        img.AddWaterMark(watermark);    
                    }
                }
            }
            img.Save();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

    }

}
