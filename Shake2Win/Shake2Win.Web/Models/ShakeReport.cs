using System;
using Newtonsoft.Json;

namespace Shake2Win.Web.Models
{
	public class ShakeReport
	{
		[JsonConstructor]
		public ShakeReport(
			int roomId,
			int userId,
			float acceleration)
		{
			RoomId = roomId;
			UserId = userId;
			Acceleration = acceleration;
			Timestamp = DateTimeOffset.Now;
		}

		public int RoomId { get; }

		public int UserId { get; }

		public float Acceleration { get; }

		public DateTimeOffset Timestamp { get; }
	}
}
