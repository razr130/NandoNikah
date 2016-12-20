using GuestBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Dapper;


namespace GuestBook.DAL
{
    public class TamuDAL : IDisposable
    {

        private string GetConnstr()
        {
            return ConfigurationManager.ConnectionStrings["GuestBookModels"].ConnectionString;
        }

        private GuestBookModel db = new GuestBookModel();

        public IQueryable<Tamu> GetData()
        {
            var results = from a in db.Tamus
                          orderby a.firstname
                          select a;
            return results;
        }

        public IQueryable<Tamu> GetDataByUsername(string user)
        {
            var result = from a in db.Tamus
                          where a.username == user
                          select a;

            return result;
        }

        public IQueryable<Tamu> Search(string txtsearch)
        {
            var results = from m in db.Tamus
                          where m.firstname.ToLower().Contains(txtsearch.ToLower())
                          select m;
            return results;
        }
        //public IEnumerable<Tamu> Search(string txtsearch)
        //{
        //    using (SqlConnection conn = new SqlConnection(GetConnstr()))
        //    {
        //        string strsql = @"select * from Tamu where firstname='" + txtsearch + "'";


        //        return conn.Query<Tamu>(strsql);
        //    }
        //}
        public Tamu GetDataById(int id)
        {
            var result = (from a in db.Tamus
                          where a.Id == id
                          select a).SingleOrDefault();

            return result;
        }
        public void Add(Tamu obj)
        {
            try
            {
                db.Tamus.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public void Edit(Tamu obj)
        {
            var model = GetDataById(obj.Id);

            if (model != null)
            {
                model.firstname = obj.firstname;
                model.lastname = obj.lastname;
                model.username = obj.username;
                model.email = obj.email;
                model.pesan = obj.pesan;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan !");
            }
        }

        public void Delete(int id)
        {
            var model = GetDataById(id);
            if (model != null)
            {
                try
                {
                    db.Tamus.Remove(model);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan !");
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}