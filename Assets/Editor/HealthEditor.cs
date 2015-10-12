using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(NCHealth))]
[CanEditMultipleObjects]
public class HealthEditor : Editor 
{
	SerializedProperty hurtClipProp;
	SerializedProperty deathClipProp;
	SerializedProperty hitPointsProp;
	SerializedProperty invulnerableProp;
	SerializedProperty npcProp;
	SerializedProperty healthSliderProp;
	SerializedProperty damageImageProp;
	SerializedProperty flashSpeedProp;
	SerializedProperty flashColorProp;

	void OnEnable()
	{
		hurtClipProp = serializedObject.FindProperty("hurtClip");
		deathClipProp = serializedObject.FindProperty("deathClip");
		hitPointsProp = serializedObject.FindProperty("hitPoints");
		invulnerableProp = serializedObject.FindProperty("invulnerable");
		npcProp = serializedObject.FindProperty("npc");
		healthSliderProp = serializedObject.FindProperty("healthSlider");
		damageImageProp = serializedObject.FindProperty("damageImage");
		flashSpeedProp = serializedObject.FindProperty("flashSpeed");
		flashColorProp = serializedObject.FindProperty("flashColor");
	}

	public override void OnInspectorGUI() 
	{
		// Update the serializedProperty - always do this at the beginning of OnInspectorGUI.
		serializedObject.Update ();

		EditorGUILayout.PropertyField(hurtClipProp, new GUIContent("Hurt Clip"));
		EditorGUILayout.PropertyField(deathClipProp, new GUIContent("Death Clip"));
		EditorGUILayout.PropertyField(hitPointsProp, new GUIContent("Hit Points"));
		EditorGUILayout.PropertyField(invulnerableProp, new GUIContent("Invulnerable"));
		EditorGUILayout.PropertyField(npcProp, new GUIContent("NPC"));

		if (npcProp.boolValue == false) {
			EditorGUILayout.PropertyField(healthSliderProp, new GUIContent("healthSilder"));
			EditorGUILayout.PropertyField(damageImageProp, new GUIContent("damageImage"));
			EditorGUILayout.PropertyField(flashSpeedProp, new GUIContent("flashSpeed"));
			EditorGUILayout.PropertyField(flashColorProp, new GUIContent("flashColor"));
		}

		// Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
		serializedObject.ApplyModifiedProperties ();
	}
}
