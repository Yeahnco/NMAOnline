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
    
    public partial class Act_de_mejora
    {
        public string Nombre_act_mejora { get; set; }
        public string Descripcion_act_mejora { get; set; }
        public int Actividad_id_act { get; set; }
    
        public virtual Actividad Actividad { get; set; }
    }
}
