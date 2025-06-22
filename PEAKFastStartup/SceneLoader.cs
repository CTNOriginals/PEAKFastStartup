using PEAKProto.Utils;
using UnityEngine.SceneManagement;

public static class SceneLoader {
	public static void Start() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		CLogger.LogInfo($"Scene Loaded: {scene.name} | {mode}");
		if (scene.name == "Pretitle") {
			CLogger.LogInfo("Skipping pretitle, loading main menu");
			SceneManager.LoadScene("WilIsland");
		}
	}
}