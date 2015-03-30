using Orchard.UI.Resources;

namespace Orchard.RandomBackground
{
	public class ResourceManifest : IResourceManifestProvider
	{
		public void BuildManifests(ResourceManifestBuilder builder)
		{
			var manifest = builder.Add();
			manifest.DefineScript("RandomBackground").SetDependencies("jQuery");
		}
	}
}
