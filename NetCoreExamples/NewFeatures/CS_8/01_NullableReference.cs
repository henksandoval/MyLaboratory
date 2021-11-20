namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.Collections.Generic;
	using NetCoreExamples.RunnableInterfaces;

	/// <summary>
	/// To enable per file, you can use #nullable enable where you want to enable the functionality and #nullable disable where you want to disable it.
	/// <see cref="https://www.meziantou.net/csharp-8-nullable-reference-types.htm"/>
	/// </summary>
	#nullable enable
	public class NullableReference : IRunnableCS_8
	{
		public void Run()
		{
			var blog = new BlogPost(null);
			Console.WriteLine("Look at the class file by see how work");
			//Validate how the compiler null literals on variables
		}
	}


	public class BlogPost
	{
		public string Title { get; set; }

		public List<Comment> Comments { get; set; } = new List<Comment>();

		public BlogPost(string title)
		{
			Title = title;
		}
	}

	public class Comment
	{
		public string Body { get; set; }

		public Author Author { get; set; }
	}

#nullable disable
	public class Author
	{
		public string Name { get; set; }

		public string Email { get; set; }
	}
#nullable enable
}
#nullable restore