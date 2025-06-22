using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using PEAKProto.Utils;

namespace PEAKFastStartup;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
	public static new ManualLogSource Logger;
	public static Harmony Harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

	public static bool DebugMode = false;

	// public static new ConfigFile Config = new ConfigFile(Paths.ConfigPath + "\\" + MyPluginInfo.PLUGIN_GUID + ".cfg", true);
	// public static ConfigEntry<bool> SkipSplashScreens;
	public static bool SkipSplashScreens;
	// public static ConfigEntry<bool> LoadIslandOnStart;
	public static bool LoadIslandOnStart;

	private void Awake() {
		// Plugin startup logic
#if DEBUG
		DebugMode = true;
#endif

		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} {MyPluginInfo.PLUGIN_VERSION} is loaded! ({(DebugMode ? "Debug" : "Release")})");

		InitializeConfig();
		Harmony.PatchAll();
		Start();
	}

	private void InitializeConfig() {
		SkipSplashScreens = Config.Bind(
			"General",
			"SkipSplashScreens",
			true,
			"Wether or not to automatically skip the splash screens that the game shows on startup."
		).Value;
		LoadIslandOnStart = Config.Bind(
			"General",
			"LoadIslandOnStart",
			false,
			"Wether or not to load a solo play game right after the game starts, skipping the main menu and airport entirely."
		).Value;

		CLogger.LogInfo($"SkipSplashScreens: {SkipSplashScreens}");
		CLogger.LogInfo($"LoadIslandOnStart: {LoadIslandOnStart}");
	}

	private void Start() {
		SceneLoader.Start();
	}
}

//? Idea for another mod
//> Map/BL_Airport/Fences/Check In desk/AirportGateKiosk
//* Pos: -11 1,5 52,5
//* Local: -1,2676 0,394 20,8579
//* Rot: 270 180 0