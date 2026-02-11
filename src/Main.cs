using System;
using BepInEx;
using HarmonyLib;
using StationeersMods.Interface;

namespace ExampleMod;

[StationeersMod(PluginGuid, PluginName, PluginVersion)]
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public sealed class ExampleModPlugin : BaseUnityPlugin
{
    public const string PluginGuid = ThisAssembly.ModInfo.AssemblyGuid;
    public const string PluginName = ThisAssembly.ModInfo.AssemblyName;
    public const string PluginVersion = ThisAssembly.ModInfo.Version;
    public const string PluginVersionGit = ThisAssembly.ModInfo.VersionGit;
    public static readonly string PluginBuildTime = DateTime
        .Parse(ThisAssembly.ModInfo.BuiltTime)
        .ToLocalTime()
        .ToString("o");

    private Harmony _harmony;

    private void Awake()
    {
        try
        {
            Logger.LogInfo(
                $"[{PluginName}] Awake (Guid: {PluginGuid}, Version: {PluginVersionGit}, BuildTime: {PluginBuildTime})"
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
        Logger.LogInfo($"[{PluginName}] OnDestroy (Version: {PluginVersionGit})");

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
