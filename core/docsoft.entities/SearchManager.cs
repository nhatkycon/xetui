using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using linh.common;
using Version = Lucene.Net.Util.Version;
namespace docsoft.entities
{
    public class SearchManager
    {
        public static string Dic
        {
            get
            {
                return HostingEnvironment.MapPath("~/index/");
            }
        }
        public static void Add(string ten, string noiDung, string alias, string rowId, string url, string loai)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            var doc = new Document();
            doc.Add(new Field("Ten", ten, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("Loai", loai, Field.Store.YES, Field.Index.NOT_ANALYZED));
            doc.Add(new Field("NoiDung", noiDung, Field.Store.YES,
                              Field.Index.ANALYZED));
            doc.Add(new Field("RowId", rowId, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Url", url, Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
            writer.Optimize();
            writer.Commit();
            writer.Close();

        }
        public static void ReIndex()
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
        public static List<Obj> Search(string q)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var indexReader = IndexReader.Open(directory, true);
            var indexSearch = new IndexSearcher(indexReader);
            var queryParser = new QueryParser(Version.LUCENE_29, "NoiDung", analyzer);
            var query = queryParser.Parse(q);

            var resultDocs = indexSearch.Search(query, indexReader.MaxDoc());
            var hits = resultDocs.scoreDocs;
            var list = hits.Select(hit => indexSearch.Doc(hit.doc)).Select(documentFromSearcher => new Obj()
                                                                                                       {
                                                                                                           Kieu = documentFromSearcher.Get("Loai")
                                                                                                           , RowId = new Guid(documentFromSearcher.Get("RowId"))
                                                                                                           , Url = documentFromSearcher.Get("Url")
                                                                                                           , NoiDung = documentFromSearcher.Get("NoiDung")
                                                                                                           , Ten = documentFromSearcher.Get("Ten")
                                                                                                       }).ToList();
            indexSearch.Close();
            directory.Close();
            return list;
        }
        public static void Remove(Guid rowid)
        {
            var directory = FSDirectory.Open(new DirectoryInfo(Dic));
            var indexReader = IndexReader.Open(directory, false);
            indexReader.DeleteDocuments(new Term("RowId", rowid.ToString()));
            indexReader.Close();
        }
        public static void Remove(string rowid)
        {
            Remove(new Guid(rowid));
        }
    }
}
