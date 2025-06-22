using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using PEAKProto.Utils;

namespace PEAKFastStartup;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
	public static new ManualLogSource Logger;
	public static Harmony Harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

	public static bool DebugMode = false;

	private void Awake() {
		// Plugin startup logic
#if DEBUG
		DebugMode = true;
#endif

		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} {MyPluginInfo.PLUGIN_VERSION} is loaded! ({(DebugMode ? "Debug" : "Release")})");

		Harmony.PatchAll();
		Start();
	}

	}
}

//? Idea for another mod
//> Map/BL_Airport/Fences/Check In desk/AirportGateKiosk
