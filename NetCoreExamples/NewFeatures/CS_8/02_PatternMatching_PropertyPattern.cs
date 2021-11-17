namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using NetCoreExamples.RunnableInterfaces;

	public class PatternMatching_PropertyPattern : IRunnableCS_8
	{
		public void Run()
		{
			var bob = new Employee { FirstName = "Bob", ReportsTo = new Employee { FirstName = "Ian" } };
			var workInUSAndReportsToUK = new Employee { Region = "US", ReportsTo = new Employee { Region = "UK" } };

			var isBobAndHisBossIsIan = EmployeeNameIsBobWithBossIan(bob);
			var isInUSAndReportsToUK = IsUsBasedWithUkManager(workInUSAndReportsToUK);

			Console.WriteLine($"Validating if {nameof(bob)} have by boss Ian: Result: {isBobAndHisBossIsIan}");
			Console.WriteLine($"Validating if {nameof(workInUSAndReportsToUK)} work is in US and report to UK: Result: {isInUSAndReportsToUK}");
		}

		public bool IsUsBasedWithUkManager(Employee employee)
		{
			return employee is { Region: "US", ReportsTo: { Region: "UK" } };
		}

		public bool EmployeeNameIsBobWithBossIan(object obj)
		{
			return obj is Employee employee &&
				employee is { FirstName: "Bob", ReportsTo: { FirstName: "Ian" } };
		}

		public class Employee
		{
			public string FirstName { get; set; }

			public string LastName { get; set; }

			public string Type { get; set; }

			public string Region { get; set; }

			public Employee ReportsTo { get; set; }
		}
	}
}
