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
    
    public partial class Asesoria
    {
        public string Razon_ases { get; set; }
        public string Estado_caso { get; set; }
        public string Diligencia { get; set; }
        public string Evento_ases { get; set; }
        public int Solicitud_id_solicitud { get; set; }
        public int Actividad_id_act { get; set; }
        public string Estado { get; set; }
    
        public virtual Actividad Actividad { get; set; }
    }
}
