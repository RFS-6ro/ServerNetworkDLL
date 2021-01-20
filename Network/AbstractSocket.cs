using System;
namespace Network
{
	public interface AbstractSocket<T> : INeedLogger
	{
		public abstract T Socket { get; }

		public abstract void SendData(Packet packet);

		public abstract void ReceiveCallback(IAsyncResult result);

		public abstract void Disconnect();
	}
}
