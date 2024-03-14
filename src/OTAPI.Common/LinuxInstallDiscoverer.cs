using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace OTAPI.Common;

[PublicAPI("OTAPI.Common.LinuxInstallDiscoverer")]
public class LinuxInstallDiscoverer : BaseInstallDiscoverer {
    public override string[] SearchPaths { get; } = ["/home/[USER_NAME]/.steam/debian-installation/steamapps/common/Terraria", "/home/[USER_NAME]/.steam/steam/steamapps/common/Terraria"];

    public override OSPlatform GetClientPlatform() {
        return OSPlatform.Linux;
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
