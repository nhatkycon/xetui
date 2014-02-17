using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using linh.frm;
using linh.json;
using linh.common;
using System.IO;
using linh.controls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using linh.core.dal;
using System.Diagnostics;
using System.Drawing;
using System.Web.UI.HtmlControls;
using docsoft;
using docsoft.entities;

namespace linh.httpModule
{
    public class defaultHandle : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public bool IsReusable
        {
            get
            {
                return true;
            }

        }

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string act = context.Request["act"];
            string rqPlug = context.Request["rqPlug"];
            string imgSaveLoc = context.Server.MapPath("~/lib/up/i/");
            string imgTemp = context.Server.MapPath("~/lib/up/temp/");
            string docTemp = context.Server.MapPath("~/lib/up/d/");
            string imgSaveTintuc = context.Server.MapPath("~/lib/up/tintuc/");
            string imgSaveSanPham = context.Server.MapPath("~/lib/up/sanpham/");
            string imgSaveQuangCao = context.Server.MapPath("~/lib/up/quangcao/");
            string imgSaveKTNN = context.Server.MapPath("~/lib/up/KTNN/");

            string _height = context.Request["height"];
            string _width = context.Request["width"];
            string _PRowIdSP = context.Request["PRowIdSP"];
            switch (act)
        {
            case "loadPlug":
                #region loadPlug: nap plug
                if (rqPlug != null)
                {
                    sb.Append(PlugHelper.RenderHtml(rqPlug));
                }
                rendertext(sb);
                break;
                #endregion
            case "upload":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                       

                    }
                    var img = new ImageProcess(context.Request.Files[0].InputStream, imgten);
                    context.Request.Files[0].SaveAs(imgSaveLoc + imgten + "full" + img.Ext);

                    img.Resize(326);
                    context.Request.Files[0].SaveAs(imgSaveLoc + imgten + "326" + img.Ext);

                    img.Crop(50, 50);
                    img.Save(imgSaveLoc + imgten + img.Ext);

                    rendertext(imgten + img.Ext);
                }

                break;
                #endregion
            case "uploadQuangCao":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveQuangCao + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveQuangCao + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    img.Save(imgSaveQuangCao + imgten + "source" + img.Ext);
                    img.Crop(int.Parse(_width), int.Parse(_height));
                    img.Save(imgSaveQuangCao + imgten + img.Ext);
                    rendertext(imgten + img.Ext);
                }

                break;
                #endregion
            case "uploadSanPham":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveSanPham + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveSanPham + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    img.Save(imgSaveSanPham + imgten + "full" + img.Ext);
                    img.Crop(400, 300);
                    img.Save(imgSaveSanPham + imgten + "400x300" + img.Ext);
                    img.Crop(200, 200);
                    img.Save(imgSaveSanPham + imgten + "200x200" + img.Ext);
                    img.Crop(90, 90);
                    img.Save(imgSaveSanPham + imgten + img.Ext);
                    rendertext(imgten + img.Ext);
                }

                break;
                #endregion
            case "uploadTintuc":
                #region upload ?nh
                if (Security.IsAuthenticated())
                {
                    if (context.Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                                if (File.Exists(imgSaveTintuc + context.Request["oldFile"]))
                                {
                                    File.Delete(imgSaveTintuc + context.Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        context.Request.Files[0].SaveAs(imgSaveTintuc + imgten + "full" + img.Ext);
                        img.Crop(730, 600);
                        img.Save(imgSaveTintuc + imgten + "990x340" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveTintuc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveTintuc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadKTNN":
                #region upload ?nh
                if (Security.IsAuthenticated())
                {
                    if (context.Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                                if (File.Exists(imgSaveKTNN + context.Request["oldFile"]))
                                {
                                    File.Delete(imgSaveKTNN + context.Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(730, 600);
                        img.Save(imgSaveKTNN + imgten + "730x600" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveKTNN + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveKTNN + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadFlash":
                #region upload flash
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveLoc + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveLoc + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    if (Path.GetExtension(context.Request.Files[0].FileName).ToLower() == ".swf")
                    {
                        string flash = Guid.NewGuid().ToString();

                        context.Request.Files[0].SaveAs(context.Server.MapPath("~/lib/up/v/") + flash + Path.GetExtension(context.Request.Files[0].FileName));
                        rendertext(flash + Path.GetExtension(context.Request.Files[0].FileName));
                    }
                    else
                    {
                        ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(420, 280);
                        img.Save(imgSaveLoc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveLoc + imgten + img.Ext);
                        img.Crop(370, 90);
                        img.Save(imgSaveLoc + imgten + "370x90" + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }

                break;
                #endregion
            case "uploadFull":
                #region upload ?nh
                if (context.Request.Files[0] != null)
                {
                    string imgten = Guid.NewGuid().ToString();
                    if (!string.IsNullOrEmpty(context.Request["oldFile"]))
                    {
                        try
                        {
                            imgten = Path.GetFileNameWithoutExtension(context.Request["oldFile"]);
                            if (File.Exists(imgSaveLoc + context.Request["oldFile"]))
                            {
                                File.Delete(imgSaveLoc + context.Request["oldFile"]);
                            }
                        }
                        finally
                        {
                        }

                    }
                    ImageProcess img = new ImageProcess(context.Request.Files[0].InputStream, Guid.NewGuid().ToString());
                    img.Save(imgSaveLoc + imgten + img.Ext);
                    rendertext(imgten + img.Ext);
                }
                break;
                #endregion
            case "loadPlugDirect":
                if (!string.IsNullOrEmpty(rqPlug))
                {
                    string _IPlugType = rqPlug;
                    Type type = Type.GetType(_IPlugType);
                    IPlug _IPlug = (IPlug)(Activator.CreateInstance(type));
                    _IPlug.ImportPlugin();                    
                    UserControl uc = (UserControl)(_IPlug);
                    Page page = new Page();
                    page.EnableViewState = false;
                    HtmlForm form = new HtmlForm();
                    form.ID = "__t";
                    page.Controls.Add(form);
                    form.Controls.Add(uc);
                    StringWriter tw = new StringWriter();
                    HttpContext.Current.Server.Execute(page, tw, true);
                }
                break;
            case "capcha":
                #region capcha
                string _capchaCode = CaptchaImage.GenerateRandomCode(CaptchaType.AlphaNumeric, 3);
                context.Session["capcha"] = _capchaCode;
                CaptchaImage c = new CaptchaImage(_capchaCode, 200, 50, "Tahoma", Color.White, Color.Orange);
                context.Response.ClearContent();
                context.Response.ContentType = "image/jpeg";
                MemoryStream ms = new MemoryStream();
                c.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                context.Response.OutputStream.Write(ms.ToArray(), 0, Convert.ToInt32(ms.Length));
                ms.Close();
                context.Response.End();
                break;
                #endregion
                default:
                #region macdinh
                context.Response.Write(DateTime.Now.ToString("hh:mm"));
                break;
                #endregion
        }
        }
        public void rendertext(StringBuilder sb)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(sb.ToString());
            c.Response.End();
        }
        public void rendertext(string txt)
        {
            HttpContext c = HttpContext.Current;
            c.Response.ClearContent();
            c.Response.ContentType = "text/html";
            c.Response.Write(txt);
            c.Response.End();
        }

        
    }
}
