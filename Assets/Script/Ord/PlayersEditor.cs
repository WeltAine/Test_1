using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayersController))]
public class PlayersEditor : Editor
{

    public override void OnInspectorGUI()
    {
        PlayersController pc = target as PlayersController;


        if (DrawDefaultInspector())
        {
            
        }

        //EditorGUILayout.Space();
        if (GUILayout.Button("Generate Solider"))
        {

            // 只有当按钮被点击时，才生成地图
            pc.SoliderNumber += 1;
        }


    }

}
