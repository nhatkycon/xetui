using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class html_Search : System.Web.UI.Page
{
    public int Total { get; set; }
    public string Paging { get; set; }
    public bool NullQuery { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var fromStr = Request["from"];
        if (string.IsNullOrEmpty(fromStr))
            fromStr = "0";
        var from = 0;

        Int32.TryParse(fromStr, out from);
        var sizeStr = Request["size"];
        if (string.IsNullOrEmpty(sizeStr))
            sizeStr = "10";
        var size = 0;
        Int32.TryParse(sizeStr, out size);
        var q = Request["q"];
        NullQuery = string.IsNullOrEmpty(q);
        if(NullQuery) return;


         var TotalPages = 0;
        var currentPageStage = 0;
        var maxPage = 0;
        var PageSize = size;
        var Query = "page";
        var PageIndex = 0 ;
        var pageIndex = Request[Query];
        if (string.IsNullOrEmpty(pageIndex))
            pageIndex = "0";
        Int32.TryParse(pageIndex, out PageIndex);
        var PagingSize = 10;

        var total = 0;
        var list = SearchManager.Search(q, (PageSize * PageIndex), PageSize, out total);
        Total = total;
        search1.List = list;
        search1.Total = Total;
       
        

        var CUrl = string.Format("?q={0}", q) + "&{1}={0}";
        if(total > size)
        {
            if (Total % PageSize == 0)
            {
                TotalPages = Convert.ToInt32(Total / PageSize);
            }
            else
            {
                TotalPages = Convert.ToInt32(Math.Floor(Convert.ToDouble(Total / PageSize))) + 1;
            }
            if (PageIndex % PagingSize == 0)
            {
                currentPageStage = PageIndex / PagingSize;
            }
            else
            {
                currentPageStage = Convert.ToInt32(Math.Floor(Convert.ToDouble(PageIndex / PagingSize))) + 1;
            }
            if (TotalPages % PagingSize == 0)
            {
                maxPage = TotalPages / PagingSize;
            }
            else
            {
                maxPage = Convert.ToInt32(Math.Floor(Convert.ToDouble(TotalPages / PagingSize))) + 1;
            }
            if (currentPageStage == 0) currentPageStage = 1;
            var sb = new StringBuilder();
            #region old
            if (Total > 0 && Total > PageSize)
            {
                if (TotalPages < PagingSize)// Tổng số trang nhỏ hơn số trang trong khay paging
                {
                    #region Paging
                    for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                    {
                        if (i <= TotalPages)
                        {
                            sb.AppendFormat("<li class=\"{1}\"><a class=\"PagingItem {1}\" href=\"{2}\">{0}</a></li>"
                                , i
                                , i == PageIndex ? "PagingItemActive active" : ""
                                , string.Format(CUrl, i, Query));
                        }
                    }
                    #endregion
                }
                else
                {
                    if (currentPageStage > 1 && currentPageStage < maxPage)
                    {
                        #region Firts, Prev
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemFirts\" href=\"{0}\"><<</a></li>"
                            , string.Format(CUrl, "1", Query));
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemPrev\" href=\"{0}\"><</a></li>"
                            , string.Format(CUrl, ((currentPageStage - 1) * PagingSize), Query));
                        #endregion
                        #region Paging
                        for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                        {
                            if (i < TotalPages)
                            {
                                sb.AppendFormat("<li class=\"{1}\"><a class=\"PagingItem {1}\" href=\"{2}\">{0}</a></li>"
                                , i
                                , i == PageIndex ? "PagingItemActive active" : ""
                                , string.Format(CUrl, i, Query));
                            }
                        }
                        #endregion
                        #region Next, Last
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemFirts\" href=\"{0}\">></a></li>"
                            , string.Format(CUrl, (currentPageStage * PagingSize) + 1, Query));
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemFirts\" href=\"{0}\">>></a></li>"
                            , string.Format(CUrl, TotalPages, Query));
                        #endregion

                    }
                    else if (currentPageStage == 1)
                    {
                        #region Paging
                        for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                        {
                            if (i < TotalPages)
                            {
                                sb.AppendFormat("<li class=\"{1}\"><a class=\"PagingItem {1}\" href=\"{2}\">{0}</a></li>"
                                , i
                                , i == PageIndex ? "PagingItemActive active" : ""
                                , string.Format(CUrl, i, Query));
                            }
                        }
                        #endregion
                        #region Next, Last
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemFirts\" href=\"{0}\">></a></li>"
                            , string.Format(CUrl, (currentPageStage * PagingSize) + 1, Query));
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemFirts\" href=\"{0}\">>></a></li>"
                            , string.Format(CUrl, TotalPages, Query));
                        #endregion
                    }
                    else
                    {
                        #region Firts, Prev
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemFirts\" href=\"{0}\"><<</a></li>"
                            , string.Format(CUrl, "1", Query));
                        sb.AppendFormat("<li><a class=\"PagingItem PagingItemPrev\" href=\"{0}\"><</a></li>"
                            , string.Format(CUrl, ((currentPageStage - 1) * PagingSize), Query));
                        #endregion
                        #region Paging
                        for (int i = Convert.ToInt32(((currentPageStage - 1) * PagingSize) + 1); i <= (currentPageStage * PagingSize); i++)
                        {
                            if (i < TotalPages)
                            {
                                sb.AppendFormat("<li class=\"{1}\"><a class=\"PagingItem {1}\" href=\"{2}\">{0}</a></li>"
                                , i
                                , i == PageIndex ? "PagingItemActive active" : ""
                                , string.Format(CUrl, i, Query));
                            }
                        }
                        #endregion
                    }
                }
            }
            #endregion
            Paging = sb.ToString();
        }

    }
}