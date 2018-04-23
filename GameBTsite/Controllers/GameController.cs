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
        [Route("getlista")]
        [HttpGet]
        public List<ListaJucatori> GetLista(string filtru)
        {
            DbHelper db = new DbHelper();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("filtru", System.Data.ParameterDirection.Input, filtru ?? string.Empty));
            var result = db.ExecuteList<ListaJucatori>("lista_jucatori",parameters);

            return result;
        }
        [Route("getjucator")]
        [HttpGet]
        public ListaJucatori GetJucator(int id)
        {
            DbHelper db = new DbHelper();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("id", System.Data.ParameterDirection.Input, id ));
            var result = db.ExecuteSingle<ListaJucatori>("get_jucator", parameters);

            return result;
        }
        [Route("editusername")]
        [HttpPost]
        public int editusername([FromBody]edit request)
        {
            DbHelper db = new DbHelper();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("username", System.Data.ParameterDirection.Input, request.username));
            parameters.Add(new DbParameter("id", System.Data.ParameterDirection.Input, request.id));
            var result = db.ExecuteNonQuery("edit_username", parameters);
            return result;
        }
        [Route("deletejucator")]
        [HttpPost]
        public int deletejucator([FromBody]int id)
        {
            DbHelper db = new DbHelper();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new DbParameter("id", System.Data.ParameterDirection.Input, id));
           
            var result = db.ExecuteNonQuery("delete_jucator", parameters);
            return result;
        }
    }
}
