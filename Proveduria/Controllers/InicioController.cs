using Microsoft.AspNetCore.Mvc;
using Proveduria.Models;
using Proveduria.Recursos;
using Proveduria.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Proveduria.Servicios.Contrato;
using Proveduria;
using System.Diagnostics;

namespace Proveduria.Controllers
{



    public class InicioController : Controller
    {

        private readonly IUsuarioService _usuarioServicio;
        private readonly IConfiguration _configuration;

        public InicioController(IUsuarioService usuarioServicio, IConfiguration configuration)
        {
            _usuarioServicio = usuarioServicio;
            _configuration = configuration;
        }



        public IActionResult Registrarse()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario model)
        {
            if (model.Contasena != null)
            {
                model.Contasena = Utilidades.EncriptarClave(model.Contasena);
            }

            Usuario usuarioCreado = await _usuarioServicio.SaveUsuarios(model);

            if (usuarioCreado.IdUsuario > 0)
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }

            ViewData["Mensaje"] = "Usuario no encontrado";

            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string contrasena)
        {
            // Punto de interrupción
            Debug.WriteLine($"Intentando iniciar sesión con correo: {correo} y contraseña: {contrasena}");

            Usuario usuarioEncontrado = await _usuarioServicio.GetUsuarios(correo, Utilidades.EncriptarClave(contrasena));

            

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron Coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, usuarioEncontrado.NombreUsuario)
    };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }














    }


}

