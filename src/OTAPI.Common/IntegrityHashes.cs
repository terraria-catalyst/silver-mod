using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace OTAPI.Common;

[PublicAPI("OTAPI.Common.IntegrityHashes")]
public static class IntegrityHashes {
#pragma warning disable CA2211 -- Matching public API.
    public static IEnumerable<string> WindowsClient = new[] {
        // ReSharper disable StringLiteralTypo
        "F3E96856E497906842C7C88C97D320EB4669A199", // 1.4.2.3
        "81B3E10FCDCA2535F4F00D53F30F18C4F32ECBC7", // 1.4.3.2
        "AC183B8C2CC86FC578D348FE5DB6F5DBB0A26424", // 1.4.3.4
        "C8A3C5B2F45C11B96E9B8632E0E44C161F847DAE", // 1.4.3.6
        // ReSharper restore StringLiteralTypo
    };

    // ReSharper disable once InconsistentNaming
    public static IEnumerable<string> MacOSClient = Enumerable.Empty<string>();
    public static IEnumerable<string> LinuxClient = Enumerable.Empty<string>();
    public static IEnumerable<string> Clients = WindowsClient.Union(MacOSClient).Union(LinuxClient);
#pragma warning restore CA2211

    public static string ComputeHash(string path) {
        using var fs = File.Open(path, FileMode.Open);
        using var bs = new BufferedStream(fs);
        using var sha1 = SHA1.Create();

        var hash = sha1.ComputeHash(bs);
        var formatted = new StringBuilder(2 * hash.Length);
        foreach (var b in hash)
            formatted.Append($"{b:X2}");

        return formatted.ToString();
    }
}
