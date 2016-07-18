using System;

namespace ResumeTestAPI.Service
{
	public class RandomNumber
	{
		private static readonly Random Global = new Random();
		[ThreadStatic]
		private static Random _local;

		private static Random LocalBuffer
		{
			get
			{
				var localBuffer = _local;
				if (localBuffer == null)
				{
					int seed;
					lock (Global) seed = Global.Next();
					localBuffer = new Random(seed);
					_local = localBuffer;
				}
				return localBuffer;
			}
		}

		public static int Next(int min, int max)
		{
			return LocalBuffer.Next(min, max);
		}

		public static int Next(int max)
		{
			return LocalBuffer.Next(max);
		}
	}
}