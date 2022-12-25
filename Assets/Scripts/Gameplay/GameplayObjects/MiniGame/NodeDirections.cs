using System;
using UnityEngine;

namespace Gameplay.GameplayObjects.MiniGame
{
    [Serializable]
    public struct NodeDirections
    {
        public bool Up => _up;
        public bool Down => _down;
        public bool Right => _right;
        public bool Left => _left;
        
        [SerializeField] private bool _up;
        [SerializeField] private bool _down;
        [SerializeField] private bool _right;
        [SerializeField] private bool _left;

        public NodeDirections(bool up, bool down, bool right, bool left, int rotateCount = 0)
        {
            _up = up;
            _down = down;
            _right = right;
            _left = left;

            if (rotateCount != 0) RotateDirections(rotateCount);
        }

        public void RotateDirections(int rotateCount)
        {
            _up = this[0 + rotateCount % 4];
            _down = this[1 + rotateCount % 4];
            _right = this[2 + rotateCount % 4];
            _left = this[3 + rotateCount % 4];
        }

        private bool this[int index]
        {
            get
            {
                return index switch
                {
                    0 => _up,
                    1 => _down,
                    2 => _right,
                    3 => _left,
                    _ => throw new Exception("not valid index")
                };
            }
        }
    }
}