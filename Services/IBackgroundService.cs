using Orchard.RandomBackground.Models;
using System.Collections.Generic;

namespace Orchard.RandomBackground.Services
{
	public interface IBackgroundService : IDependency
	{
		IEnumerable<BackgroundPart> Get();
	}
}