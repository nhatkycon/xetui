using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using docsoft.entities;
using linh.common;
using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;
public partial class lib_lab_Lucense : System.Web.UI.Page
{
    public string Dic
    {
        get { return Server.MapPath("~/index1/"); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Indexer();
    }
    public void Indexer()
    {
        var directory = FSDirectory.Open(new DirectoryInfo(Dic));
        var analyzer = new StandardAnalyzer(Version.LUCENE_29);
        var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
        foreach (var item in XeDal.SelectAll())
        {
            var doc = new Document();
            doc.Add(new Field("Ten", item.Ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("NoiDung", string.Format("{0} {1}", item.Ten, item.GioiThieu), Field.Store.YES,
                              Field.Index.ANALYZED));
            doc.Add(new Field("RowId", item.RowId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("ID", item.ID.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Url", item.XeUrl, Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
        }

        foreach (var item in NhomDal.SelectAll())
        {
            var doc = new Document();
            doc.Add(new Field("Ten", item.Ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("NoiDung", string.Format("{0} {1} {2}", item.Ten, item.GioiThieu, item.MoTa), Field.Store.YES,
                              Field.Index.ANALYZED));
            doc.Add(new Field("RowId", item.RowId.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("ID", item.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Url", item.Url, Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
        }


        foreach (var item in BinhLuanDal.SelectAll())
        {
            item.Ten = string.Format("{0} bình luận ngày {1}", item.Username, Lib.TimeDiff(item.NgayTao));
            var doc = new Document();
            doc.Add(new Field("Ten", item.Ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("NoiDung", string.Format("{0} {1}", item.Ten, item.NoiDung), Field.Store.YES,
                              Field.Index.ANALYZED));
            doc.Add(new Field("RowId", item.RowId.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("ID", item.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Url", item.Url, Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
        }

        foreach (var item in BlogDal.SelectAll())
        {
            var doc = new Document();
            doc.Add(new Field("Ten", item.Ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("NoiDung", string.Format("{0} {1}", item.Ten, item.NoiDung), Field.Store.YES,
                              Field.Index.ANALYZED));
            doc.Add(new Field("RowId", item.RowId.ToString(), Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("ID", item.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Url", item.Url, Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
        }

        writer.Optimize();
        writer.Commit();
        writer.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();

        var directory = FSDirectory.Open(new DirectoryInfo(Dic));
        var analyzer = new StandardAnalyzer(Version.LUCENE_29);
        var indexReader = IndexReader.Open(directory, true);
        var indexSearch = new IndexSearcher(indexReader);
        var queryParser = new QueryParser(Version.LUCENE_29, "NoiDung", analyzer);
        var query = queryParser.Parse(TextBox1.Text);

        var resultDocs = indexSearch.Search(query, indexReader.MaxDoc());
        var hits = resultDocs.scoreDocs;

        foreach (var hit in hits)
        {
            var documentFromSearcher = indexSearch.Doc(hit.doc);
            sb.AppendFormat("{3}: {0} {1} {2}<br/>"
                ,documentFromSearcher.Get("ID")
                , documentFromSearcher.Get("Ten")
                , documentFromSearcher.Get("RowId")
                , hit.score);
        }
        indexSearch.Close();
        directory.Close();

        Literal1.Text = sb.ToString();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        var directory = FSDirectory.Open(new DirectoryInfo(Dic));
        var indexReader = IndexReader.Open(directory, false);
        indexReader.DeleteDocuments(new Term("RowId", TextBox2.Text));
        indexReader.Close();
        
    }
}