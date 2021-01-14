using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
	public abstract class TCPBase
	{
		public TcpClient Socket;

		protected abstract LoggerBase _logger { get; }

		protected NetworkStream _stream;
		protected byte[] _receiveBuffer = new byte[NetworkSettings.DATA_BUFFER_SIZE];

		public abstract void Connect(TcpClient socket = null);

		public abstract void Disconnect(TcpClient socket = null);

		protected abstract void HandleRecievedData(byte[] data);

		protected void ReceiveCallback(IAsyncResult result)
		{
			try
			{
				int receivedLength = _stream.EndRead(result);

				if (receivedLength <= 0)
				{
					//TODO: disconnect
					Disconnect();
					_logger.PrintWarning("Zero bytes were received. Disconnecting...");

					return;
				}

				byte[] data = new byte[receivedLength];
				Array.Copy(_receiveBuffer, data, receivedLength);
				Array.Clear(_receiveBuffer, 0, receivedLength);

				HandleRecievedData(data);
				//TODO: handle received data

				_stream.BeginRead(_receiveBuffer, 0, NetworkSettings.DATA_BUFFER_SIZE, ReceiveCallback, null);
			}
			catch (Exception ex)
			{
				_logger.PrintError($"error with receiving data: {ex}");
				Disconnect();
				//TODO: disconnect
			}
		}
	}
}
