using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Result.Ubigeo
{
    public class UbigeoResultado
    {
        public List<RegionResultadoDTO> Regiones { get; set; }
        public List<ProvinciaResultadoDTO> Provincias { get; set; }
        public List<DistritoResultadoDTO> Distritos { get; set; }

        public UbigeoResultado()
        {
            Regiones = new List<RegionResultadoDTO>();
            Provincias = new List<ProvinciaResultadoDTO>();
            Distritos = new List<DistritoResultadoDTO>();
        }
    }

    public class RegionResultadoDTO {
        public Int16 IdRegion { get; set; }
        public String RegionNombre { get; set; }
    }
    public class ProvinciaResultadoDTO {
        public Int16 IdProvincia { get; set; }        
        public String ProvinciaNombre { get; set; }
    }
    public class DistritoResultadoDTO {
       
        public Int16 IdDistrito { get; set; }        
        public String DistritoNombre { get; set; }

    }
}
