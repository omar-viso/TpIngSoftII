﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class Proyecto : IEntityBase
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Nombre { get; set; }
        public int ProyectoEstadoID { get; set; }
        public virtual ProyectoEstado ProyectoEstado { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        //private List<Tarea> tareas = new List<Tarea>();

        /*
        public enum Estado
        {
            Vigente,
            Finalizado,
            Pausado,
            Cancelado
        }
        
        public void agregarTareas(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        public void eliminarTarea(int idTarea)
        {
            foreach (Tarea tarea in tareas)
            {
                if (tarea.Id == idTarea)
                {
                    tareas.Remove(tarea);
                }
            }
        }

        public List<Tarea> ObtenerTareas()
        {
            return tareas;
        }

        //se desea saber la cantidad de horas trabajadas por cada proyecto por tipo de perfil
        public float ObtenerHorasTPerfil(int idPerfil)
        {
            float horasT = 0;
            foreach (Tarea tarea in tareas)
            {
                if (tarea.IdPerfil == idPerfil)
                {
                    foreach (HorasTrabajadas ht in tarea.ObtenerHorasTrabajadas())
                    {
                        horasT += ht.CantHoras;
                    }
                }
            }
            return horasT;
        }
        */
    }
}
