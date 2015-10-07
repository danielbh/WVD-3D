using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(EnemyAttack))]
[CanEditMultipleObjects]
public class EnemyAttackEditor : Editor 
{
	SerializedProperty timeBwAttacksProp;
	SerializedProperty rangedProp;
	SerializedProperty projectileProp;
	SerializedProperty weaponProp;

	void OnEnable () 
	{
		// Setup serialized properties
		timeBwAttacksProp = serializedObject.FindProperty("timeBetweenAttacks");
		rangedProp = serializedObject.FindProperty ("ranged");
		projectileProp = serializedObject.FindProperty("projectile");
		weaponProp = serializedObject.FindProperty("weapon");
	}

	public override void OnInspectorGUI() 
	{
		// Update the serializedProperty - always do this at the beginning of OnInspectorGUI.
		serializedObject.Update ();

		EditorGUILayout.PropertyField(timeBwAttacksProp, new GUIContent("Time Between Attacks"));
		EditorGUILayout.PropertyField(rangedProp, new GUIContent("Ranged"));

		if (rangedProp.boolValue == true)
		{
			EditorGUILayout.PropertyField(weaponProp, new GUIContent("Weapon"));
			EditorGUILayout.PropertyField(projectileProp, new GUIContent("Projectile"));
		}

		// Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
		serializedObject.ApplyModifiedProperties ();
	}
}
