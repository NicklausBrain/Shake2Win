using System;

namespace Shake2Win.Web.Data
{
	public class IdGenerator
	{
		private readonly Random _random;

		public IdGenerator()
		{
			_random = new Random(Environment.TickCount);
		}

		public int Generate() => _random.Next(0, int.MaxValue);
	}
}
