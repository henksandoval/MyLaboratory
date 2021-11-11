namespace NetCoreExamples.NewFeatures.CS_6
{
	using System;
	using System.Collections.Generic;
	using NetCoreExamples.RunnableInterfaces;

	public class IndexInitializers : IRunnableCS_6
	{
		public void Run()
		{
			Dictionary<int, string> httpStatusesDictionary = new Dictionary<int, string>
			{
				[200] = "Ok",
				[400] = "Bad Request",
				[404] = "Not Found",
				[500] = "Internal Error"
			};

			Dictionary<int, User> usersDictionary = new Dictionary<int, User>
			{
				[1] = new User { Name = "Logan" },
				[2] = new User { Name = "Peter" },
				[3] = new User { Name = "Stephan" }
			};

			User user1 = new User { Name = "Logan" };

			Console.WriteLine($"Error 400 is {httpStatusesDictionary[400]}");
			Console.WriteLine($"User with id 3 is {usersDictionary[3].Name}");
		}
	}

	public class User
	{
		public string Name { get; set; }
	}
}
