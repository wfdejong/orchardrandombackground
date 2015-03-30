using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.RandomBackground.Models;

namespace Orchard.RandomBackground.Drivers
{
	public class BackgroundDriver :  ContentPartDriver<BackgroundPart>
	{
        private readonly ISignals _signals;

		public BackgroundDriver(ICacheManager cacheManager, ISignals signals) 
		{
			_signals = signals;
        }


		protected override DriverResult Display(BackgroundPart part, string displayType, dynamic shapeHelper)
		{
			return ContentShape("Parts_Background",	() => shapeHelper.Parts_Background());
		}

		//GET
		protected override DriverResult Editor(BackgroundPart part, dynamic shapeHelper)
		{
			return ContentShape("Parts_Background_Edit",
				() => shapeHelper.EditorTemplate(
					TemplateName: "Parts/Background",
					Model: part,
					Prefix: Prefix));
		}

		//POST
		protected override DriverResult Editor(BackgroundPart part, IUpdateModel updater, dynamic shapeHelper)
		{
			updater.TryUpdateModel(part, Prefix, null, null);
			_signals.Trigger("Randombackground.BackgroundListChanged");
			return Editor(part, shapeHelper);
		}
	}
}