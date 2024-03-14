using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace OTAPI.Common;

[PublicAPI("OTAPI.Common.WindowsInstallDiscoverer")]
public class WindowsInstallDiscoverer : BaseInstallDiscoverer {
    public override string[] SearchPaths { get; } = [@"C:\Program Files (x86)\Steam\steamapps\common\Terraria"];

    public override OSPlatform GetClientPlatform() {
        return OSPlatform.Windows;
    }

    public override string GetResource(string fileName, string installPath) {
        return Path.Combine(installPath, fileName);
    }

    public override string GetResourcePath(string installPath) {
        return installPath;
    }

    public override bool IsValidInstallPath(string folder) {
        // NO-OP; we use our own tModLoader-specific discoverers.
        return false;
    }
}
