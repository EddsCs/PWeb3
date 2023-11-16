using Microsoft.AspNetCore.Mvc;
using Proyect_web_def.Models;


using Proyect_web_def.Models;
using Proyect_web_def.Logica;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
namespace Proyect_web_def.Controllers
{
    public class AccesoController : Controller
    {
       
        
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Usuario objeto = new LO_Usuario().EncontrarUsuario(correo, clave);


           if (objeto.Nombres != null)
            {
                /*FormsAuthentication.SetAuthCookie(objeto.Correo, false);

                Session["Usuario"] = objeto;*/


                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
