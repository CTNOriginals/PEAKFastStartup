using HarmonyLib;
using PEAKFastStartup;

[HarmonyPatch(typeof(Pretitle))]
public static class PretitlePatch {
	[HarmonyPrefix, HarmonyPatch(nameof(Pretitle.Update))]
	public static bool UpdatePatch(ref Pretitle __instance) {
		if (!Plugin.SkipSplashScreens) {
			return true;
		}

		__instance.allowedToSwitch = true;
		return false;
	}
}