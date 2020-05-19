﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Tienda
    {
        public Int16 IdComercio { get; set; }
        public Byte IdDocumentoTipo { get; set; }
        public String NumeroDocumento { get; set; }
        public String ComercioNombre { get; set; }
        public String URL { get; set; }
        public Boolean? Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Int32 CreatedoPor { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Int32? ActualizadoPor { get; set; }
    }

}
