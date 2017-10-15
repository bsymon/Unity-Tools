using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(SceneField))]
public class SceneFieldDrawer : PropertyDrawer {
	
	override public void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		SerializedProperty sceneAsset = property.FindPropertyRelative("sceneAsset");
		SerializedProperty sceneName  = property.FindPropertyRelative("sceneName");
		
		EditorGUI.BeginChangeCheck();
		
		sceneAsset.objectReferenceValue = EditorGUI.ObjectField(position, label, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);
		
		if(EditorGUI.EndChangeCheck()) {
			if(sceneAsset.objectReferenceValue != null) {
				sceneName.stringValue = ((SceneAsset) sceneAsset.objectReferenceValue).name;
			} else {
				sceneName.stringValue = "";
			}
		}
	}
	
}
