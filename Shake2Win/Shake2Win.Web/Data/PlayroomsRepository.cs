using System.Collections.Generic;
using System.Linq;
using Shake2Win.Web.Models;

namespace Shake2Win.Web.Data
{
	public class PlayroomsRepository
	{
		private readonly Dictionary<int, Playroom> _playrooms =
			new Dictionary<int, Playroom>();

		private readonly IdGenerator _idGenerator;

		private readonly object _lock = new object();

		public PlayroomsRepository(IdGenerator idGenerator)
		{
			_idGenerator = idGenerator;
		}

		public Connection ConnectUser()
		{
			lock (_lock)
			{
				var userId = _idGenerator.Generate();
				var spareRoom = _playrooms.FirstOrDefault(p => !p.Value.IsFull);
				var availableRoom = spareRoom.Value ?? new Playroom(_idGenerator.Generate());
				availableRoom.AddUser(userId);
				_playrooms.TryAdd(availableRoom.Id, availableRoom);
				return new Connection(userId, availableRoom);
			}
		}

		public Playroom GetById(int id) =>
			_playrooms.ContainsKey(id)
				? _playrooms[id]
				: null;

		public IEnumerable<Playroom> All() =>
			_playrooms.Values;

		public IEnumerable<Playroom> RemoveInactive()
		{
			var inactivePlayrooms = _playrooms.Values
				.Where(p => !p.IsActive)
				.ToArray();

			foreach (Playroom inactivePlayroom in inactivePlayrooms)
			{
				_playrooms.Remove(inactivePlayroom.Id);
			}

			return inactivePlayrooms;
		}
	}
}
