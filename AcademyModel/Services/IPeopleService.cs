﻿using AcademyModel.BuisnessLogic;
using AcademyModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyModel.Services
{
	public interface IPeopleService
	{
		IEnumerable<Student> GetAllStudents();
		IEnumerable<Student> GetStudentsByLastnameLike(string lastnameLike);
		Student CreateStudent(Student s);
		Student GetStudentById(long id);
		Student UpdateStudent(Student s);
		void DeleteStudent(Student s);
		void DeleteStudent(long id);
		Enrollment EnrollSudentToEdition(EnrollData data);

		Instructor GetInstructorById(long id);
		IEnumerable<Instructor> GetInstructors();
	}
}
