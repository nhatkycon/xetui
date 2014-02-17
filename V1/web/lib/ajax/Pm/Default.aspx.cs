using System;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core;

public partial class lib_ajax_Pm_Default : BasedPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var toUser = Request["toUser"];
        var fromUser = Request["fromUser"];
        var fromId = Request["fromId"];
        var noiDung = Request["txt"];
        var Id = Request["Id"];
        var logged = Security.IsAuthenticated();
        var pmSize = 10;
        switch (subAct)
        {
            case "add":
                #region add
                    if(!string.IsNullOrEmpty(noiDung))
                    {
                        if (toUser == Security.Username)
                            rendertext("Cannot send to yourself");
                        var item = new Pm
                                       {
                                           NoiDung = noiDung,
                                           NguoiGui = Security.Username,
                                           NguoiNhan = toUser,
                                           NgayTao = DateTime.Now,
                                           Doc = false
                                       };

                        var pmRoom = PmRoomDal.SelectByU1U2(Security.Username, toUser);
                        if (pmRoom.Id == 0)
                            pmRoom = PmRoomDal.Insert(new PmRoom()
                                                          {
                                                              NgayTao = DateTime.Now
                                                              ,
                                                              NgayCapNhat = DateTime.Now
                                                              ,
                                                              NguoiGui = Security.Username
                                                              ,
                                                              NguoiNhan = toUser
                                                              ,
                                                              Total = 0
                                                              , 
                                                              RowId = Guid.NewGuid()
                                                          });
                        item.PMR_ID = pmRoom.Id;
                        item.RowId = Guid.NewGuid();
                        item = PmDal.Insert(item);
                    }
                    break;
                #endregion
            case "remove":
                #region remove
                    if(!string.IsNullOrEmpty(Id))
                    {
                        var item = PmDal.SelectById(Convert.ToInt64(Id));
                        if (item.NguoiGui == Security.Username)
                            item.NguoiGuiXoa = true;
                        if (item.NguoiNhan == Security.Username)
                            item.NguoiNhanXoa = true;
                        PmDal.Update(item);
                    }
                    break;
                #endregion
            case "getPmBox":
                    #region get pm box
                    if (!string.IsNullOrEmpty(Id))
                    {
                        var item = PmRoomDal.SelectById(Convert.ToInt32(Id));
                        var list = PmDal.SelectByPmRoomId(Id, pmSize, fromId, Security.Username);
                        var mList = (from p in list
                                     select p).OrderBy(p => p.Id).ToList();
                        PmBox.List = mList;
                        PmBox.ToUser = item.NguoiGui == Security.Username ? item.NguoiNhan : item.NguoiGui;
                        PmBox.Id = Id;
                        PmBox.Visible = true;

                    }
                    break;
                    #endregion
            case "getPmList-More":
                    #region get pm more
                    if (!string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(fromId))
                    {
                        var list = PmDal.SelectByPmRoomId(Id, pmSize, fromId, Security.Username);
                        var mList = (from p in list
                                     select p).OrderBy(p => p.Id).ToList();
                        PmList.FromId = fromId;
                        PmList.RoomId = Id;
                        PmList.List = mList;
                        PmList.Visible = true;

                    }
                    break;
                    #endregion
            case "getPmList-Latest":
                    #region get pm box Latest
                    if (!string.IsNullOrEmpty(Id))
                    {
                        var list = PmDal.SelectLatestByPmRoomId(Id, 30, fromId, Security.Username);
                        var mList = (from p in list
                                     select p).OrderBy(p => p.Id).ToList();
                        PmList.RoomId = Id;
                        PmList.List = mList;
                        PmList.FromId = fromId;
                        PmList.Visible = true;

                    }
                    break;
                    #endregion
        }
    }
}