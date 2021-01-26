using System;
using System.Text;

namespace Network
{
	public partial class Packet
	{
		/// <summary>Inserts the length of the packet's content at the start of the buffer.</summary>
		public void WriteLength()
		{
			_buffer.InsertRange(0, BitConverter.GetBytes(_buffer.Count)); // Insert the byte length of the packet at the very beginning
		}
		/// <summary>Inserts the given int at the start of the buffer.</summary>
		/// <param name="value">The int to insert.</param>
		public void InsertInt(int value)
		{
			_buffer.InsertRange(0, BitConverter.GetBytes(value)); // Insert the int at the start of the buffer
		}
		/// <summary>Adds a byte to the packet.</summary>
		/// <param name="value">The byte to add.</param>
		public void Write(byte value)
		{
			_buffer.Add(value);
		}
		/// <summary>Adds an array of bytes to the packet.</summary>
		/// <param name="value">The byte array to add.</param>
		public void Write(byte[] value)
		{
			_buffer.AddRange(value);
		}
		/// <summary>Adds a short to the packet.</summary>
		/// <param name="value">The short to add.</param>
		public void Write(short value)
		{
			_buffer.AddRange(BitConverter.GetBytes(value));
		}
		/// <summary>Adds an int to the packet.</summary>
		/// <param name="value">The int to add.</param>
		public void Write(int value)
		{
			_buffer.AddRange(BitConverter.GetBytes(value));
		}
		/// <summary>Adds a long to the packet.</summary>
		/// <param name="value">The long to add.</param>
		public void Write(long value)
		{
			_buffer.AddRange(BitConverter.GetBytes(value));
		}
		/// <summary>Adds a float to the packet.</summary>
		/// <param name="value">The float to add.</param>
		public void Write(float value)
		{
			_buffer.AddRange(BitConverter.GetBytes(value));
		}
		/// <summary>Adds a bool to the packet.</summary>
		/// <param name="value">The bool to add.</param>
		public void Write(bool value)
		{
			_buffer.AddRange(BitConverter.GetBytes(value));
		}
		/// <summary>Adds a string to the packet.</summary>
		/// <param name="value">The string to add.</param>
		public void Write(string value)
		{
			Write(value.Length); // Add the length of the string to the packet
			_buffer.AddRange(Encoding.ASCII.GetBytes(value)); // Add the string itself
		}
		/// <summary>Adds a string to the packet.</summary>
		/// <param name="value">The string to add.</param>
		public void Write(ServerIdentifierData value)
		{
			Write(value.IpAddress);
			Write(value.Port);
		}
	}
}
