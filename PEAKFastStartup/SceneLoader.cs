using PEAKFastStartup;
using PEAKProto.Utils;
using UnityEngine.SceneManagement;

public static class SceneLoader {
	// private static bool _initialStartup = true;
	public static bool LoadedIslandStartup = true;

	public static void Start() {
		if (!Plugin.LoadIslandOnStart) {
			return;
		}

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		CLogger.LogInfo($"Scene Loaded: {scene.name} | {mode}");
		if ((Plugin.SkipSplashScreens && scene.name == "Pretitle") || (!Plugin.SkipSplashScreens && scene.name == "Title")) {
			CLogger.LogInfo("Skipping pretitle, loading main menu");
			SceneManager.LoadScene("WilIsland");
		}
	}
}