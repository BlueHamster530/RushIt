using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    [SerializeField]
    Sprite[] Spirteimage;//상하좌우순서 흰 검 순서
    SpriteRenderer renderer;

    [SerializeField]
    int nType;

    // Start is called before the first frame update
    //private void Start()
    //{
        //renderer = GetComponent<SpriteRenderer>();
        //Init(nType);
    //}
    public void Init(int _type)
    {
        if(renderer == null)
            renderer = GetComponent<SpriteRenderer>();
        SetUpSprite(_type);
    }
    private void SetUpSprite(int _type)
    {
        nType = _type;
        if (nType >= 4)
        {
            nType -= 4;
            renderer.color = Color.black;
        }
        else
        {
            renderer.color = Color.white;
        }
        renderer.sprite = Spirteimage[_type];
        
    }
    public void DisableObject(float _time = 0.0f)
    {
        Invoke("UnableObject", _time);
    }
    private void UnableObject()
    {
        gameObject.SetActive(false);

    }
}
