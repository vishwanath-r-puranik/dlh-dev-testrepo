using System;
namespace TestPermitMicroFrontEnd.Models
{
    public class TestPermit
    {
        public TestPermit()
        {
        }

        public int ID { get; set; }

        public string PrmtNo { get; set; }

        public string PrmtTypeCD { get; set; }

        public string StatCD { get; set; }

        public string CLSexCD { get; set; }

        public string NChrgSrvFlag { get; set; }

        public string SaleTypeCD { get; set; }

        public string TestRstlCD { get; set; }

        public string SaleBlkFlag { get; set; }

        public DateTime AccPit { get; set; }

        public DateTime DefnPit { get; set; }

        public int DefnMVID { get; set; }

        public string UpdSrvTxNo { get; set; }

        public string UpdReasCD { get; set; }

        public DateTime SaleDefnPit { get; set; }

        public int SaleDefnMVID { get; set; }

        public string SaleSrvTxNo { get; set; }

        public string SaleOffID { get; set; }

        public int PrchMVID { get; set; }

        public string DrxID { get; set; }

        public string OclCD { get; set; }

        public DateTime RsltDefnPit { get; set; }

        public int RsltDefnMVID { get; set; }

        public string RsltOpSrvTxNo { get; set; }

        public DateTime TestDt { get; set; }

        public int CLMVID { get; set; }

        public DateTime CLDoB { get; set; }

        public string CLName { get; set; }

        public string CLCity { get; set; }

        public string CLPCode { get; set; }

        public string AdvRoadTestInd { get; set; }
    }
}
