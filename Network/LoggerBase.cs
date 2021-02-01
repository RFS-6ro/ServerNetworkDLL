using System;

namespace Network
{
	public interface LoggerBase
	{
		public void PrintSuccess(string message);

		public void PrintWarning(string message);

		public void PrintError(string message);

	}
}
