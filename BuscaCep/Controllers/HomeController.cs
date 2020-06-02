using System.Web.Mvc;

namespace BuscaCep.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // POST: ConsultarCep
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ConsultarCep(string cep)
        {
            BuscaCep.Correios.enderecoERP endereco = null;

            using (BuscaCep.Correios.AtendeClienteClient correios = new BuscaCep.Correios.AtendeClienteClient())
            {
                endereco = correios.consultaCEP(cep);
            }

            return Json(endereco);
        }
    }
}