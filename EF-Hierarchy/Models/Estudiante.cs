using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Entity_Framework.Models
{
	public class Estudiante : Usuario
	{
		// Propiedades de la entidad

		public override Rol Rol => Rol.Estudiante;

		// Relaciones con otras entidades

		public Contacto Contacto { get; set; }

		public IEnumerable<Calificacion> Calificaciones { get; set; }

		public IEnumerable<MateriaEstudiante> Materias { get; set; }
	}
}
