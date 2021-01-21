using System;
using System.Collections.Generic;

namespace Network
{
	public sealed class Pool<T> : SingletonBase<Pool<T>> where T : class
	{
		private Stack<T> _avaliableResources;

		private Func<T> CreateInstance;

		public int Count => _avaliableResources.Count;

		public Pool()
		{
			_avaliableResources = new Stack<T>();
		}

		public Pool(Func<T> createInstance)
		{
			_avaliableResources = new Stack<T>();
			SetFractoryMethod(createInstance);
		}

		public Pool(Func<T> createInstance, int maxCapacity)
		{
			_avaliableResources = new Stack<T>(maxCapacity + 1);
			SetFractoryMethod(createInstance);
		}

		/// <summary>
		/// NOTE: Method is clearing current avaliable resources
		/// </summary>
		/// <param name="createInstance"></param>
		public void SetFractoryMethod(Func<T> createInstance)
		{
			_avaliableResources.Clear();
			CreateInstance = createInstance.Clone() as Func<T>;
		}

		public T GetResource()
		{
			if (_avaliableResources.Count <= 0)
			{
				if (CreateInstance != null)
				{
					return CreateInstance();
				}
			}

			return _avaliableResources.Pop();
		}

		public void ReturnResource(T resource)
		{
			_avaliableResources.Push(resource);
		}
	}

	public static class PoolExtensions
	{
		public static void ReturnToPool<T>(this T resource) where T : class
		{
			Pool<T>.Instance.ReturnResource(resource);
		}
	}
}
