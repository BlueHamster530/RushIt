using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject NodePrefab;
    [SerializeField]
    PlayerInfomation player;

    [SerializeField]
    Transform UpDownTransform;
    [SerializeField]
    Transform LeftRightTransform;


    MusicNodeInfoList nodeList = new MusicNodeInfoList();

    float fCurrentNodeBuildPlayTime;

    // Start is called before the first frame update
    public void AddNodeList(float _Time, int _Type, Vector3 Position)
    {
        MusicNodeInfo clone = new MusicNodeInfo(_Time, _Type, Position.x, Position.y);
        nodeList.nodeList.Add(clone);
    }

    private void KeyEvent()
    {
        if (cGameManager.instance.bIsStart == false) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PushNodePrefab(fCurrentNodeBuildPlayTime, 0,UpDownTransform.position);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PushNodePrefab(fCurrentNodeBuildPlayTime, 1, UpDownTransform.position);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PushNodePrefab(fCurrentNodeBuildPlayTime, 2, LeftRightTransform.position);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PushNodePrefab(fCurrentNodeBuildPlayTime, 3, LeftRightTransform.position);
        }
    }
    [ContextMenu("SaveNodeList")]
    public void SaveNodeList()
    {
        print(nodeList.nodeList.Count);
        NodeBuliderMusicInfoMaker.instance.NodeList = nodeList;
        NodeBuliderMusicInfoMaker.instance.SaveNodeList();
    }
    private void PushNodePrefab(float _fTime, int Type, Vector3 _Position)
    {
        if (player.bIsNodeBarBlack == true)
            Type = Type + 4;

       AddNodeList(_fTime, Type, _Position);

        GameObject clone = Instantiate(NodePrefab, _Position, Quaternion.identity);
        clone.GetComponent<NodeInfo>().Init(Type);
        Destroy(clone, 1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        KeyEvent();
        fCurrentNodeBuildPlayTime = cGameManager.instance.fCurrnetPlayTime - cGameManager.instance.fDelayTimeBeforeStart;
    }
}
