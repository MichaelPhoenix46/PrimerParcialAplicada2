using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamoRepositorio : RepositorioBase<Prestamo>
    {
        public override bool Guardar(Prestamo entity)
        {
            bool paso = false;
            try
            {
                if (_contexto.Set<Prestamo>().Add(entity) != null)
                {
                    _contexto.Cuenta.Find(entity.CuentaId).Balance += entity.Capital;
                    _contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                Prestamo entity = _contexto.Set<Prestamo>().Find(id);
                _contexto.Cuenta.Find(entity.CuentaId).Balance -= entity.Capital;
                _contexto.Set<Prestamo>().Remove(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override bool Modificar(Prestamo entity)
        {
            bool paso = false;
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            try
            {
                var prestamoAnterior = repositorio.Buscar(entity.PrestamoId);
                var cuenta = _contexto.Cuenta.Find(entity.CuentaId);
                var cuentaAnterior = _contexto.Cuenta.Find(prestamoAnterior.CuentaId);
                if (entity.CuentaId != prestamoAnterior.CuentaId)
                {
                    cuenta.Balance += entity.Capital;
                    cuentaAnterior.Balance -= prestamoAnterior.Capital;
                }
                decimal diferencia;
                diferencia = entity.Capital - prestamoAnterior.Capital;
                cuenta.Balance += diferencia;
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
    }
}
