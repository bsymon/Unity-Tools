using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SceneField {
	
	public string SceneName {
		get { return sceneName; }
	}
	
	// -- //
	
	[SerializeField]
	private Object sceneAsset;
	
	[SerializeField]
	private string sceneName;
	
	// -- //
	
	static public implicit operator string(SceneField sceneField) {
		return sceneField.SceneName;
	}
	
#if UNITY_EDITOR
	static public implicit operator SceneAsset(SceneField sceneField) {
		return sceneField.sceneAsset as SceneAsset;
	}
#endif
	
}
