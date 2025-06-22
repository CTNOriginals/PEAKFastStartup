using HarmonyLib;
using PEAKProto.Utils;

[HarmonyPatch(typeof(Character))]
public static class CharacterPatch {
	[HarmonyPrefix, HarmonyPatch(nameof(Character.StartPassedOutOnTheBeach))]
	public static bool StartPassedOutOnTheBeachPatch(ref Character __instance) {
		CLogger.LogInfo($"Character.StartPassedOutOnTheBeach | Startup: {SceneLoader.LoadedIslandStartup}");

		if (!SceneLoader.LoadedIslandStartup) {
			return true;
		}

		SceneLoader.LoadedIslandStartup = false;
		return false;
	}
}