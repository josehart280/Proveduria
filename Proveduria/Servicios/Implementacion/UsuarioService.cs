using Microsoft.EntityFrameworkCore;
using Proveduria.Models;
using Proveduria.Servicios.Contrato;
using System.Linq;
using System.Threading.Tasks;
using Proveduria.Models;
using System.Configuration;

namespace Proveduria.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ProveeduriaPiiContext _dbContext;

        public UsuarioService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProveduriaWebContext");
            var optionsBuilder = new DbContextOptionsBuilder<ProveeduriaPiiContext>();
            optionsBuilder.UseSqlServer(connectionString);

            _dbContext = new ProveeduriaPiiContext(optionsBuilder.Options);

        }

        public async Task<Usuario> GetUsuarios(string correo, string Contasena)
        {
            Usuario usuario_Encontrado = await _dbContext.Usuario
                .Where(u => u.Correo == correo && u.Contasena == Contasena)
                .FirstOrDefaultAsync();

            return usuario_Encontrado;
        }


        public async Task<Usuario> SaveUsuarios(Usuario modelo)
        {
            _dbContext.Usuario.Add(modelo);
            await _dbContext.SaveChangesAsync();

            return modelo;
        }
    }
}
