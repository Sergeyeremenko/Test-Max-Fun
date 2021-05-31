using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GeneratorPlanets))]
public class EditorPlanet : Editor
{
    public void Start()
    {
        OnInspectorGUI();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GeneratorPlanets generator = (GeneratorPlanets)target;
        if (generator.IsAuto) generator.GeneratePlanetsInEditor();
        if (GUILayout.Button("Generate")) generator.GeneratePlanetsInEditor();
    }
}