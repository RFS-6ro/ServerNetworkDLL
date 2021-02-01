using System;
namespace Network
{
	public abstract class AbstractSocket<T>
	{
		public T Socket { get; protected set; }

		public abstract void SendData(Packet packet);

		public abstract void Disconnect();
	}
}
