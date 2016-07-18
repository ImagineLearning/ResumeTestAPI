using System.Collections.Generic;
using ResumeTestAPI.Service;

namespace ResumeTestAPI.Models
{
	public class Student
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FavoriteFood { get; set; }
		public string FavoriteColor { get; set; }
		public string FavoriteMovie { get; set; }
		public int Id { get; set; }


		private static readonly string[] FirstNames = { "Noah", "Liam", "Mason", "Jacob", "William", "Ethan", "James", "Alexander", "Michael", "Benjamin", "Jacob", "Emma", "Olivia", "Sophia", "Ava", "Isabella", "Mia", "Abigail", "Emily", "Charlotte", "Harper" };
		private static readonly string[] LastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore", "Martin", "Jackson", "Thompson", "White" };
		private static readonly string[] FavoriteFoods = { "Spaghetti", "Apples", "Sandwich", "Pizza", "Avocado", "Fried chicken", "S'mores", "Pie", "Cake", "Chicken nuggets", "Macaroni and cheese"};
		private static readonly string[] FavoriteColors = { "Red", "Blue", "Green", "White", "Black", "Pink", "Teal", "Aquamarine", "Brown"};
		private static readonly string[] FavoriteMovies = { "The Incredibles", "Star Wars Episode 1", "Aladdin", "Oliver and Company", "The Rescuers", "Hercules", "Big Hero 6", "Zootopia" };
		 

		public static Student GiveMeAStudent()
		{
			return new Student()
			{
				FirstName = FirstNames[RandomNumber.Next(0, FirstNames.Length)],
				LastName = LastNames[RandomNumber.Next(0, LastNames.Length)],
				FavoriteFood = FavoriteFoods[RandomNumber.Next(0, FavoriteFoods.Length)],
				FavoriteColor = FavoriteColors[RandomNumber.Next(0, FavoriteColors.Length)],
				FavoriteMovie = FavoriteMovies[RandomNumber.Next(0, FavoriteMovies.Length)],
				Id = RandomNumber.Next(1, 40000)
			};
		}

		public static Student[] GiveMeSomeStudents()
		{
			var students = new List<Student>();

			var numStudents = RandomNumber.Next(10, 50);
			for (int i = 0; i < numStudents; i++)
			{
				students.Add(GiveMeAStudent());
			}

			return students.ToArray();
		}
	}
}