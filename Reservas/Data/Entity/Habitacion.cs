using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Reservas.BData.Data.Entity
{
    //[Index(nameof(Nhab), Name = "Habitacion_Nhab_UQ", IsUnique=true)]

    //[PrimaryKey(nameof(Nhab))]
    public class Habitacion
    {
        public int Id { get; set; }
		public int Nhab { get; set; }

        [Required(ErrorMessage = "El numero de camas es Obligatorio")]
        public int Camas { get; set; }

        [Required(ErrorMessage = "El estado es Obligatorio")]
        public string Estado { get; set; } = "";

        [Required(ErrorMessage = "El Precio es Obligatorio")]
        public int Precio { get; set; }
        public int Garantia { get; set; }

        public static implicit operator Habitacion(List<Habitacion> v)
        {
            throw new NotImplementedException();
        }
    }
}
