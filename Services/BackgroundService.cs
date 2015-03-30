using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.RandomBackground.Models;
using System.Collections.Generic;

namespace Orchard.RandomBackground.Services
{
	public class BackgroundService : IBackgroundService
	{
		private readonly IContentManager _contentManager;
		
		public BackgroundService(
			IContentManager contentManager,
			ISignals signals)
		{
			_contentManager = contentManager;
		}

		public IEnumerable<BackgroundPart> Get()
		{
			return _contentManager.Query<BackgroundPart>().List();
		}
	}
}