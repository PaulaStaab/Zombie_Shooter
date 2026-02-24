using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
class DefaultPlayScene
{
    const string START_SCENE_PATH = "Assets/Scenes/StartScreen.unity";  // Deinen Pfad prüfen!

    static DefaultPlayScene()
    {
        EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(START_SCENE_PATH);
    }
}
