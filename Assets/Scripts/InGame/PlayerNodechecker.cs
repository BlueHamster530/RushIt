using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNodechecker : MonoBehaviour
{
    // Start is called before the first frame update
    Queue<NodeInfo> nodes = new Queue<NodeInfo>();
    [SerializeField]
    PlayerInfomation Playerinfo;
    public void PressNodeCheckrt(int _Type,bool IsBarColorBlack)
    {
        if (IsBarColorBlack == true)
            _Type = _Type + 4;

        if (nodes.Count > 0)
        {
            DeQueuueNode();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Playerinfo.bIsNodeBuilder == true) return;
        if (collision.CompareTag("Node"))
        {
            nodes.Enqueue(collision.gameObject.transform.GetComponent<NodeInfo>());
        }
    }
    private void DeQueuueNode(NodeScore _Score = NodeScore.Null)
    {
        if (nodes.Count <= 0) return;
       NodeInfo clone = nodes.Dequeue();
        if (_Score == NodeScore.Null)
        {
            float fDistance = Vector2.Distance(this.transform.position, clone.transform.position);
            if (fDistance >= 4.6f)
            {
                _Score = NodeScore.Bad;
            }
            else if (fDistance >= 1.5f)
            {
                _Score = NodeScore.Good;
            }
            else
            {
                _Score = NodeScore.Perfact;
            }
        }
        print(_Score);
        cGameManager.instance.AddScore((int)_Score);
        clone.DisableObject(1.5f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Playerinfo.bIsNodeBuilder == true) return;
        if (collision.CompareTag("Node"))
        {
            DeQueuueNode(NodeScore.Bad);
        }
    }
}
