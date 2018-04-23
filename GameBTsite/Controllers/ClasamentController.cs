using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameBTsite.Controllers
{
    public class ClasamentController : Controller
    {
        // GET: Clasament
        public async Task<ActionResult> Index(string filtru = "", string orderBy = "")
        {
            var lista = await RequestHelper.MakeGetRequest<List<ListaJucatori>>(string.Format("test/getlista/?filtru={0}", filtru));
            if(orderBy == "data")
            {
                lista = lista.OrderBy(l => l.data).ToList();
            }
            if(orderBy == "scor")
            {
                lista = lista.OrderByDescending(l => l.scor).ToList();
            }
            return View(lista);
        }

        // GET: Clasament/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clasament/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clasament/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clasament/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var jucator = await RequestHelper.MakeGetRequest<ListaJucatori>(string.Format("test/getjucator/?id={0}", id));
            return View(jucator);
        }

        // POST: Clasament/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string username = collection["username"];
                var edit = new edit
                {
                    username = username,
                    id = id
                };
                var respPost = RequestHelper.MakePostRequest<int>("test/editusername/", edit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clasament/Delete/5
        public ActionResult Delete(int id)
        {
            var respPost = RequestHelper.MakePostRequest<int>("test/deletejucator/", id);
            return RedirectToAction("Index");
        }

        // POST: Clasament/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
