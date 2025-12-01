using System;
using BepInEx;
using HarmonyLib;
using StationeersMods.Interface;

namespace ExampleMod;

[StationeersMod(PluginGuid, PluginName, PluginVersion)]
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public sealed class ExampleModPlugin : BaseUnityPlugin
{
    public const string PluginGuid = "aproposmath-stationeers-example-mod"; // TODO: make this unique per mod
    public const string PluginName = ThisAssembly.AssemblyName;
    public const string PluginVersion = ThisAssembly.AssemblyVersion;
    public const string PluginLongVersion = ThisAssembly.AssemblyInformationalVersion;

    private Harmony? _harmony;

    private void Awake()
    {
        try
        {
            Logger.LogInfo(
                $"[{PluginName}] Awake (Guid: {PluginGuid}, Version: {PluginLongVersion})"
            );

            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll();
        }
        catch (Exception ex)
        {
            Logger.LogError($"[{PluginName}] Error during Awake: {ex}");
        }
    }

    private void OnDestroy()
    {
        Logger.LogInfo($"[{PluginName}] OnDestroy (Version: {PluginLongVersion})");

        if (_harmony is null)
            return;

        try
        {
            // If using BepInEx ScriptEngine for hot-reload, you may want to unpatch here.
            // For release builds, be aware this can be called immediately after Awake(),
            // which may break your mod depending on your use-case.

            // _harmony.UnpatchSelf();
        }
        catch (Exception ex)
        {
            Logger.LogError(
                $"[{PluginName}] Error while unpatching Harmony in {nameof(OnDestroy)}: {ex}"
            );
        }
        finally
        {
            _harmony = null;
        }
    }
}
