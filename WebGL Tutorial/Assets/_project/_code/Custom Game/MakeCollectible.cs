using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MakeCollectible : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Assets/Create/Data/New Collectible")]
    public static void Create()
    {
        CollectibleEntity asset = ScriptableObject.CreateInstance<CollectibleEntity>();

        AssetDatabase.CreateAsset(asset, "Assets/_project/_data/NewCollectible.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
#endif
}

