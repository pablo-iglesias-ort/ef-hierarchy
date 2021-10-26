using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Entity_Framework.Models
{
	public class Docente : Usuario
	{
		// Propiedades de la entidad

		public override Rol Rol => Rol.Docente;

		[Required(ErrorMessage = "Este campo es requerido")]
		[RegularExpression("^[0-9]{2}-[0-9]{8}-[0-9]{1}", ErrorMessage = "{0} con formato incorrecto")]		
		public string Cuil { get; set; }


		// Relaciones con otras entidades

		public IEnumerable<Materia> Materias { get; set; }
	}
}
