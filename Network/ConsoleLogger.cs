using System;
namespace Network
{
	public class ConsoleLogger : SingletonBase<ConsoleLogger>, LoggerBase
	{
		public void Print(string message)
		{
			PrintColored(message);
		}

		public void PrintSuccess(string message)
		{
			PrintColored(message, ConsoleColor.Green, ConsoleColor.Black);
		}

		public void PrintWarning(string message)
		{
			PrintColored(message, ConsoleColor.Yellow, ConsoleColor.Black);
		}

		public void PrintError(string message)
		{
			PrintColored(message, ConsoleColor.Red, ConsoleColor.White);
		}

		public void PrintColored(string message, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor textColor = ConsoleColor.White)
		{
			Console.BackgroundColor = backgroundColor;
			Console.ForegroundColor = textColor;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
