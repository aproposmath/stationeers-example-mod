using System;
using BepInEx;
using HarmonyLib;
using StationeersMods.Interface;

namespace ExampleMod
{
    [StationeersMod(PluginGuid, PluginName, PluginVersion)]
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class ExampleModPlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "aproposmath-stationeers-example-mod"; // Change this to your own unique Mod ID
        public const string PluginName = ThisAssembly.AssemblyName;
        public const string PluginVersion = ThisAssembly.AssemblyVersion;
        public const string PluginLongVersion = ThisAssembly.AssemblyInformationalVersion;

        private Harmony _harmony = null;

        private void Awake()
        {
            try
            {
                Logger.LogInfo(
                    $"Awake {PluginName} {PluginGuid} {PluginLongVersion}"
                );

                _harmony = new Harmony(PluginGuid);
                _harmony.PatchAll();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error in {PluginName} {PluginLongVersion} Awake: {ex}");
            }
        }

        private void OnDestroy()
        {
            Logger.LogInfo($"OnDestroy {PluginName} {PluginLongVersion}");

            // Uncomment this if you are using BepInEx SriptEngine plugin for hot-reloading
            // the mod while the game is running
            // See https://github.com/BepInEx/BepInEx.Debug/blob/master/README.md#scriptengine
            // But remove it again before building a release version of your mod, as sometimes this function is called immediately
            // after Awake(), which would break your mod.

            _harmony.UnpatchSelf();
        }
    }
}
