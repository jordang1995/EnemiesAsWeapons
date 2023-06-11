using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
    public Node[,] nodes;
    public float nodeRadius;
    public GameObject area;
    public float nodeDistance;
    public GameObject nodeDebug;

    private void Start()
    {
        SpriteRenderer spriteRenderer = area.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Critical error during NavMesh Generation: no SpriterRenderer found");
        }

        Vector2 startingPosition = area.transform.TransformPoint(spriteRenderer.sprite.bounds.min);
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
                    foreach (Vector2Int direction in Utilities.Directions8)
                    {
                        destination = GetNode(new Vector2Int(x + direction.x, y + direction.y));
                        if (destination != null && EdgeOK(source, destination))
                        {
                            Debug.Log("drawing line between " + source.position + " and " + destination.position);
                            Debug.DrawLine(source.position, destination.position, Color.magenta, Mathf.Infinity);
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
