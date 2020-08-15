using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;

namespace StockAnalyzer.Web.Controllers
{
    public class StocksController : ApiController
    {
        [Route("api/stocks/{ticker}")] 
        public async Task<IHttpActionResult> Get(string ticker)
        {
            var Ticker = ticker.ToUpper();
            var store = new DataStore(HostingEnvironment.MapPath("~/bin"));

            var data = await store.LoadStocks();

            if (!data.ContainsKey(Ticker)) 
                return NotFound();


            Thread.Sleep(5000);
            return Json(data[Ticker]);
        }
    }
}