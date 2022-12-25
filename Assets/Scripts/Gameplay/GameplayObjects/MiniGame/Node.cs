using System;
using Gameplay.GameplayObjects.MiniGame;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private NodeData _data;
    [SerializeField] private MeshRenderer _renderer;

    public bool IsTurned;
    public NodeDirections Directions { get; private set; }
    public NodePoint Position { get; private set; }
    
    public event Action<Node> OnRotate;
    public event Action<Node> OnTurned;
    
    private Quaternion Rotation => gameObject.transform.rotation;
    private int RotateCount => (int)(Rotation.x / 90);


    public void TurnOn()
    {
        IsTurned = true;
        OnTurned?.Invoke(this);
    }

    public void UpdateMaterial()
    {
        _renderer.materials = new[] { _data.Material };
    }

    public void SetPosition(NodePoint position)
    {
        Position = position;
    }

    private void Start()
    {
        UpdateMaterial();
        Directions = _data._nodeDirections;
    }

    private void Rotate()
    {
        if (_data.isLockRotate) return;
        
        var x = Rotation.x;
        x += _data.isRightRotate ? 90 : -90;
        if (Math.Abs(Math.Abs(x) - 360) < float.Epsilon) x = 0;
        gameObject.transform.rotation = new Quaternion(x, Rotation.y, Rotation.z, Rotation.w);
        
        Directions.RotateDirections(RotateCount);

        OnRotate?.Invoke(this);
    }

    private void ChangeColor()
    {
        _renderer.materials[0].color = IsTurned ? _data.OnColor : _data.OffColor;
    }
}
