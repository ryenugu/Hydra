using System.Collections.Generic;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Hydra.Entities;

namespace Hydra.Models
{

    public static class MpiConn
    {
        public static readonly IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["MpicombinedCopyConnectionString"].ConnectionString);
        public static SqlConnection con;
        //To Handle connection related activities      
        private static void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MpicombinedCopyConnectionString"].ToString();
            con = new SqlConnection(constr);

        }
    }
    public static class MpiRepo
    {
        private static readonly IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["MpicombinedCopyConnectionString"].ConnectionString);

        public static string TestDapper()
        {
            string sqlstr = "select * from Mpiheader_Test";
            return MpiConn._db.Query<MpiHeader_Test>(sqlstr).SingleOrDefault(u => u.CODE == "DODGX").NAME;
        }
        public static IEnumerable<MpiHeader_Test> GetProducts()
        {
            string sqlstr = "select * from Mpiheader_Test";
            return _db.Query<MpiHeader_Test>(sqlstr).OrderBy(x => x.NAME);
        }

        public static IEnumerable<ResDocModel> GetDocs(string id)
        {
            string sqlstr = "SELECT ManagerID,DocumentDate,DocumentLocation,DocumentDescription FROM HydraDocs where Managerid ='" + id + "'";
            return _db.Query<ResDocModel>(sqlstr).OrderByDescending(X => X.DocumentDate);
        }

        public static IOrderedEnumerable<MpiReturns_Test> GetAllReturns()
        {
            string sqlstr = "select * from Mpireturns_Test";
            return _db.Query<MpiReturns_Test>(sqlstr).OrderByDescending(x => x.Rtndate);
        }

        public static IEnumerable<MpiReturns_Test> GetReturns(string id)
        {
            string sqlstr = "select * from MpiReturns_Test where code='" + id + "'";
            return _db.Query<MpiReturns_Test>(sqlstr).OrderByDescending(x => x.Rtndate);
        }
    }

    public class ResDocModel
    {
        public int ManagerID { get; set; }
        public string DocumentLocation { get; set; }

        public string DocumentDescription { get; set; }
        public DateTime DocumentDate { get; set; }
    }
}