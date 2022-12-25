using System;
using UnityEngine;

namespace Gameplay.GameplayObjects.MiniGame
{
    [CreateAssetMenu(menuName = "VRGame/MiniGame/NodeData")]
    public class NodeData : ScriptableObject
    {
        public Material Material;

        public bool isLockRotate;
        public bool isRightRotate;

        public Color OnColor = Color.yellow;
        public Color OffColor = Color.white;

        public NodeDirections _nodeDirections;
    }
}