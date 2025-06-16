using UnityEngine;
using UnityEditor;
using System.IO;

public class ConvertShadersInFolderToURP : EditorWindow
{
    private string folderPath = "Assets/";

    [MenuItem("Tools/Convert Materials to URP/In Specific Folder")]
    static void ShowWindow()
    {
        GetWindow<ConvertShadersInFolderToURP>("Convert Shaders in Folder");
    }

    void OnGUI()
    {
        GUILayout.Label("Select Folder to Convert Materials", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        folderPath = EditorGUILayout.TextField("Folder Path", folderPath);
        if (GUILayout.Button("...", GUILayout.Width(30)))
        {
            string selectedPath = EditorUtility.OpenFolderPanel("Select Folder", "Assets", "");
            if (!string.IsNullOrEmpty(selectedPath))
            {
                // Convert absolute path to relative Unity path
                if (selectedPath.StartsWith(Application.dataPath))
                {
                    folderPath = "Assets" + selectedPath.Substring(Application.dataPath.Length);
                }
            }
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Convert to URP/Lit"))
        {
            ConvertMaterials(folderPath);
        }
    }

    static void ConvertMaterials(string folder)
    {
        if (!AssetDatabase.IsValidFolder(folder))
        {
            Debug.LogError($"Invalid folder: {folder}");
            return;
        }

        string[] guids = AssetDatabase.FindAssets("t:Material", new[] { folder });
        int count = 0;

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader.name != "Universal Render Pipeline/Unlit")
            {
                mat.shader = Shader.Find("Universal Render Pipeline/Unlit");
                EditorUtility.SetDirty(mat);
                count++;
            }
        }

        AssetDatabase.SaveAssets();
        Debug.Log($"{count} materials in '{folder}' converted to URP Lit shader.");
    }
}
