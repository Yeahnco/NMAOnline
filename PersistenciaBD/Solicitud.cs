//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersistenciaBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solicitud
    {
        public int id_solicitud { get; set; }
        public string Razon_soli { get; set; }
        public int Profesional_id_prof { get; set; }
        public int Gerente_id_gerente { get; set; }
    
        public virtual Gerente Gerente { get; set; }
    }
}
