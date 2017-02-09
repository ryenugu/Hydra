using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Hydra.Entities;

namespace Hydra.Models
{
    internal interface IProductsRepo
    {
    }


    public class ProductsRepo : IProductsRepo
    {
        private readonly IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["MpicombinedCopyConnectionString"].ConnectionString);
    }

    public static class MpiRepo
    {
        private static readonly IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["MpicombinedCopyConnectionString"].ConnectionString);


        public static IEnumerable<MpiHeader_Test> GetProducts()
        {
            string sqlstr = "select * from Mpiheader_Test";
            return _db.Query<MpiHeader_Test>(sqlstr).OrderBy(x => x.NAME);
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
}