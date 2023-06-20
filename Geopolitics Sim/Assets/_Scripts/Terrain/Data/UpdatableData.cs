using System;
#if UNITY_EDITOR
	using UnityEditor;
#endif
using UnityEngine;

public class UpdatableData : ScriptableObject {

	public event Action OnValuesUpdated;
	public bool autoUpdate;

	protected virtual void OnValidate() {
		if (autoUpdate) {
			
		#if UNITY_EDITOR
			EditorApplication.update += NotifyOfUpdatedValues;
		#endif
			
		}
	}

	// ReSharper disable Unity.PerformanceAnalysis
	public void NotifyOfUpdatedValues() {
		#if UNITY_EDITOR
			EditorApplication.update -= NotifyOfUpdatedValues;
		#endif
		OnValuesUpdated?.Invoke ();
	}

}
