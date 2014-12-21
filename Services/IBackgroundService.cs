using Orchard.RandomBackground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.RandomBackground.Services
{
	public interface IBackgroundService : IDependency
	{
		IEnumerable<BackgroundRecord> Get();
	}
}