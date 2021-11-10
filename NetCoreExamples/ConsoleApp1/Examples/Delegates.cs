namespace NetCoreExamples.Examples
{
	using System;
	using System.Collections.Generic;
	using NetCoreExamples.RunnableInterfaces;

	public class Delegates : IRunnableExamples
	{
		public class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}

		public class FilterPeople
		{
			public static bool IsChild(Person person) => person.Age < 18;

			public static bool IsAdult(Person person) => person.Age >= 18;

			public static bool IsSenior(Person person) => person.Age >= 65;
		}

		public delegate bool FilterDelegate(Person person);

		public delegate Person GetPerson(object sender, EventArgs args);

		public void Run()
		{
			FirstExampleUseDelegates();
		}

		private void FirstExampleUseDelegates()
		{
			var people = new List<Person>
			{
				new Person { Name = "John", Age = 41 },
				new Person { Name = "Jane", Age = 69 },
				new Person { Name = "Jake", Age = 12 },
				new Person { Name = "Jessie", Age = 25 }
			};

			DisplayPeople("Childrens", people, FilterPeople.IsChild);
			DisplayPeople("Adults", people, FilterPeople.IsAdult);
			DisplayPeople("Seniors", people, FilterPeople.IsSenior);

			FilterDelegate notFilterDelegate = delegate (Person person)
			{
				return true;
			};
			DisplayPeople("All", people, notFilterDelegate);

			FilterDelegate exampleWithLambdaExpression = p => p.Age > 0;
			DisplayPeople("All", people, exampleWithLambdaExpression);

			DisplayPeople("Nobody", people, p => p.Age < 999);
		}

		private void DisplayPeople(string title, List<Person> people, FilterDelegate filter)
		{
			Console.WriteLine($"Only show {title}");

			foreach (var person in people)
				if (filter(person))
					Console.WriteLine($"{person.Name}, {person.Age} years old");

		}
	}
}
