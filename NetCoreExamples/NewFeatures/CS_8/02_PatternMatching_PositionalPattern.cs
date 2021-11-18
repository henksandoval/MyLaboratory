namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using NetCoreExamples.RunnableInterfaces;

	public class PatternMatching_PositionalPattern : IRunnableCS_8
	{
		public void Run()
		{
			var studentInSeventhGradeMath = new Student("Francisco", "Salazar", new Teacher("Siro", "Cañas", "Math"), 7);
			var studentInNinthGradeEnglish = new Student("Fernando", "Montoya", new Teacher("Pacho", "Ochoa", "English"), 9);

			var studentNameIsFrancisco = HisNameIsEqualToFrancisco(studentInSeventhGradeMath);
			var validationStudentIsInSeventhGradeMath = IsInSeventhGradeMath(studentInSeventhGradeMath);
			var validationStudentIsInNinthGradeEnglish = IsInNinthGradeEnglish(studentInSeventhGradeMath);

			Console.WriteLine($"Validating if {nameof(studentInSeventhGradeMath)} course Seventh grade of Math: Result: {validationStudentIsInSeventhGradeMath}");
			Console.WriteLine($"Validating if {nameof(studentInSeventhGradeMath)} course Ninth grade of English: Result: {validationStudentIsInNinthGradeEnglish}");

			validationStudentIsInSeventhGradeMath = IsInSeventhGradeMath(studentInNinthGradeEnglish);
			validationStudentIsInNinthGradeEnglish = IsInNinthGradeEnglish(studentInNinthGradeEnglish);

			Console.WriteLine($"Validating if {nameof(studentInNinthGradeEnglish)} course Seventh grade of Math: Result: {validationStudentIsInSeventhGradeMath}");
			Console.WriteLine($"Validating if {nameof(studentInNinthGradeEnglish)} course Ninth grade of English: Result: {validationStudentIsInNinthGradeEnglish}");
		}

		public bool HisNameIsEqualToFrancisco(Student student)
		{
			return student is Student("Francisco", _, _, _);
		}

		public bool IsInSeventhGradeMath(Student student)
		{
			return student is Student(_, _, (_, _, "Math"), 7);
		}

		public bool IsInNinthGradeEnglish(Student student)
		{
			return student is Student(_, _, Teacher(_, _, "English"), 9);
		}

		public class Student
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public Teacher HomeRoomTeacher { get; set; }
			public int GradeLevel { get; set; }

			public Student(string firstName, string lastName, Teacher homeRoomTeacher, int gradeLevel)
			{
				FirstName = firstName;
				LastName = lastName;
				HomeRoomTeacher = homeRoomTeacher;
				GradeLevel = gradeLevel;
			}

			public void Deconstruct(out string firstName, out string lastName, out Teacher homeRoomTeacher, out int gradeLevel)
			{
				firstName = FirstName;
				lastName = LastName;
				homeRoomTeacher = HomeRoomTeacher;
				gradeLevel = GradeLevel;
			}
		}

		public class Teacher
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Subject { get; set; }
			public Teacher(string firstName, string lastName, string subject)
			{
				FirstName = firstName;
				LastName = lastName;
				Subject = subject;
			}

			public void Deconstruct(out string firstName, out string lastName, out string subject)
			{
				firstName = FirstName;
				lastName = LastName;
				subject = Subject;
			}
		}
	}
}
