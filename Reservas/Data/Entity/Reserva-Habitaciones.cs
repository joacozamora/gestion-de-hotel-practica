using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.BData.Data.Entity
{
	public class Reserva_Habitaciones
	{
		public int id { get; set; }
		public int NumHab { get; set; }
		public int idRes { get; set; }
		public int ResPersonid { get; set; }
	}
}
