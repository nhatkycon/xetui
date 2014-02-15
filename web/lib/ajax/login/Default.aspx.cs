using System;
using System.Net;
using System.Reflection;
using docsoft;
using docsoft.entities;
using linh.common;
using linh.controls;
using linh.core;
using linh.core.dal;
using docsoft.plugin.hethong.thanhvien;
public partial class lib_ajax_login_Default : BasedPage
{
    public delegate void SaveAvatarDelegate(int id, string fbid, string dic);
    public delegate void SendEmailDelegate(string email, string title, string body);
    public void SendMailSingle(string email, string title, string body)
    {
        omail.Send(email, "Xetui.vn", title, body, "gigawebhome@gmail.com", "Xetui.vn", "25111987");
    }
    const string uAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; vi; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
    void SaveAvatar(int id, string fbid, string dic)
    {
        var url = string.Format("http://graph.facebook.com/{0}/picture?type=large", fbid);
        var rq = (HttpWebRequest)(WebRequest.Create(url));
        rq.UserAgent = uAgent;
        rq.Timeout = 20000;
        var rp = (HttpWebResponse)(rq.GetResponse());
        var newUri = rp.ResponseUri;
        var img = new ImageProcess(newUri, url);
        img.Crop(180, 180);
        var ten = string.Format("{0}{1}", id, img.Ext);
        img.Save(dic + ten);
        var user = MemberDal.SelectById(id);
        MemberDal.UpdateAnh(user.Username, ten);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        var email = Request["email"];
        var name = Request["name"];
        var id = Request["id"];
        var username = Request["username"];
        var verified = Request["verified"];
        var Captcha = Request["Captcha"];
        var Email = Request["Email"];
        var Pwd = Request["Pwd"];
        var Ten = Request["Ten"];
        var Rem = Request["Rem"];
        var dic = Server.MapPath("~/lib/up/users/");
        Rem = !string.IsNullOrEmpty(Rem) ? "true" : "false";
        switch (subAct)
        {
            case "signupFb":
                #region Sigup
                if(!string.IsNullOrEmpty(id))
                {
                    var userFb = MemberDal.SelectByFbId(id);
                    if(string.IsNullOrEmpty(userFb.Username))
                    {
                        var userEmail = MemberDal.SelectByEmail(email);
                        var userUsername = MemberDal.SelectByUsername(username);
                        userFb.Username = username;
                        if (!string.IsNullOrEmpty(userUsername.Username))
                        {
                            userFb.Username = email;
                        }
                        if (!string.IsNullOrEmpty(userEmail.Username))
                        {
                            rendertext("2");                            
                        }
                        userFb.Ten = name;
                        userFb.CQ_ID = 1;
                        userFb.NgayTao = DateTime.Now;
                        userFb.XacNhan = true;
                        userFb.NgayXacNhan = DateTime.Now;
                        userFb.ChungThuc = false;
                        userFb.Email = email;
                        userFb.FbId = id;
                        userFb.RowId = Guid.NewGuid();
                        userFb.Active = true;
                        userFb = MemberDal.Insert(userFb);
                        var saveAvatar = new SaveAvatarDelegate(SaveAvatar);
                        saveAvatar.BeginInvoke(userFb.Id, id, dic, null, null);
                        MemberDal.UpdateVcard(DAL.con(), userFb.Username);
                        Security.Login(username, "true");
                        rendertext("1");
                    }
                    rendertext("0");
                }
                break;
                #endregion
            case "checkFbId":
                #region Check exsist username by FbId
                if (!string.IsNullOrEmpty(id))
                {
                    var userFb = MemberDal.SelectByFbId(id);
                    if (string.IsNullOrEmpty(userFb.Username))
                    {
                        rendertext("0");
                    }
                    Security.Login(userFb.Username, "true");
                    rendertext("1");
                }
                break;
                #endregion
            case "signup":
                #region Sigup
                if (!string.IsNullOrEmpty(Email))
                {
                    if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(Pwd) || string.IsNullOrEmpty(Captcha))
                    {
                        rendertext("3");
                    }

                    if(Captcha.ToLower() != Session["capcha"].ToString().ToLower())
                    {
                        rendertext("0");
                    }
                    

                    var user = MemberDal.SelectByEmail(Email);
                    if (!string.IsNullOrEmpty(user.Username))
                    {
                        rendertext("2");
                    }
                    user.Username = Email;
                    user.Ten = Ten;
                    user.Password = maHoa.EncryptString(Pwd, Email);
                    user.CQ_ID = 1;
                    user.NgayTao = DateTime.Now;
                    user.XacNhan = false;
                    user.ChungThuc = false;
                    user.Email = Email;
                    user.Active = true;
                    user.RowId = Guid.NewGuid();
                    user.DiaChi = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 6);
                    user = MemberDal.Insert(user);
                    var obj = ObjDal.Insert(new Obj()
                    {
                        ID = Guid.NewGuid()
                        ,
                        Kieu = typeof(Member).FullName
                        ,
                        NgayTao = DateTime.Now
                        ,
                        RowId = user.RowId
                        ,
                        Url = user.Url
                        ,
                        Username = Security.Username
                        ,
                        Ten = user.Ten
                    });
                    
                    MemberDal.UpdateVcard(DAL.con(), user.Username);
                    
                    
                    Security.Login(user.Username, Pwd, "true");

                    var dele = new SendEmailDelegate(SendMailSingle);
                    var emailTemp = Lib.GetResource(typeof(Class1).Assembly, "Xetui-email-welcome.html");
                    dele.BeginInvoke(user.Email, "Xetui.vn - Xac nhan tai khoan"
                                     , string.Format(emailTemp, user.Ten, user.Email, user.Id, user.DiaChi)
                                     , null, null);

                    rendertext("1");
                }
                rendertext("3");
                break;
                #endregion
            case "reSendActive":
                #region reSend Active
                if (Security.IsAuthenticated())
                {
                    var user = MemberDal.SelectAllByUserName(Security.Username);
                    user.DiaChi = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 6);
                    user = MemberDal.Update(user);
                    var dele = new SendEmailDelegate(SendMailSingle);
                    var emailTemp = Lib.GetResource(typeof(Class1).Assembly, "Xetui-email-welcome.html");
                    dele.BeginInvoke(user.Email, "Xetui.vn - Xac nhan tai khoan"
                                     , string.Format(emailTemp, user.Ten, user.Email, user.Id, user.DiaChi)
                                     , null, null);
                    rendertext("1");
                }
                rendertext("0");
                break;
                #endregion
            case "recover-sendEmail":
                #region recover sendEmail
                if (!string.IsNullOrEmpty(Email))
                {
                    var user = MemberDal.SelectAllByUserName(Email);
                    if(user.Id==0)
                        rendertext("0");
                    if (!user.XacNhan)
                        rendertext("2");
                    user.DiaChi = CaptchaImage.GenerateRandomCode(CaptchaType.Numeric, 6);
                    user = MemberDal.Update(user);
                    var dele = new SendEmailDelegate(SendMailSingle);
                    var emailTemp = Lib.GetResource(typeof(Class1).Assembly, "Lay-lai-mat-khau.html");
                    dele.BeginInvoke(user.Email, "Xetui.vn - Lay lai mat khau"
                                     , string.Format(emailTemp, user.Ten, user.Email, user.Id, user.DiaChi)
                                     , null, null);
                    rendertext("1");
                }
                rendertext("0");
                break;
                #endregion
            case "recover-newPassword":
                #region recover newPassword
                if (!string.IsNullOrEmpty(id))
                {
                    var user = MemberDal.SelectById(Convert.ToInt32(id));
                    if (user.Id == 0)
                        rendertext("0");
                    if (!user.XacNhan)
                        rendertext("2");
                    user.DiaChi = string.Empty;
                    user.Password = maHoa.EncryptString(Pwd, user.Username);
                    user = MemberDal.Update(user);
                    Security.Login(user.Username, "true");
                    rendertext("1");
                }
                rendertext("0");
                break;
                #endregion
            case "login":
                #region Login
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Pwd))
                {
                    var ok = Security.Login(Email, Pwd, Rem);
                    if(ok)
                    {
                        var user = MemberDal.SelectAllByUserName(Email);
                        if(!user.Active)
                        {
                            Security.LogOut();
                            rendertext("2");                            
                        }
                        rendertext("1");
                    }
                    rendertext("0");
                }
                rendertext("0");
                break;
                #endregion
            case "logout":
                #region logout this system
                Security.LogOut();
                break;
                #endregion
        }
    }
}