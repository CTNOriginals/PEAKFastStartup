using System;
using PEAKFastStartup;
using UnityEngine;

namespace PEAKProto.Utils;

public static class CLogger {
	public static void Log(string message) 			{ SendLog(message, "Log"); }
	public static void LogInfo(string message) 		{ SendLog(message, "LogInfo"); }
	public static void LogError(string message) 	{ SendLog(message, "LogError"); }
	public static void LogWarning(string message) 	{ SendLog(message, "LogWarning"); }
	// public static void LogDebug(string message) 	{ SendLog(message, "LogDebug"); } //! is broken and doesnt work in PEAK
	public static void LogFatal(string message) 	{ SendLog(message, "LogFatal"); }
	public static void LogMessage(string message) 	{ SendLog(message, "LogMessage"); }
	public static void LogException(string message, SystemException exception) { SendLog(message, "LogException", exception: exception); }
	public static void LogException(string message, Exception exception) { SendLog(message, "LogException", exception: exception); }

	private static void SendLog(string message, string level = null, Exception exception = null) {
		if (!Plugin.DebugMode && (level == "LogDebug" || level == "LogInfo")) return;

		switch(level) {
			case "LogInfo": 	Plugin.Logger.LogInfo(message); 	break;
			case "LogError": 	Plugin.Logger.LogError(message); 	break;
			case "LogWarning": 	Plugin.Logger.LogWarning(message);	break;
			case "LogDebug": 	Plugin.Logger.LogDebug(message); 	break;
			case "LogFatal": 	Plugin.Logger.LogFatal(message); 	break;
			case "LogMessage": 	Plugin.Logger.LogMessage(message);	break;
			case "LogException": {
				if (exception == null) {
					Plugin.Logger.LogError($"{message}");
				}
				Plugin.Logger.LogError($"{message}\nMessage: {exception.Message}\nSource: {exception.Source}\n{exception.GetBaseException().StackTrace}\n");
			} break;
			default: {
				if (level != "Log") Debug.Log($"[{level}]: {message}");
				else Debug.Log(message);
			} break;
		}
	}
}
