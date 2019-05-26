using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    [SerializeField] private float minTimeScale;

    private void Update()
    {
        Time.timeScale = TimeScale();
    }
    public float TimeScale()
    {
        float time = Mathf.Abs(MobileController.Horizontal) + Mathf.Abs(MobileController.Vertical);
        if (time > minTimeScale)
            return time;
        else
            return minTimeScale;
    }
}
