using HarmonyLib;

[HarmonyPatch(typeof(Pretitle))]
public static class PretitlePatch {
	[HarmonyPrefix, HarmonyPatch(nameof(Pretitle.Update))]
	public static bool UpdatePatch(ref Pretitle __instance) {
		__instance.allowedToSwitch = true;
		return false;
	}
}