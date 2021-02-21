using System;
using System.Collections.Generic;
using System.Text;

namespace Network
{
	public class ServerIdentifierData
	{
		public string IpAddress;
		public int Port;

		private byte[] IdentityArrayOfBytes = null;

		private ServerIdentifierData() { }

		public ServerIdentifierData(string ipAddress, int port)
		{
			IpAddress = ipAddress;
			Port = port;
		}

		public byte[] ToByteArray()
		{
			if (IdentityArrayOfBytes == null)
			{
				List<byte> buffer = new List<byte>();

				buffer.AddRange(BitConverter.GetBytes(IpAddress.Length));
				buffer.AddRange(Encoding.ASCII.GetBytes(IpAddress));
				buffer.AddRange(BitConverter.GetBytes(Port));

				IdentityArrayOfBytes = buffer.ToArray();
			}

			return IdentityArrayOfBytes;
		}
	}
}
