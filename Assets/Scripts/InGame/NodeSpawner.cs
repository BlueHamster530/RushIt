using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    int nCurrentIndex;
    MusicNodeInfoList NodeList;

    [SerializeField]
    NodeInfo[] NodePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        nCurrentIndex = 0;
    }
    private void nodeSpawn()
    {
        if (cGameManager.instance.bIsStart == false) return;

        if(NodeList.nodeList.Count <=0 || NodeList.nodeList.Count <= nCurrentIndex) return;
        if (cGameManager.instance.fCurrnetPlayTime >= NodeList.nodeList[nCurrentIndex].fSpawnTime)
        {
            EnableNode(NodeList.nodeList[nCurrentIndex].nType, NodeList.nodeList[nCurrentIndex].xPos, NodeList.nodeList[nCurrentIndex].yPos);
            nCurrentIndex++;
         // NodeList.nodeList.RemoveAt(0);
        }
    }
    private void EnableNode(int _Type, float _x, float _y)
    {
        bool bIsCheck = true;
        for (int i = 0; i < NodePrefabs.Length; i++)
        {
            if (NodePrefabs[i].gameObject.activeSelf == false)
            {
                NodePrefabs[i].Init(_Type);
                NodePrefabs[i].transform.position = new Vector3(_x, _y, 0);
                NodePrefabs[i].gameObject.SetActive(true);
                bIsCheck = false;
                break;
            }
        }
        if (bIsCheck == true)
        {
            print("노드 프리팹 배열수 부족");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (NodeList == null)
        {
            NodeList = NodeBuliderMusicInfoMaker.instance.NodeList;
            print(NodeList.nodeList.Count);
        }
        nodeSpawn();
    }
}
