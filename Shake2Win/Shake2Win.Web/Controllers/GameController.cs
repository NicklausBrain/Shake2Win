using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shake2Win.Web.Data;
using Shake2Win.Web.Models;

namespace Shake2Win.Web.Controllers
{
	public class GameController : ControllerBase
	{
		private readonly PlayroomsRepository _playrooms;

		public GameController(PlayroomsRepository playrooms)
		{
			_playrooms = playrooms;
		}

		[HttpPost("game/connect")]
		public Connection Connect()
		{
			var connection = _playrooms.ConnectUser();

			return connection;
		}

		[HttpGet("game/rooms")]
		public ActionResult<IEnumerable<Playroom>> GetRooms() =>
			Ok(_playrooms.All());

		[HttpDelete("game/rooms/inactive")]
		public ActionResult<IEnumerable<Playroom>> DeleteInactive() =>
			Ok(_playrooms.RemoveInactive());

		[HttpGet("game/room/{id}")]
		public ActionResult<Playroom> GetRoom(int id)
		{
			var playroom = _playrooms.GetById(id);

			if (playroom != null)
			{
				return playroom;
			}

			return NotFound();
		}

		[HttpPost("game/report")]
		public IActionResult PostReport([FromBody]ShakeReport report)
		{
			var playroom = _playrooms.GetById(report.RoomId);

			playroom.ReceiveReport(report);

			return Accepted();
		}
	}
}
