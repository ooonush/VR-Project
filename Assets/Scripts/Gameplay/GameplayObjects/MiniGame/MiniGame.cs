using System;
using System.Collections.Generic;
using UnityEngine;


public class MiniGame : MonoBehaviour
{
    [SerializeField] private NodePoint _startPoint;
    [SerializeField] private NodePoint _endPoint;
    [SerializeField] private NodeArray _nodes;

    public event Action OnEndGame;

    private static readonly List<Tuple<Func<Node, bool>, Func<Node, bool>, int, int>> checkConnectionList = new()
    {
        new (x => x.Directions.Up, x => x.Directions.Down, 0, 1),
        new (x => x.Directions.Down, x => x.Directions.Up, 0, -1),
        new (x => x.Directions.Right, x => x.Directions.Left, 1, 0),
        new (x => x.Directions.Left, x => x.Directions.Right, -1, 0),
    };

    private void Start()
    {
        CheckPoints();
        CheckNodes();
    }

    private void CheckNodes()
    {
        for (var i = 0; i < _nodes.RowCount; i++)
        {
            for (var j = 0; j < _nodes[i].NodeCount; j++)
            {
                Node node = _nodes[i][j];
                node.SetPosition(new NodePoint(i, j));
                node.OnRotate += CheckIncomingConnection;
                node.OnTurned += CheckOutgoingConnection;
            }
        }
    }
    
    private void CheckPoints()
    {
        if ((_startPoint.X == -1 && _startPoint.Y == -1) || 
            (_startPoint.X != -1 && _startPoint.Y != -1) || 
            _startPoint.X < -1 || _startPoint.Y < -1) throw new Exception("incorrect StartPoint position");
        
        if ((_endPoint.X == -1 && _endPoint.Y == -1) || 
            (_endPoint.X != -1 && _endPoint.Y != -1) || 
            _endPoint.X < -1 || _endPoint.Y < -1) throw new Exception("incorrect EndPoint position");
    }

    private void CheckIncomingConnection(Node node)
    {
        foreach (Node connectionNode in FindConnections(node))
        {
            if (!connectionNode.IsTurned) continue;
            node.TurnOn();
            break;
        }
    }
    
    private void CheckOutgoingConnection(Node node)
    {
        foreach (Node connectionNode in FindConnections(node))
        {
            connectionNode.TurnOn();
        }
    }

    private IEnumerable<Node> FindConnections(Node node)
    {
        NodePoint position = node.Position;
        
        foreach (var connection in checkConnectionList)
        {
            if (!connection.Item1.Invoke(node)) continue;
            var x = position.X + connection.Item3;
            var y = position.Y + connection.Item4;
            if ((x == -1 || y == -1) && node.IsTurned)
            {
                if (x == _endPoint.X && y == _endPoint.Y)
                {
                    EndGame();
                    break;
                }
                continue;
            }
            Node targetNode = _nodes[x][y];
            if (connection.Item2.Invoke(targetNode)) yield return targetNode;
        }
    }

    private void EndGame()
    {
        Debug.Log("EndGame");
        OnEndGame?.Invoke();
    }
}

[Serializable]
public class NodePoint
{
    [SerializeField] private int _x;
    [SerializeField] private int _y;

    public int X => _x;
    public int Y => _y;
    
    public NodePoint(int x, int y)
    {
        _x = x;
        _y = y;
    }
}

[Serializable]
public struct NodeArray
{
    [SerializeField] private NodeArrayRow[] _columns;

    public int RowCount => _columns.Length;
        
    public NodeArrayRow this[int index] => _columns[index];
}

[Serializable]
public struct NodeArrayRow
{
    [SerializeField] private Node[] _nodes;

    public int NodeCount => _nodes.Length;

    public Node this[int index] => _nodes[index];
}
