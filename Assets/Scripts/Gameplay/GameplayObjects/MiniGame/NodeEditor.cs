using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Gameplay.GameplayObjects.MiniGame
{
    [CustomEditor( typeof(Node) )]
    [CanEditMultipleObjects]
    public class NodeEditor : Editor
    {
        Node _subject;
        SerializedProperty _data;
        SerializedProperty _renderer;
        
        private int index;
        private int oldIndex;
        private Dictionary<string, NodeData> _nodesData;
        private string[] _popupList;
        
        void OnEnable () 
        {
            _subject = target as Node;

            _data = serializedObject.FindProperty("_data");
            _renderer = serializedObject.FindProperty("_renderer");
            _nodesData = FindAllNodeData();
            _popupList = _nodesData.Keys.ToArray();
            index = FindIndex(_data.objectReferenceValue.name);
            oldIndex = index;
        }

        private int FindIndex(string s)
        {
            for (var i = 0; i < _popupList.Length; i++)
            {
                if (_popupList[i] == s) return i;
            }

            return 0;
        }
        
        public override void OnInspectorGUI() 
        {
            serializedObject.Update ();

            index = EditorGUILayout.Popup(index, _popupList);
            EditorGUILayout.PropertyField(_renderer);

            if (index != oldIndex)
            {
                _data.objectReferenceValue = _nodesData[_popupList[index]];
                serializedObject.ApplyModifiedProperties ();
                _subject.UpdateMaterial();
                oldIndex = index;
            }

            serializedObject.ApplyModifiedProperties ();
        }

        private static Dictionary<string, NodeData> FindAllNodeData()
        {
            var guids = AssetDatabase.FindAssets("t:" + nameof(NodeData));
            var nodesData = new Dictionary<string, NodeData>();
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var node = AssetDatabase.LoadAssetAtPath<NodeData>(path);
                nodesData[node.name] = node;
            }

            return nodesData;
        }
    }
}