using Orchard.Caching;
using Orchard.Data;
using Orchard.RandomBackground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.RandomBackground.Services
{
	public class BackgroundService : IBackgroundService
	{
		private const string DefaultScript = "";

		private readonly IRepository<BackgroundRecord> _repository;
		private readonly ISignals _signals;

		public BackgroundService(
			IRepository<BackgroundRecord> repository,
			ISignals signals)
		{
			_repository = repository;
			_signals = signals;
		}

		public IEnumerable<BackgroundRecord> Get()
		{
			return _repository.Table;
		}

		//public bool Set(bool enable, string script)
		//{
		//	var settings = Get();

		//	settings.Enable = enable;
		//	settings.Script = script;

		//	_signals.Trigger("GoogleAnalytics.SettingsChanged");

		//	return true;
		//}
	}
}