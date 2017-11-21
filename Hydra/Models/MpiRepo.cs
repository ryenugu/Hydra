using Dapper;
using Hydra.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public static IEnumerable<Manager> FillManagers(string search)
        {
            string sqlstr = "select ManagerId,ManagerName from  TblManagers where ManagerName like '" + search + "'";

            return _db.Query<Manager>(sqlstr).OrderBy(x => x.ManagerName);
        }

        public static IEnumerable<Manager> FillManagers()
        {
            string sqlstr = "select ManagerId,ManagerName from  TblManagers";

            return _db.Query<Manager>(sqlstr).OrderBy(x => x.ManagerName);
        }
    }

    public class Manager
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }

    public class ResDocModel
    {
        public int ManagerID { get; set; }
        public string DocumentLocation { get; set; }
        public string DocumentDescription { get; set; }
        public DateTime DocumentDate { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Product : MpiHeader_Test
    {
        public string Code;
        public string Name { get { return NAME; } set { NAME = Name; } }
        public string Type { get { return SubType; } set { Type = SubType; } }
        public bool? isIndex { get; set; }
    }
}