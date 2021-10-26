using MVC_Entity_Framework.Controllers;
using MVC_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Entity_Framework.Data
{
	public static class InicializacionDeDatos
	{
		public static readonly ISeguridad seguridad = new SeguridadBasica();

		public static void Inicializar(MVC_Entity_FrameworkContext context)
		{
			context.Database.EnsureCreated();

			if (!context.Docentes.Any())
			{
				var usuarioDocente = new Docente
				{
					Id = Guid.NewGuid(),
					Nombre = "Docente",
					Apellido = "Docente",
					Dni = 50123456,
					Cuil = "20-50123456-01",
					FechaDeNacimiento = DateTime.Now.AddYears(-30),					
					User = "docente",
					Contraseña = seguridad.EncriptarPass("docente"),					
				};
				context.Docentes.AddRange(usuarioDocente);
				context.SaveChanges();
			}

			if (!context.Estudiantes.Any())
			{
				var usuarioEstudiante = new Estudiante
				{
					Id = Guid.NewGuid(),
					Nombre = "Estudiante",
					Apellido = "Estudiante",
					Dni = 40123456,
					FechaDeNacimiento = DateTime.Now.AddYears(-20),
					User = "estudiante",
					Contraseña = seguridad.EncriptarPass("estudiante"),
				};
				context.Estudiantes.Add(usuarioEstudiante);

				var nuevoContacto = new Contacto
				{
					Celular = 1134347879,
					Email = "estudiante@estudiante.com",
					EstudianteId = usuarioEstudiante.Id,
					Facebook = "FB",
					Instagram = "IG",
					Twitter = "TW",					
				};
				context.Contactos.Add(nuevoContacto);
				context.SaveChanges();
			}

			if (!context.Administradores.Any())
			{
				var usuarioAdministrador = new Administrador
				{
					Id = Guid.NewGuid(),
					Nombre = "Admin",
					Apellido = "Admin",
					Dni = 20123456,
					FechaDeNacimiento = DateTime.Now.AddYears(-32),
					User = "admin",
					Contraseña = seguridad.EncriptarPass("admin"),
				};
				context.Administradores.Add(usuarioAdministrador);
				context.SaveChanges();
			}


			if (context.MateriasEstudiantes.Any())
			{
				// Si ya hay datos aqui, significa que ya los hemos creado previamente
				return;
			}

			var docente = context.Docentes.First();
			var nuevaMateria = new Materia();
			nuevaMateria.Id = Guid.NewGuid();
			nuevaMateria.Nombre = "PNT1";
			nuevaMateria.DocenteId = docente.Id;
			context.Materias.Add(nuevaMateria);
			context.SaveChanges();

			var estudiante = context.Estudiantes.First();			
			var materia = context.Materias.First();

			var relacionMateriaEstudiante = new MateriaEstudiante();

			relacionMateriaEstudiante.Id = Guid.NewGuid();
			relacionMateriaEstudiante.EstudianteId = estudiante.Id;
			relacionMateriaEstudiante.MateriaId = materia.Id;

			context.MateriasEstudiantes.Add(relacionMateriaEstudiante);
			context.SaveChanges();
		}
	}
}
