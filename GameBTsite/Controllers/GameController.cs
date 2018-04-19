using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static GameBTsite.DbHelper;
namespace GameBTsite.Controllers
{
    [RoutePrefix("api/test")]
    public class GameController : ApiController
    {


        [Route("save")]
        [HttpPost]

        public int Save([FromBody]SalveazaJucator request)
        {
            DbHelper db = new DbHelper();
            List<DbParameter> parameters = new List<DbParameter>();

            parameters.Add(new DbParameter("username", System.Data.ParameterDirection.Input, request.username));
            parameters.Add(new DbParameter("scor", System.Data.ParameterDirection.Input, request.scor));
            var result = db.ExecuteNonQuery("insereaza_jucator", parameters);
            return result;
        }
    }
}
