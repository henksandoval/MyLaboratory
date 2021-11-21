namespace WpfApp1
{
	using System;
	using System.Windows;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public string Version => $"Framework version: {Environment.Version}";

		public MainWindow() => InitializeComponent();
	}
}
