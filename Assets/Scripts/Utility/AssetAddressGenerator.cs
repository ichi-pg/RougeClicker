using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets;

public static class AssetAddressGenerator
{
    const string Template =
@"public static class AssetAddress
{{{0}
}}
";
    const string Body = "    public const string {0} = \"{0}\";";
    const string FileName = "Assets/Scripts/Utility/AssetAddress.cs";

    [MenuItem("Assets/Generate AssetAddress.cs")]
    private static void GenerateAssetAddress()
    {
        var builder = new StringBuilder();
        var settings = AddressableAssetSettingsDefaultObject.Settings;
        var groups = settings.groups.Where(t => !t.ReadOnly);

        foreach (var group in groups)
            foreach (var entry in group.entries)
                builder.AppendLine().AppendFormat(Body, entry.address);

        using (var stream = File.Open(FileName, FileMode.Create, FileAccess.Write))
        using (var writer = new StreamWriter(stream))
            writer.Write(Template, builder.ToString());

        AssetDatabase.Refresh();

        Debug.Log($"Finish Generate AssetAddress.cs");
    }
}
