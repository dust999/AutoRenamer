using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AutoRenamer 
{
    [MenuItem("Tools/AutoRename")]
    public static void RenameObjects()
    {
        int i = 1;
        GameObject [] gameObjects = Selection.gameObjects;
        Array.Sort(gameObjects, new UnityTransformSort());

        foreach (GameObject obj in gameObjects)
        {
            obj.name += " (" + i + ")";
            i++;

            Debug.Log(obj);
        }

    }

}
public class UnityTransformSort : IComparer<GameObject>
{
    public int Compare(GameObject lhs, GameObject rhs)
    {
        if (lhs == rhs) return 0;
        if (lhs == null) return -1;
        if (rhs == null) return 1;
        return (lhs.transform.GetSiblingIndex() > rhs.transform.GetSiblingIndex()) ? 1 : -1;
    }
}
