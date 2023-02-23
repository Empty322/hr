using hr.DB.Enums;
using hr.DB.Models;

namespace hr.Tests;

internal static class TestEntities
{
	public static Candidate Candidate1 => new Candidate
	{
		FullName = "Ivan Petrov",
		DateOfBirth = new DateTime(1990, 3, 12),
		Education = Education.HigherTechnical,
		University = "GUAP",
		Faculty = "INDO"
	};

	public static Candidate Candidate2 => new Candidate
	{
		FullName = "Semen Ivanov",
		DateOfBirth = new DateTime(1995, 7, 16),
		Education = Education.IncompleteHigherEducation,
		University = "GUAP",
		Faculty = "IITP"
	};

	public static Candidate Candidate3 => new Candidate
	{
		FullName = "Igor Sidorov",
		DateOfBirth = new DateTime(1985, 12, 7),
		Education = Education.SecondarySpecialized,
		University = "SPPK",
		Faculty = "Programming in computer systems"
	};

	public static PlaceOfWork PlaceOfWork1 => new PlaceOfWork
	{
		Begin = new DateTime(2010, 4, 2),
		End = new DateTime(2015, 3, 4),
		Company = "Better place",
		Description = "Better place company desctiption",
		Position = "Developer"
	};

	public static PlaceOfWork PlaceOfWork2 => new PlaceOfWork
	{
		Begin = new DateTime(2016, 1, 4),
		End = new DateTime(2018, 8, 14),
		Company = "New company",
		Description = "New company desctiption",
		Position = "Developer"
	};

	public static PlaceOfWork PlaceOfWork3 => new PlaceOfWork
	{
		Begin = new DateTime(2008, 2, 4),
		End = new DateTime(2019, 11, 10),
		Company = "System management",
		Description = "System management company desctiption",
		Position = "System administrator"
	};

	public static PlaceOfWork PlaceOfWork4 => new PlaceOfWork
	{
		Begin = new DateTime(2001, 2, 2),
		End = new DateTime(2004, 9, 4),
		Company = "5post",
		Description = "5post delivery company",
		Position = "Business analyst"
	};

	public static PlaceOfWork PlaceOfWork5 => new PlaceOfWork
	{
		Begin = new DateTime(2005, 3, 4),
		End = new DateTime(2011, 5, 14),
		Company = "Ozon",
		Description = "Ozon marketplace",
		Position = "Developer"
	};

	public static PlaceOfWork PlaceOfWork6 => new PlaceOfWork
	{
		Begin = new DateTime(2011, 3, 4),
		End = new DateTime(2021, 6, 10),
		Company = "MTS",
		Description = "MTS telecommunication company",
		Position = "Lead Developer"
	};
}
