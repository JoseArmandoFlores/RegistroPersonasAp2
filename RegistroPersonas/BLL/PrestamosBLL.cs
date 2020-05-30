using Microsoft.EntityFrameworkCore;
using RegistroPersonas.DAL;
using RegistroPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroPersonas.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.PrestamoId))
                return Insertar(prestamo);
            else
                return Modificar(prestamo);
        }

        private static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;
                contexto.Prestamos.Add(prestamo);
                paso = contexto.SaveChanges() > 0;

                GuardarBalance(prestamo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;
                ModificarBalance(prestamo);
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamo = contexto.Prestamos.Find(id);

                if (prestamo != null)
                {
                    EliminarBalance(prestamo);
                    contexto.Prestamos.Remove(prestamo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamo;

            try
            {
                prestamo = contexto.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return prestamo;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Personas.Any(e => e.PersonasId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static void GuardarBalance(Prestamos prestamo)
        {
            Personas personas = new Personas();

            personas = PersonasBLL.Buscar(prestamo.PersonaId);
            personas.Balance += prestamo.Balance;

            PersonasBLL.Modificar(personas);
        }

        public static void ModificarBalance(Prestamos prestamo)
        {
            Personas persona = new Personas();
            Prestamos anteriorPrestamo = new Prestamos();

            persona = PersonasBLL.Buscar(prestamo.PersonaId);
            anteriorPrestamo = PrestamosBLL.Buscar(prestamo.PrestamoId);

            persona.Balance -= anteriorPrestamo.Balance;
            persona.Balance += prestamo.Balance;

            PersonasBLL.Modificar(persona);
        }

        public static void EliminarBalance(Prestamos prestamo)
        {
            Personas persona = new Personas();

            persona = PersonasBLL.Buscar(prestamo.PersonaId);
            persona.Balance -= prestamo.Balance;

            PersonasBLL.Modificar(persona);
        }

    }
}

