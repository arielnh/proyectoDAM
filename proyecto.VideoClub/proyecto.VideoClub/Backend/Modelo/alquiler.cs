//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto.VideoClub.Backend.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class alquiler
    {
        public int id_alquiler { get; set; }
        public Nullable<int> id_producto { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<System.DateTime> fecha_alquiler { get; set; }
        public Nullable<System.DateTime> fecha_prev_devolucion { get; set; }
        public Nullable<System.DateTime> fecha_devolucion { get; set; }
        public Nullable<int> recargo { get; set; }
        public Nullable<bool> devuelto { get; set; }
        public Nullable<int> id_tipo { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual tipo_alquiler tipo_alquiler { get; set; }
    }
}