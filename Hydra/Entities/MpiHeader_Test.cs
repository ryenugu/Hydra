//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Dapper.Contrib.Extensions;
using System;

namespace Hydra.Entities
{


    public partial class MpiHeader_Test
    {
        
        public MpiHeader_Test()
        {
            MpiReturns_Test = new MpiReturns_Test();
            MpiEquityChars_Test = new MpiEquityChars_Test();
            MpiFixedIncomeChars_Test = new MpiFixedIncomeChars_Test();
        }
    
        [Key]
        public string CODE { get; set; }

        public int? AssetClassId { get; set; }
        public string NAME { get; set; }
        public string PROVIDER { get; set; }
        public string HCAUNIVERSE { get; set; }
        public string TICKER { get; set; }
        public string CUSIP { get; set; }
        public double? MINIMUM { get; set; }

        

        public string GROSSNET { get; set; }
        public double? EXPENSERATIO { get; set; }
        public string PORTDATE { get; set; }
        public string ASSETCLASS { get; set; }
        public string OPENCLOSED { get; set; }
        public string MGRBENCHMARK { get; set; }
        public string HCABENCHMARK { get; set; }
        public double? ASSETS { get; set; }
        public string AlternateMappingID { get; set; }
        public string MapReturns { get; set; }
        public string MapReturnsBeforeOrAfter { get; set; }
        public DateTime? InceptionDate { get; set; }
        public string FootNote { get; set; }
        public string IsIndex { get; set; }
        public string SubType { get; set; }
        public string PrimaryBMID { get; set; }
        public string StylusTemplate { get; set; }
        public int? ACID { get; set; }
        public int? StylusUnvID { get; set; }
        public int? StylusFundID { get; set; }
    
        
        public virtual MpiReturns_Test MpiReturns_Test { get; set; }
        public virtual MpiEquityChars_Test MpiEquityChars_Test { get; set; }
        public virtual MpiFixedIncomeChars_Test MpiFixedIncomeChars_Test { get; set; }
    }
}
