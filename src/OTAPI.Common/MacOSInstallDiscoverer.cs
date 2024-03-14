using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace OTAPI.Common;

// ReSharper disable once InconsistentNaming
[PublicAPI("OTAPI.Common.MacOSInstallDiscoverer")]
public class MacOSInstallDiscoverer : BaseInstallDiscoverer {
    public override string[] SearchPaths { get; } = ["/Users/[USER_NAME]/Library/Application Support/Steam/steamapps/common/Terraria/Terraria.app/Contents/", "/Applications/Terraria.app/Contents/"];

    public override OSPlatform GetClientPlatform() {
        return OSPlatform.OSX;
    }

    public override string GetResource(string fileName, string installPath) {
        return Path.Combine(installPath, "Resources", fileName);
    }

    public override string GetResourcePath(string installPath) {
        return Path.Combine(installPath, "Resources");
    }

    public override bool IsValidInstallPath(string folder) {
        // NO-OP; we use our own tModLoader-specific discoverers.
        return false;
    }
}
