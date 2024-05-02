/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using UnityEngine;
using RTDK.InspectorPlus;
using System;

public class InspectorSample : MonoBehaviour
{

    [Title(nameof(DynamicTitle), 20, true, stringInputMode: StringInputMode.Dynamic)]
    [SerializeField] private string stringField04;

    private string DynamicTitle() => $"This is a dynamic title: {stringField04}";

    //

    [Header("Required Attribute:")]
    [SerializeField, Required] private GameObject objectField;

    //

    [Header("AssetPreview attribute:")]
    [SerializeField, AssetPreview] private Sprite spriteAsset;
    [SerializeField, AssetPreview(64f, 64f)] private Material materialAsset;
    [SerializeField, AssetPreview(32f, 32f)] private Mesh meshAsset;

    // 

    [Header("Clamp Attribute:")]
    [SerializeField, Clamp(-10, 10)] private int clampIntField;
    [SerializeField, Clamp(-0.5f, 10.5f)] private float clampFloatField;
    [Space]
    [SerializeField, Clamp(-10f, 10f, -5f, 5f)] private Vector2 vector2Field;
    [SerializeField, Clamp(-10f, 10f, -5f, 5f, -1f, 1f)] private Vector3 vector3Field;

    //

    [Header("ColorField Attribute:")]
    [SerializeField, ColorField(GUIColor.Orange)] private int colorIntField;
    [SerializeField] private double doubleField;
    [SerializeField, ColorField(3f, 252f, 177f)] private string stringField;
    [SerializeField, ColorField("#8c508b")] private bool boolField;
    [SerializeField] private Vector3 vectorField;

    //

    [Header("ConditionalField Attribute Hide/Show:")]
    public bool condition01;
    public bool condition02;

    [ConditionalField(ConditionType.AND, nameof(condition01), nameof(condition02))]
    [SerializeField] private int conditionalFieldAND;


    //

    [Serializable]
    private struct Data
    {
        public int intField;
        public float floatField;
        public string stringField;
        public bool boolField;
    }

    [Header("DataTable Attribute:")]
    [SerializeField, DataTable(true)] private Data structField;
    [SerializeField, DataTable(showLabels: false)] private Data[] structArray;

    // 

    [Header("Dropdown Attribute:")]
    [Dropdown(nameof(intValues))]
    [SerializeField] private int intDropdown;

    [Dropdown(nameof(stringValues))]
    [SerializeField] private string stringDropdown;

    [Dropdown(nameof(floatValues))]
    [SerializeField] private float floatDropdown;

    [SerializeField, HideInInspector] private int[] intValues = new int[] { 0, 1, 2 };

    [SerializeField, HideInInspector] private string[] stringValues = new string[] { "Value01", "Value02", "Value03" };

    [SerializeField, HideInInspector] private float[] floatValues = new float[] { 0.5f, 1.8f, 69.420f };

    //

    [Header("Wrap Attribute:")]
    [SerializeField, Wrap(0, 20)] private int warpIntField;
    [SerializeField, Wrap(0f, 360f)] private float wrapFloatField;
    [Space]
    [SerializeField, Wrap(0f, 10f, -10f, 0f)] private Vector2 wrapVector2Field;
    [SerializeField, Wrap(0f, 10f, -10f, 0f, -20f, 20f)] private Vector3 wrapVector3Field;

    //

    [Header("Suffix Attribute:")]
    [SerializeField, Suffix("meters")] private float intField;
    [SerializeField, Suffix("km", 30f)] private float floatField;
    [SerializeField, Suffix(nameof(dynamicSuffix), stringInputMode: StringInputMode.Dynamic)] private string dynamicSuffix;

    //

    [Button("Hello World", 40)]
    public void PrintInConsole()
    {
        print("Hello world!");
    }
}
