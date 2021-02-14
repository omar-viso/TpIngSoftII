using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class SubtotalHsOBDto
    {
        public int TareaID { get; set; }
        public string TareaNombre { get; set; }
        public decimal SubtotalHsOB { get; set; }
    }
}
