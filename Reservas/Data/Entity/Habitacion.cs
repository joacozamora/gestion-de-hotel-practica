using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Reservas.BData.Data.Entity
{
    //[Index(nameof(Nhab), Name = "Habitacion_Nhab_UQ", IsUnique=true)]

    //[PrimaryKey(nameof(Nhab))]
    public class Habitacion
    {
		public int Nhab { get; set; }

        [Required(ErrorMessage = "El numero de camas es Obligatorio")]
        public int camas { get; set; }

        [Required(ErrorMessage = "El estado es Obligatorio")]
        public string Estado { get; set; } = "";

        [Required(ErrorMessage = "El Precio es Obligatorio")]
        public decimal Precio { get; set; }
        public decimal Senia { get; set; }

        public static implicit operator Habitacion(List<Habitacion> v)
        {
            throw new NotImplementedException();
        }
    }
}
