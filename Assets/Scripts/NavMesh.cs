using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    public static NavMesh Instance;

    public Node[,] nodes;
    public float nodeRadius;
    public GameObject area;
    public float nodeDistance;
    public GameObject nodeDebug;

    public Vector2 startingPosition;

    private void Start()
    {
        NavMesh.Instance = this;
        SpriteRenderer spriteRenderer = area.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Critical error during NavMesh Generation: no SpriterRenderer found");
        }

        startingPosition = area.transform.TransformPoint(spriteRenderer.sprite.bounds.min);
        Vector2 size = spriteRenderer.bounds.size;
        Vector2Int length = new Vector2Int((int)(size.x / nodeDistance), (int)(size.y / nodeDistance));
        nodes = new Node[length.x, length.y];
        for (int y = 0; y < length.y; y++)
        {
            for (int x = 0; x < length.x; x++)
            {
                Vector2 nodePosition = new Vector2(x * nodeDistance + startingPosition.x, y * nodeDistance + startingPosition.y);
                if (NodeOK(nodePosition))
                {
                    nodes[x, y] = new Node(nodePosition);
                }
            }
        }
        Node source;
        Node destination;
        for (int y = 0; y < length.y; y++)
        {
            for (int x = 0; x < length.x; x++)
            {
                source = nodes[x, y];
                if (source != null)
                {
                    GameObject.Instantiate(nodeDebug, nodes[x, y].position, Quaternion.identity);
                    source.neighbors = new List<Node>();
                    foreach (Vector2Int direction in Utilities.Directions8)
                    {
                        destination = GetNode(new Vector2Int(x + direction.x, y + direction.y));
                        if (destination != null && EdgeOK(source, destination))
                        {
                            //Debug.Log("drawing line between " + source.position + " and " + destination.position);
                            //Debug.DrawLine(source.position, destination.position, Color.magenta, Mathf.Infinity);
                            source.neighbors.Add(destination);
                        }
                    }
                }
            }
        }
    }

    public Node GetNode(Vector2Int position)
    {
        if ((position.x < 0) || (position.x >= nodes.GetLength(0)) || (position.y < 0) || (position.y >= nodes.GetLength(1)))
        {
            return null;
        }
        return nodes[position.x, position.y];
    }

    public bool EdgeOK(Node source, Node destination)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(source.position, nodeRadius, destination.position - source.position, (destination.position - source.position).magnitude, LayerMask.GetMask("Impassable"));
        if (hits.Length > 0)
        {
            return false;
        }
        return true;
    }

    // Returns true if a node can be placed at the given position, false otherwise.
    public bool NodeOK(Vector2 position)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(position, nodeRadius, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Impassable"));
        if (hits.Length > 0)
        {
            return false;
        }
        return true;
    }

    public List<Node> GetPath(Node source, Node destination)
    {
        //Debug.Log("Drawing: " + source.position + " | " + destination.position);

        Node current;
        float tentativeGScore;
        List<Node> totalPath = new List<Node>();
        List<Node> openSet = new List<Node>() { source };
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        Dictionary<Node, float> gScore = new Dictionary<Node, float>();
        gScore[source] = 0;
        Dictionary<Node, float> fScore = new Dictionary<Node, float>();
        fScore[source] = Heuristic(source, destination);

        while (openSet.Count > 0)
        {
            current = GetBestGuessNode(openSet, fScore);
            if (current == destination)
            {
                totalPath.Add(current);
                while (cameFrom.ContainsKey(current))
                {
                    current = cameFrom[current];
                    totalPath.Insert(0, current);
                }
                Debug.Log("Pathfinsing successful!");
                return totalPath;
            }

            openSet.Remove(current);
            Debug.Log("A");
            Debug.Log(current.neighbors);
            foreach (Node neighbor in current.neighbors)
            {
                tentativeGScore = GetScore(gScore, current) + (current.position - neighbor.position).magnitude;
                if (tentativeGScore < GetScore(gScore, neighbor))
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = tentativeGScore + Heuristic(neighbor, destination);
                    if (!(openSet.Contains(neighbor)))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
        Debug.LogError("PATHFINDING FAIL!!!!!!!");
        return totalPath;
    }

    public float GetScore(Dictionary<Node, float> map, Node key)
    {
        if (!(map.ContainsKey(key)))
        {
            return Mathf.Infinity;
        }
        return map[key];
    }

    public Node GetBestGuessNode(List<Node> openSet, Dictionary<Node, float> fScore)
    {
        Node bestGuess = null;
        foreach (Node node in openSet)
        {
            if ((bestGuess == null) || (GetScore(fScore, node) < GetScore(fScore, bestGuess)))
            {
                bestGuess = node;
            }
        }
        return bestGuess;
    }

    public float Heuristic(Node source, Node destination)
    {
        float dx = destination.position.x - source.position.x;
        float dy = destination.position.y - source.position.y;

        if (Mathf.Abs(dx) > Mathf.Abs(dy))
        {
            return GetDistanceForHeuristic(dx, dy);
        }
        return GetDistanceForHeuristic(dy, dx);
    }

    public float GetDistanceForHeuristic(float p, float q)
    {
        return (p - q) + (Mathf.Sqrt((2) * (Mathf.Pow(q, 2))));
    }

    public void DrawPath(List<Node> nodes)
    {
        Node source = null;
        foreach(Node target in nodes)
        {
            if (source == null)
            {
                source = target;
            }
            else
            {
                Debug.DrawLine(source.position, target.position, Color.green, 1f);
            }
            source = target;
        }
    }

    public Node GetClosestNode(Vector3 position)
    {
        return nodes[Mathf.RoundToInt((position.x - startingPosition.x) / nodeDistance), Mathf.RoundToInt((position.y - startingPosition.y) / nodeDistance)];
    }

    public class Node
    {
        public Vector2 position;
        public List<Node> neighbors;

        public Node(Vector2 position)
        {
            this.position = position;
        }
    }

}
