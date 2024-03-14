using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace OTAPI.Common;

[PublicAPI("OTAPI.Common.InstallStatusUpdate")]
public class InstallStatusUpdate : EventArgs {
    public string? Text { get; set; }
}

[PublicAPI("OTAPI.Common.BaseInstallDiscoverer")]
public abstract class BaseInstallDiscoverer : IInstallDiscoverer {
    public string Status {
        set => StatusUpdate?.Invoke(this, new InstallStatusUpdate { Text = value });
    }

    public abstract string[] SearchPaths { get; }

    public event EventHandler<InstallStatusUpdate>? StatusUpdate;

    public virtual IEnumerable<string> FindInstalls() {
        foreach (var path in SearchPaths) {
            var formatted = path.Replace("[USER_NAME]", Environment.UserName);
            if (IsValidInstallPath(formatted))
                yield return formatted;
        }
    }

    public abstract OSPlatform GetClientPlatform();

    public abstract string GetResource(string fileName, string installPath);

    public abstract string GetResourcePath(string installPath);

    public abstract bool IsValidInstallPath(string folder);

    public virtual bool VerifyIntegrity(string path) {
        return true;
    }
}
