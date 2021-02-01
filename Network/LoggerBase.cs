using System;

namespace Network
{
	public interface LoggerBase
	{
		void PrintSuccess(string message);

		void PrintWarning(string message);

		void PrintError(string message);

	}
}
