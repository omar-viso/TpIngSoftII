using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class Cliente : IEntityBase
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int? TelefonoFijo { get; set; }
        public int? TelefonoCelular { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }

        /*
        public void agregarProyecto(Proyecto proyecto)
        {
            Proyectos.Add(proyecto);
        }

        public Proyecto GetProyecto(int idProyecto)
        {
            Proyecto p = null;
            foreach (Proyecto proyecto in Proyectos)
            {
                if (proyecto.ID == idProyecto)
                {
                    p = proyecto;
                }
            }
            return p;
        }

        public List<Proyecto> ObtenerProyectos()
        {
            return Proyectos;
        }

        public void eliminarProyecto(int idProyecto)
        {
            foreach (Proyecto proyecto in Proyectos)
            {
                if (proyecto.ID == idProyecto)
                {
                    Proyectos.Remove(proyecto);
                }
            }
        }
        */
    }
}
