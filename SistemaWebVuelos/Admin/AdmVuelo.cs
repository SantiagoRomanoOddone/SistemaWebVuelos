using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//a

namespace SistemaWebVuelos.Admin
{
    public static class AdmVuelo
    {
        private static VueloDbContext context = new VueloDbContext();
        public static List<Vuelo> Listar()
        {
            return context.Vuelos.ToList();
        }
        public static Vuelo Listar(int id)
        {
            return context.Vuelos.Find(id);
        }
        public static Vuelo Buscar(int id)
        {
            Vuelo vuelo = context.Vuelos.Find(id);
            context.Entry(vuelo).State = EntityState.Detached;
            return vuelo;
        }

        public static void Crear(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            context.SaveChanges();
        }

        public static void Eliminar(Vuelo vuelo)
        {
            context.Vuelos.Remove(vuelo);
            context.SaveChanges();
        }
        public static void Modificar(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.SaveChanges();
        }
        public static List<Vuelo> ListarDestino(string destino)
        {
            List<Vuelo> vueloDestino = (from m in context.Vuelos
                                                where m.Destino == destino
                                                select m).ToList();
            return vueloDestino;
        }




    }
}