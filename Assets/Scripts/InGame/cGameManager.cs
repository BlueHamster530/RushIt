using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeScore
{
    Null = -1, Bad = 0, Good = 50, Perfact = 100
}
public class cGameManager : MonoBehaviour
{
    public static cGameManager instance;
    // Start is called before the first frame update

    public bool bIsStart;
    public bool bIsMoveLine;

    [SerializeField]
    MusicInfo musicinfo;

    [SerializeField]
    [Header("초반 딜레이 시간 설정")]
    public float fDelayTimeBeforeStart;

    public float fCurrnetPlayTime { get; set; }
    public float fMusicPlayDelayTime { get; set; }
    private int nScore;

    private bool bIsMusicAlreayStart = false;
    void Awake()
    {
        instance = this;
        bIsStart = false;
        bIsMoveLine = false;
        nScore = 0;
        fCurrnetPlayTime = 0;
        bIsMusicAlreayStart = false;
        if (musicinfo == null)
            musicinfo = GameObject.Find("MusicInfo").GetComponent<MusicInfo>();

        fMusicPlayDelayTime = 0;
    }
    private void FixedUpdate()
    {
        if (bIsStart == true)
        {
            fCurrnetPlayTime += Time.deltaTime;
            if (bIsMusicAlreayStart == false)
            {
                fMusicPlayDelayTime += Time.deltaTime;
                if (fMusicPlayDelayTime >= fDelayTimeBeforeStart)
                {
                    bIsMusicAlreayStart = true;
                    musicinfo.MusicStartOrPause(true);
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameStartOrPuase();
        }
    }
    public void GameStartOrPuase()
    {
        bIsMoveLine = !bIsMoveLine;
        bIsStart = !bIsStart;
        if (bIsMusicAlreayStart == true)
        {
            musicinfo.MusicStartOrPause(bIsStart);
        }
    }
    public void AddScore(int _Score)
    {
        nScore += _Score;
    }
    public int GetScore()
    {
        return nScore;
    }    
}
