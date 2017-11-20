using Dapper;
using Hydra.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hydra.Models
{
    public class ShowCaseViewModel
    {
        public IEnumerable<MpiHeader_Test> ReturnItems { get; set; }
        public IEnumerable<MpiHeader_Test> EquityItems { get; set; }

        private static readonly IDbConnection _db =
            new SqlConnection(ConfigurationManager.ConnectionStrings["MpicombinedCopyConnectionString"].ConnectionString);

        public IEnumerable<MpiHeader_Test> GetProductReturns()
        {
            var resultList = _db.Query<MpiHeader_Test, MpiReturns_Test, MpiHeader_Test>(@"
                    SELECT a.Code, a.Name,
                            s.Code, s.Rtndate, s.Rtnvalue
                    FROM Mpiheader_Test a
                    INNER JOIN Mpireturns_Test s ON s.Code = a.Code
                    ", (a, s) =>
                {
                    a.MpiReturns_Test = s;
                    return a;
                },
                splitOn: "Code"
            ).AsQueryable();

            return resultList.AsList();
        }

        public List<MpiHeader_Test> GetEquityChars()
        {
            var resultList = _db.Query<MpiHeader_Test, MpiEquityChars_Test, MpiHeader_Test>(@"
                    SELECT a.Code, a.Name,
                            s.*
                    FROM Mpiheader_Test a
                    INNER JOIN Mpiequitychars_Test s ON s.Productid = a.Code
                    ", (a, s) =>
                {
                    a.MpiEquityChars_Test = s;
                    return a;
                },
                splitOn: "ProductId"
            ).AsQueryable();

            return
                new List<MpiHeader_Test>(resultList.AsList().OrderByDescending(x => x.MpiEquityChars_Test.PeriodEnding));
        }
    }
}