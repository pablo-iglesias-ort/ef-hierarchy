using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Models
{
	public class Administrador : Usuario
	{
		// Propiedades de la entidad

		public override Rol Rol => Rol.Administrador;


		// Relaciones con otras entidades
	}
}