using System;
namespace Network
{
	[Serializable]
	public struct SafeInt : IComparable<SafeInt>
	{
		private int value;
		private int salt;

		public SafeInt(int value)
		{
			salt = new Random().Next(int.MinValue / 4, int.MaxValue / 4);
			this.value = value ^ salt;
		}

		public int CompareTo(SafeInt other)
		{
			if (this > other)
			{
				return 1;
			}
			else if (this == other)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}

		public override bool Equals(object obj)
		{
			return (object)(value ^ salt) == obj;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return ((int)this).ToString();
		}

		public static implicit operator int(SafeInt safeInt)
		{
			return safeInt.value ^ safeInt.salt;
		}

		public static implicit operator SafeInt(int normalInt)
		{
			return new SafeInt(normalInt);
		}
	}
}
