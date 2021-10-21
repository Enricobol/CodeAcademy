﻿using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyModel.Extensions;

namespace CodeAcademyWeb.Profiles
{
	public class CourseEditionProfile : Profile
	{
		public CourseEditionProfile()
		{
			CreateMap<CourseEdition, CourseEditionDTO>(); // Da database a DTO
			CreateMap<CourseEditionDTO, CourseEdition>(); // Da DTO a database

			CreateMap<CourseEdition, CourseEditionDetailsDTO>()
				.ForMember(dto => dto.InstructorFullName, opt => opt.MapFrom(edition => $"{edition.Instructor.Firstname} {edition.Instructor.Lastname}"))
				.ForMember(dto => dto.StartDate, opt => opt.MapFrom(edition => edition.StartDate.ToLocalDateString()))
				.ForMember(dto => dto.FinalizationDate, opt => opt.MapFrom(edition => edition.FinalizationDate.ToLocalDateString()));
			
			CreateMap<CourseEditionDetailsDTO, CourseEdition>()
				.ForMember(edition => edition.StartDate, opt => opt.MapFrom(dto => dto.StartDate.Parse()))
				.ForMember(edition => edition.FinalizationDate, opt => opt.MapFrom(dto => dto.FinalizationDate.Parse()));
			
				
		}
	}
}
