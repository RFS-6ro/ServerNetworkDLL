using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
	public abstract class UDPBase : AbstractSocket<UdpClient>
	{
		public UdpClient Socket { get; protected set; }
		public IPEndPoint EndPoint;

		public abstract LoggerBase _logger { get; }

		public abstract void Connect(object connection);

		public void ReceiveCallback(IAsyncResult result)
		{
			try
			{
				byte[] _data = Socket.EndReceive(result, ref EndPoint);
				Socket.BeginReceive(ReceiveCallback, null);

				if (_data.Length < 4)
				{
					//here was instance.Disconnect();
					Disconnect();
					return;
				}

				HandleData(_data);
			}
			catch
			{
				Disconnect();
			}
		}

		protected abstract void HandleData(byte[] _data);

		public abstract void SendData(Packet packet);

		public abstract void Disconnect();

		public abstract void CompleteDisconnect();
	}
}
