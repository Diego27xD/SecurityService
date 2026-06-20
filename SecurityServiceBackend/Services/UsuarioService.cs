using SecurityServiceBackend.Data;
using SecurityServiceBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace SecurityServiceBackend.Services
{
    public interface IUsuarioService
    {
        Task<Usuario?> ValidarCredencialesAsync(string usuario, string password);
        Task<bool> ExisteUsuarioAsync(string usuario);
        Task<Usuario> RegistrarUsuarioAsync(string usuario, string nombre);
        Task<bool> CambiarPasswordAsync(int usuarioId, string passwordActual, string passwordNueva);
        Task<Usuario?> ObtenerPorIdAsync(int id);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public UsuarioService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<Usuario?> ValidarCredencialesAsync(string usuario, string password)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == usuario);

            if (user == null) return null;

            bool esValida = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            return esValida ? user : null;
        }

        public async Task<bool> ExisteUsuarioAsync(string usuario)
        {
            return await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario);
        }

        public async Task<Usuario> RegistrarUsuarioAsync(string usuario, string nombre)
        {
            string passwordGenerica = _config["Usuarios:PasswordGenerica"] ?? "Cambio123*";

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = usuario,
                Nombre = nombre,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordGenerica),
                RequiereCambioPassword = true,
                FechaCreacion = DateTime.UtcNow
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return nuevoUsuario;
        }

        public async Task<bool> CambiarPasswordAsync(int usuarioId, string passwordActual, string passwordNueva)
        {
            var user = await _context.Usuarios.FindAsync(usuarioId);
            if (user == null) return false;

            if (!BCrypt.Net.BCrypt.Verify(passwordActual, user.PasswordHash))
                return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordNueva);
            user.RequiereCambioPassword = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
