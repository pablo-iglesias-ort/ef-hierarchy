using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Entity_Framework.Models
{
	public abstract class Usuario
	{
		// Propiedades de la entidad

		[Key]
		public Guid Id { get; set; }

		[MaxLength(20, ErrorMessage = "La longitud máxima es {1}")]
		[MinLength(8, ErrorMessage = "La longitud mínima es {1}")]
		[Display(Name = "Usuario")]
		public string User { get; set; }

		[ScaffoldColumn(false)]
		public byte[] Contraseña { get; set; }

		[Required(ErrorMessage = "Este campo es requerido")]
		[Range(1, 999999999, ErrorMessage = "El valor debe estar entre {1} y {2}")]
		public int Dni { get; set; }

		[Required(ErrorMessage = "El {0} es requerido")]
		[MaxLength(40, ErrorMessage = "El maximo permitido para el {0} es {1}")]
		public string Nombre { get; set; }		

		[Required(ErrorMessage = "El {0} es requerido")]
		[MaxLength(80, ErrorMessage = "El maximo permitido para el {0} es {1}")]
		public string Apellido { get; set; }

		[Required(ErrorMessage = "Debe informar su fecha de nacimiento")]
		[Display(Name = "Fecha de Nacimiento")]
		[DataType(DataType.Date)]
		public DateTime FechaDeNacimiento { get; set; }

		public abstract Rol Rol { get; }


		// Relaciones con otras entidades		
	}
}
