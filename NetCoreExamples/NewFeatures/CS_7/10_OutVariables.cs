namespace NetCoreExamples.NewFeatures.CS_7
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using NetCoreExamples.RunnableInterfaces;

	public class OutVariables : IRunnableCS_7
	{
		public void Run()
		{
			const string NUMBER = "01";

			if (int.TryParse(NUMBER, out int result))
				Console.WriteLine(result);
			else
				Console.WriteLine("Could not parse input");

			var classOut = new ClassOutChildren(result);
		}
	}

	public class ClassOutFather
	{
		public ClassOutFather(int firstValue, out int outValue)
		{
			outValue = firstValue + 10;
		}
	}

	public class ClassOutChildren : ClassOutFather
	{
		public ClassOutChildren(int firstValue) : base(firstValue, out var outValue)
		{
			Console.WriteLine($"The value of 'outValue' is {outValue}");
		}
	}
}
