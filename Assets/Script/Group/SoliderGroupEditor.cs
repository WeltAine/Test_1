using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NewCode
{
    [CustomEditor(typeof(SoliderGroup))]
    public class SoliderGroupEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SoliderGroup sg = target as SoliderGroup;


            if (DrawDefaultInspector())
            {

            }

            //EditorGUILayout.Space();
            if (GUILayout.Button("Generate One Solider"))
            {

                // 只有当按钮被点击时，才生成地图
                sg.AddMembers(1);
                
            }


        }
    }
}
