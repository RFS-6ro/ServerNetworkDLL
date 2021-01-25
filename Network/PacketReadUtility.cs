﻿using System;
using System.Text;

namespace Network
{
	public partial class Packet
	{
		/// <summary>Reads a byte from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public byte ReadByte(bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				byte value = _readableBuffer[_readPosition]; // Get the byte at readPos' position
				if (moveReadPos)
				{
					// If _moveReadPos is true
					_readPosition += 1; // Increase readPos by 1
				}
				return value; // Return the byte
			}
			else
			{
				throw new Exception("Could not read value of type 'byte'!");
			}
		}

		/// <summary>Reads an array of bytes from the packet.</summary>
		/// <param name="length">The length of the byte array.</param>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public byte[] ReadBytes(int length, bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				byte[] value = _buffer.GetRange(_readPosition, length).ToArray(); // Get the bytes at readPos' position with a range of _length
				if (moveReadPos)
				{
					// If _moveReadPos is true
					_readPosition += length; // Increase readPos by _length
				}
				return value; // Return the bytes
			}
			else
			{
				throw new Exception("Could not read value of type 'byte[]'!");
			}
		}

		/// <summary>Reads a short from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public short ReadShort(bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				short value = BitConverter.ToInt16(_readableBuffer, _readPosition); // Convert the bytes to a short
				if (moveReadPos)
				{
					// If _moveReadPos is true and there are unread bytes
					_readPosition += 2; // Increase readPos by 2
				}
				return value; // Return the short
			}
			else
			{
				throw new Exception("Could not read value of type 'short'!");
			}
		}

		/// <summary>Reads an int from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public int ReadInt(bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				int value = BitConverter.ToInt32(_readableBuffer, _readPosition); // Convert the bytes to an int
				if (moveReadPos)
				{
					// If _moveReadPos is true
					_readPosition += 4; // Increase readPos by 4
				}
				return value; // Return the int
			}
			else
			{
				throw new Exception("Could not read value of type 'int'!");
			}
		}

		/// <summary>Reads a long from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public long ReadLong(bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				long value = BitConverter.ToInt64(_readableBuffer, _readPosition); // Convert the bytes to a long
				if (moveReadPos)
				{
					// If _moveReadPos is true
					_readPosition += 8; // Increase readPos by 8
				}
				return value; // Return the long
			}
			else
			{
				throw new Exception("Could not read value of type 'long'!");
			}
		}

		/// <summary>Reads a float from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public float ReadFloat(bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				float value = BitConverter.ToSingle(_readableBuffer, _readPosition); // Convert the bytes to a float
				if (moveReadPos)
				{
					// If _moveReadPos is true
					_readPosition += 4; // Increase readPos by 4
				}
				return value; // Return the float
			}
			else
			{
				throw new Exception("Could not read value of type 'float'!");
			}
		}

		/// <summary>Reads a bool from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public bool ReadBool(bool moveReadPos = true)
		{
			if (_buffer.Count > _readPosition)
			{
				// If there are unread bytes
				bool value = BitConverter.ToBoolean(_readableBuffer, _readPosition); // Convert the bytes to a bool
				if (moveReadPos)
				{
					// If _moveReadPos is true
					_readPosition += 1; // Increase readPos by 1
				}
				return value; // Return the bool
			}
			else
			{
				throw new Exception("Could not read value of type 'bool'!");
			}
		}

		/// <summary>Reads a string from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public string ReadString(bool moveReadPos = true)
		{
			try
			{
				int length = ReadInt(); // Get the length of the string
				string value = Encoding.ASCII.GetString(_readableBuffer, _readPosition, length); // Convert the bytes to a string
				if (moveReadPos && value.Length > 0)
				{
					// If _moveReadPos is true string is not empty
					_readPosition += length; // Increase readPos by the length of the string
				}
				return value; // Return the string
			}
			catch
			{
				throw new Exception("Could not read value of type 'string'!");
			}
		}

		/// <summary>Reads a string from the packet.</summary>
		/// <param name="moveReadPos">Whether or not to move the buffer's read position.</param>
		public ServerIdentifierData ReadServerIdentifier(bool moveReadPos = true)
		{
			try
			{
				int length = ReadInt();
				string address = Encoding.ASCII.GetString(_readableBuffer, _readPosition, length);

				if (moveReadPos && address.Length > 0)
				{
					// If _moveReadPos is true string is not empty
					_readPosition += length; // Increase readPos by the length of the string
				}

				int port = ReadInt();

				return new ServerIdentifierData(address, port);
			}
			catch
			{
				throw new Exception("Could not read value of type 'ServerIdentifierData'!");
			}
		}
	}
}
