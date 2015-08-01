using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Tiled2Unity.CustomTiledImporter]
public class CustomImporter : Tiled2Unity.ICustomTiledImporter
{
    public void HandleCustomProperties(UnityEngine.GameObject gameObject,
        IDictionary<string, string> props)
    {
        // Does this game object have a spawn property?
        if (!props.ContainsKey("SpawnEnemy"))
            return;

        // Load the prefab assest and Instantiate it
        string prefabPath = "Assets/Prefabs/" + props["SpawnEnemy"] + ".prefab";
        UnityEngine.Object spawn = UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
        if (spawn != null)
        {
            GameObject spawnInstance =
                (GameObject)GameObject.Instantiate(spawn);
            spawnInstance.name = spawn.name;

            // Use the position of the game object we're attached to
            spawnInstance.transform.parent = gameObject.transform;
            spawnInstance.transform.localPosition = new Vector3(1f, 1f, 0f);
        }

    }

    public void CustomizePrefab(UnityEngine.GameObject prefab)
    {
        // Do nothing
    }
}
