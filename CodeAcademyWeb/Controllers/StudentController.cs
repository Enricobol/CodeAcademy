using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using AcademyModel.Exceptions;
using AcademyModel.Services;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : Controller
	{
		private IPeopleService service;
		private IMapper mapper;
		public StudentController(IPeopleService service, IMapper mapper)
		{
			this.service = service;
			this.mapper = mapper;
		}

		//PRENDI TUTTI STUDENTI
		[HttpGet]
		public IActionResult GetAll()
		{
			var students = service.GetAllStudents();
			var studentDTOs = mapper.Map<IEnumerable<StudentDTO>>(students);
			return Ok(studentDTOs);
		}

		//CREA STUDENTE
		[HttpPost]
		public IActionResult Create(StudentDTO s)
		{
			var student = mapper.Map<Student>(s);
			service.CreateStudent(student);
			var studentDTO = mapper.Map<StudentDTO>(student);
			return Created($"/api/student/{studentDTO.Id}", studentDTO);
		}

		//ELIMINA PER STUDENT
		[HttpDelete]
		public IActionResult RemoveStudent(StudentDTO studentDTO)
		{
			var student = mapper.Map<Student>(studentDTO);
			service.DeleteStudent(student);
			var resDTO = mapper.Map<StudentDTO>(student);
			return Ok(resDTO);
		}

		//ELIMINA PER ID
		[HttpDelete]
		[Route("{id}")]
		public IActionResult DeleteStudent(long id)
		{
			var student = service.GetStudentById(id);
			service.DeleteStudent(id);
			var resDTO = mapper.Map<StudentDTO>(student);
			return Ok(resDTO);
		}

		//GET STUDENT BY ID
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(long id)
		{
			var student = service.GetStudentById(id);
			var studentDTO = mapper.Map<StudentDTO>(student);
			return Ok(studentDTO);
		}

		//UPDATE STUDENT
		[HttpPut]
		public IActionResult UpdateStudent(StudentDTO studentDTO)
		{
			var student = mapper.Map<Student>(studentDTO);
			student = service.UpdateStudent(student);
			var resDTO = mapper.Map<StudentDTO>(student);
			return Created($"/api/student/{resDTO.Id}", resDTO);
		}

		//ISCRIVI STUDENTE
		[HttpPost]
		[Route("{idStudent}/enrollments")]
		public IActionResult EnrollStudent(EnrollDataDTO dataDTO, long idStudent)
		{
			if( idStudent != dataDTO.IdStudent )
			{
				return BadRequest(new ErrorObject(StatusCodes.Status400BadRequest, "L'id studente nell'URL e nel body non coincidono."));
			}
			var data = mapper.Map<EnrollData>(dataDTO);
			var enr = service.EnrollSudentToEdition(data);
			var enrDTO = mapper.Map<EnrollmentDTO>(enr);
			return Created($"/api/student/{data.IdStudent}/enrollments/{enr.Id}", enrDTO);
		}
	}
}
