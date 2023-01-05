using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using TestPermitMicroFrontEnd.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace TestPermitMicroFrontEnd.Pages
{
    public class TestPermitDisplayModel : PageModel
    {
        public string testPermitNumber { get; set; }
        public string lastUpdate { get; set; }
        public string updatedBy { get; set; }
        public string clientMVID { get; set; }
        public string clientName { get; set; }
        public string clientAddress { get; set; }
        public string dob { get; set; }
        public string sex { get; set; }
        public string blockPermit { get; set; }
        public string permitType { get; set; }
        public string vClass { get; set; }
        public string noCharge { get; set; }
        public string advance { get; set; }
        public string status { get; set; }
        public string saleDate { get; set; }
        public string saleTx { get; set; }
        public string saleClerk { get; set; }
        public string saleOffice { get; set; }
        public string saleType { get; set; }
        public string purchaseClient { get; set; }
        public string resultDate { get; set; }
        public string resultTx { get; set; }
        public string resultClerk { get; set; }
        public string testDate { get; set; }
        public string driverExaminer { get; set; }
        public string reason { get; set; }
        public string lastUpdate2 { get; set; }

        private readonly ILogger _logger;

        public TestPermitDisplayModel(ILogger<TestPermitDisplayModel> logger)
        {
            _logger = logger;
        }

        public void OnGet([FromQuery(Name = "testpermitno")] string testpermitno)
        {

            Task<TestPermit> t = Task.Run(() => GetTestPermit(testpermitno));

            t.Wait();

            TestPermit testPermit = t.Result;

            if (testPermit != null)
            {
                testPermitNumber = testPermit.PrmtNo;
                lastUpdate = testPermit.DefnPit.ToShortDateString();
                updatedBy = testPermit.DefnMVID.ToString();
                clientMVID = testPermit.CLMVID.ToString();
                clientName = testPermit.CLName;
                clientAddress = testPermit.CLPCode;
                dob = testPermit.CLDoB.ToShortDateString();
                sex = testPermit.CLSexCD;
                blockPermit = testPermit.SaleBlkFlag;
                permitType = testPermit.PrmtTypeCD;
                vClass = testPermit.OclCD;
                noCharge = testPermit.NChrgSrvFlag;
                advance = testPermit.AdvRoadTestInd;
                status = testPermit.StatCD;
                saleDate = testPermit.SaleDefnPit.ToShortDateString();
                saleTx = testPermit.SaleSrvTxNo;
                saleClerk = testPermit.SaleDefnMVID.ToString();
                saleOffice = testPermit.SaleOffID;
                saleType = testPermit.SaleTypeCD;
                purchaseClient = testPermit.PrchMVID.ToString();
                resultDate = testPermit.RsltDefnPit.ToShortDateString();
                resultTx = testPermit.RsltOpSrvTxNo;
                resultClerk = testPermit.RsltDefnMVID.ToString();
                testDate = testPermit.TestDt.ToShortDateString();
                driverExaminer = testPermit.DrxID;
                reason = testPermit.UpdReasCD;
                lastUpdate2 = testPermit.UpdSrvTxNo;

                _logger.LogInformation("Test Permit Acccess " + testPermit.PrmtNo + " by IP " + Request.HttpContext.Connection.RemoteIpAddress);
            }
        }

        public static async Task<TestPermit> GetTestPermit(string tpNo)
        {
            TestPermit testPermit = null;

            var url = $"https://testpermit-micro-api-testpermit.apps.moves.hcscloud.net/api/TestPermit";
            if (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("TESTPERMIT_MICROSERVICES_API_URL")))
            {
                url = Environment.GetEnvironmentVariable("TESTPERMIT_MICROSERVICES_API_URL");
            }

            url = url + "/ByPrmtNo/" + tpNo;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //string json = JsonConvert.SerializeObject(op);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await client.GetAsync(""))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                testPermit = JsonConvert.DeserializeObject<TestPermit>(apiResponse);
                
            }
            return testPermit;
        }
    }
}
