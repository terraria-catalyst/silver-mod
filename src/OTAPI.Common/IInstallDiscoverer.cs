using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace OTAPI.Common;

[PublicAPI("OTAPI.Common.IInstallDiscoverer")]
public interface IInstallDiscoverer {
    IEnumerable<string> FindInstalls();

    OSPlatform GetClientPlatform();

    string GetResource(string fileName, string installPath);

    string GetResourcePath(string installPath);

    bool IsValidInstallPath(string folder);

    bool VerifyIntegrity(string path);
}
