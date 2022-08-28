using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfomation : MonoBehaviour
{
   public bool bIsNodeBarBlack = false;
    SpriteRenderer renderer;
    [SerializeField]
    [Header("노드빌드용일때 체크하시오")]
   public bool bIsNodeBuilder = false;

    [SerializeField]
    PlayerNodechecker UpDownNodeChecker;
    [SerializeField]
    PlayerNodechecker LeftDownNodeChecker;

    [SerializeField]
    GameObject NodeBuildObject;
    // Start is called before the first frame update
    void Start()
    {
        bIsNodeBarBlack = false;
        renderer = GetComponent<SpriteRenderer>();
        if (bIsNodeBuilder == false)
            NodeBuildObject.SetActive(false);
    }

    private void KeyEvent()
    {
        if (cGameManager.instance.bIsMoveLine == false ) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeNodeColor();
        }

        if (bIsNodeBuilder == true) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpDownNodeChecker.PressNodeCheckrt(0, bIsNodeBarBlack);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            UpDownNodeChecker.PressNodeCheckrt(1, bIsNodeBarBlack);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftDownNodeChecker.PressNodeCheckrt(2, bIsNodeBarBlack);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LeftDownNodeChecker.PressNodeCheckrt(3, bIsNodeBarBlack);
        }
    }
    public void CheckNodeScore(int _PressType)
    {
        if (bIsNodeBarBlack == true)
            _PressType = _PressType + 4;

        print(_PressType);
    }
    void Update()
    {
        KeyEvent();
    }
    private void ChangeNodeColor()
    {
        bIsNodeBarBlack = !bIsNodeBarBlack;
        if (bIsNodeBarBlack == true)
            renderer.color = Color.black;
        else
            renderer.color = Color.white;

    }
}
