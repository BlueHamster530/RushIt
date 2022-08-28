using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRotation : MonoBehaviour
{
    [SerializeField]
    [Header("판정선이 1바퀴 도는데 걸리는 시간")]
    float fSpeed = 1.0f;
    [SerializeField]
    [Header("판정선이 1바퀴 도는데 걸리는 시간의 스피드")]
    float fSpeedbytick = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        float originrotationz = ((360.0f / fSpeed) * cGameManager.instance.fDelayTimeBeforeStart);
        print(originrotationz);
        transform.Rotate(new Vector3(0, 0, -originrotationz));
    }
    private void Rotation()
    {
        if (cGameManager.instance.bIsMoveLine == false) return;

        this.transform.Rotate(new Vector3(0, 0, 360.0f/fSpeed) * Time.deltaTime);
        fSpeedbytick = 360.0f / fSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotation();
    }
}
