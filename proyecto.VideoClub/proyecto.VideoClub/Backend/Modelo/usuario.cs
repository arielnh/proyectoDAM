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
    using proyecto.VideoClub.MVVM;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class usuario : PropertyChangedDataError
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.alquiler = new HashSet<alquiler>();
            this.incidencia = new HashSet<incidencia>();
        }
    
        public int id_usuario { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30)]
        public string apellido_1 { get; set; }
        [MaxLength(30)]
        public string apellido_2 { get; set; }
        [MaxLength(100)]
        public string direccion { get; set; }
        [MaxLength(60)]
        public string mail { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30)]
        public string telefono { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30)]
        public string usuario1 { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(30)]
        public string contraseña { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int id_rol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alquiler> alquiler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incidencia> incidencia { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public virtual rol rol { get; set; }
    }
}
