using System;

namespace Network
{
	public class SingletonBase<T>
		where T : SingletonBase<T>, new()
	{
		protected static T _instance = null;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new T();
				}

				return _instance;
			}
		}

		protected SingletonBase() { }

		public void Destroy()
		{
			_instance = null;
			GC.SuppressFinalize(this);
		}
	}
}
