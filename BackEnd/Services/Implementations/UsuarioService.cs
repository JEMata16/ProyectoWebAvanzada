using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        IUnidadDeTrabajo _unidad;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }

        UsuarioModel Convertir(Usuario usuario)
        {
            return new UsuarioModel
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                Contraseña = usuario.Contraseña,
                RolId = usuario.RolId,
            };
        }
        Usuario Convertir(UsuarioModel usuario)
        {
            return new Usuario
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                CorreoElectronico = usuario.CorreoElectronico,
                Contraseña = usuario.Contraseña,
                RolId = usuario.RolId,
            };
        }
        public Task<bool> Add(UsuarioModel usuario)
        {
            _unidad._usuarioDAL.Add(Convertir(usuario));
            var result = _unidad.Complete();
            return Task.FromResult(result);
        }

        public Task<bool> Delete(int id)
        {
            Usuario usuario = new Usuario { UsuarioId = id };
            _unidad._usuarioDAL.Remove(usuario);
            var result = _unidad.Complete();
            return Task.FromResult(result);
        }

        public Task<UsuarioModel> GetUsuarioById(int id)
        {
            Usuario usuario = _unidad._usuarioDAL.Get(id);
            return Task.FromResult(Convertir(usuario));
        }

        public Task<List<UsuarioModel>> GetUsuarios()
        {
            var Usuarios = _unidad._usuarioDAL.GetAll();
            List<UsuarioModel> lista = new List<UsuarioModel>();
            foreach(var  usuario in Usuarios)
            {
                lista.Add(Convertir(usuario));
            }
            return Task.FromResult(lista);
        }

        public Task<bool> Update(UsuarioModel usuario)
        {
            _unidad._usuarioDAL.Update(Convertir(usuario));
            var result = _unidad.Complete();
            return Task.FromResult(result);
        }
    }
}
