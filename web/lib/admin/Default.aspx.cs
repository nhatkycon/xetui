using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using System.Text;
using linh.frm;
using linh.common;
using System.IO;
using linh.controls;
using docsoft.entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using linh.core.dal;
using System.Diagnostics;
public partial class _admin_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        string imgSaveLoc = Server.MapPath("~/lib/up/i/");
        string imgSaveTintuc = Server.MapPath("~/lib/up/tintuc/");
        string imgTemp = Server.MapPath("~/lib/up/temp/");
        string docTemp = Server.MapPath("~/lib/up/d/");
        bool loggedIn = Security.IsAuthenticated();
        insertLog("0", Security.Username, Request.UserHostAddress, Request.Url.PathAndQuery);
        switch (act)
        {
            case "loadPlug":
                if (rqPlug != null)
                {
                    sb.Append(PlugHelper.RenderHtml(rqPlug));
                }
                rendertext(sb);
                break;
            case "loadPlugContent":
                if (rqPlug != null)
                {
                    Type type = Type.GetType(rqPlug);
                    IPlug plug = (IPlug)Activator.CreateInstance(type);
                    plug.ImportPlugin();
                    using (SqlConnection con = linh.core.dal.DAL.con())
                    {
                        plug.KhoiTao(con);
                        rendertext(plug.Html);
                    }
                }
                rendertext(sb);
                break;
            case "upload":
                #region upload ảnh
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                                if (File.Exists(imgSaveLoc + Request["oldFile"]))
                                {
                                    File.Delete(imgSaveLoc + Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(730, 600);
                        img.Save(imgSaveLoc + imgten + "730x600" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveLoc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveLoc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadTintuc":
                #region upload ảnh
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                                if (File.Exists(imgSaveLoc + Request["oldFile"]))
                                {
                                    File.Delete(imgSaveLoc + Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Crop(730, 600);
                        img.Save(imgSaveTintuc + imgten + "730x600" + img.Ext);
                        img.Crop(420, 280);
                        img.Save(imgSaveTintuc + imgten + "420x280" + img.Ext);
                        img.Crop(130, 100);
                        img.Save(imgSaveTintuc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
                }
                break;
                #endregion
            case "uploadFull":
                #region upload ảnh
                if (Security.IsAuthenticated())
                {
                    if (Request.Files[0] != null)
                    {
                        string imgten = Guid.NewGuid().ToString();
                        if (!string.IsNullOrEmpty(Request["oldFile"]))
                        {
                            try
                            {
                                imgten = Path.GetFileNameWithoutExtension(Request["oldFile"]);
                                if (File.Exists(imgSaveLoc + Request["oldFile"]))
                                {
                                    File.Delete(imgSaveLoc + Request["oldFile"]);
                                }
                            }
                            finally
                            {
                            }

                        }
                        ImageProcess img = new ImageProcess(Request.Files[0].InputStream, Guid.NewGuid().ToString());
                        img.Save(imgSaveLoc + imgten + img.Ext);
                        rendertext(imgten + img.Ext);
                    }
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
                    Page pageHolder = new Page();
                    UserControl uc = (UserControl)(_IPlug);
                    this.Controls.Add(uc);
                }
                break;
           
            default:
                string d = "12/9/2010";
                //DateTime da = Convert.ToDateTime(d, new System.Globalization.CultureInfo("vi-Vn"));
                //Response.Write(da.Month.ToString());
                Response.Write(maHoa.EncryptString("111", "phatcd"));
                break;
        }
    }
    protected override void OnError(EventArgs e)
    {
        insertLog("1", Security.Username, Request.UserHostAddress, Request.Url.PathAndQuery);
        insertLog(string.Format("MSG: {0} SRS: {1}", Server.GetLastError().InnerException, Server.GetLastError().Source), "1", Security.Username, Request.UserHostAddress, Request.Url.PathAndQuery);
        base.OnError(e);
    }
    void insertLog(string LOG_LLOG_ID, string Username, string LOG_RequestIp, string LOG_RawUrl)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlParameter[] obj = new SqlParameter[4];
        obj[0] = new SqlParameter("Username", Username);
        obj[1] = new SqlParameter("LOG_RequestIp", LOG_RequestIp);
        obj[2] = new SqlParameter("LOG_RawUrl", LOG_RawUrl);
        obj[3] = new SqlParameter("LOG_LLOG_ID", LOG_LLOG_ID);
        try
        {
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sptblLog_Insert_quick_linhnx", obj);
            con.Close();

        }
        finally
        {
            con.Close();
        }
    }
    void insertLog(string LOG_Ten, string LOG_LLOG_ID, string Username, string LOG_RequestIp, string LOG_RawUrl)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlParameter[] obj = new SqlParameter[5];
        obj[0] = new SqlParameter("Username", Username);
        obj[1] = new SqlParameter("LOG_RequestIp", LOG_RequestIp);
        obj[2] = new SqlParameter("LOG_RawUrl", LOG_RawUrl);
        obj[3] = new SqlParameter("LOG_LLOG_ID", LOG_LLOG_ID);
        obj[4] = new SqlParameter("LOG_Ten", LOG_Ten);
        try
        {
            con.Open();
            SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sptblLog_Insert_quick1_linhnx", obj);
            con.Close();

        }
        finally
        {
            con.Close();
        }
    }
   
}