using Orchard.UI.Resources;

namespace Orchard.jQuery {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("Orchard.RandomBackground").SetUrl("RandomBackground.js", "RandomBackground.js");            
        }
    }
}
