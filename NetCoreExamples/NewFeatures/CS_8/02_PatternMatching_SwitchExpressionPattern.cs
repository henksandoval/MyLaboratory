namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using NetCoreExamples.RunnableInterfaces;

	/// <summary>
	/// Interesting example
	/// <see cref="https://alexatnet.com/cs8-switch-statement/"/>
	/// <seealso cref="https://csharp.christiannagel.com/2019/08/14/moving-from-the-switch-statement-to-switch-expressions-c-8/"/>
	/// </summary>
	public class PatternMatching_SwitchExpressionPattern : IRunnableCS_8
	{
		public void Run()
		{
			var circle = new Circle(3);
			var triangle = new Triangle(1, 2, 1);
			var rectangle = new Rectangle(10, 6);

			var text = $"Validation of {nameof(circle)} with pattern matching: {DisplayShapeInfo(circle)}";
			Console.WriteLine(text);
			text = $"Validation of {nameof(triangle)} with pattern matching: {DisplayShapeInfo(triangle)}";
			Console.WriteLine(text);
			text = $"Validation of {nameof(rectangle)} with pattern matching: {DisplayShapeInfo(rectangle)}";
			Console.WriteLine(text);
			text = $"Validation of {nameof(text)} with pattern matching: {DisplayShapeInfo(text)}";
			Console.WriteLine(text);
		}

		public string DisplayShapeInfo(object obj) => obj switch
		{
			Circle circle => $"Circle (r={circle.Radious} A={circle.Area:F2})",
			Rectangle rectangle => $"Rectangle (l={rectangle.Length} w={rectangle.Width})",
			Triangle triangle => $"Triangle ({triangle.Side01}, {triangle.Side02}, {triangle.Side03})",
			_ => "Unknow shape"
		};

		public class Circle
		{
			public double Area => Radious * Math.PI;
			public int Radious { get; }

			public Circle(int radious) => Radious = radious;
		}

		public class Rectangle
		{
			public int Length { get; }
			public int Width { get; }

			public Rectangle(int length, int width)
			{
				Length = length;
				Width = width;
			}
		}

		public class Triangle
		{
			public int Side01 { get; }
			public int Side02 { get; }
			public int Side03 { get; }

			public Triangle(int side01, int side02, int side03)
			{
				Side01 = side01;
				Side02 = side02;
				Side03 = side03;
			}
		}
	}
}
