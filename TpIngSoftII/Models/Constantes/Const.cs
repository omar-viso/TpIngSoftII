using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpIngSoftII.Models.Constantes
{
    public class Const
    {
        public static class HoraTrabajadaEstado
        {
            public const int Pagada = 1;
            public const int Adeudada = 2;
        }

        public static class TipoPersona
        {
            public const int Fisica = 1;
            public const int Juridica = 2;
        }

        public static class ProyectoEstado
        {
            public const int Vigente = 1;
            public const int Pausado = 2;
            public const int Cancelado = 3;
            public const int Finalizado = 4;
        }
    }
}
