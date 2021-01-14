namespace Network
{
	public abstract class LoggerBase
	{
		public abstract void PrintSuccess(string message);

		public abstract void PrintWarning(string message);

		public abstract void PrintError(string message);
	}
}