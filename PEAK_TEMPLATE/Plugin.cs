using BepInEx;
using BepInEx.Logging;
using PEAKProto.Utils;

namespace PEAK_TEMPLATE;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
	public static new ManualLogSource Logger;

	private void Awake() {
		// Plugin startup logic
		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
	}
}
