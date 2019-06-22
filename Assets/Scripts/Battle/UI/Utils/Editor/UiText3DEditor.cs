using UnityEditor;

[CustomEditor(typeof(UiText3D), true)]
public class UiText3DEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        (target as UiText3D).ResetColor();
    }
}