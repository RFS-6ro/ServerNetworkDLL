using System;
using System.Net.Sockets;

namespace Network
{
	internal class TestSocket : TCPBase
	{
		public override LoggerBase _logger => throw new NotImplementedException();

		public override void Connect(TcpClient socket = null)
		{
		}

		public override void Disconnect()
		{
			throw new NotImplementedException();
		}

		protected override bool HandleReceivedData(byte[] data)
		{
			throw new NotImplementedException();
		}
	}
}
