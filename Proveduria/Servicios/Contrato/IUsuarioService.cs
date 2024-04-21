using Proveduria.Models;
using Microsoft.EntityFrameworkCore;

namespace Proveduria.Servicios.Contrato
{
    public interface IUsuarioService
    {

        Task<Usuario> GetUsuarios(string correo, string Contasena);

        Task<Usuario> SaveUsuarios(Usuario modelo);





    }
}
