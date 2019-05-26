using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        //CreatePlayer();
    }

    //private void CreatePlayer()
    //{
    //    Vector3 pos = new Vector3(spawnPlayerPoint.position.x, spawnPlayerPoint.position.y, spawnPlayerPoint.position.z);
    //    var playerObj = Instantiate(playerPrefab, pos, Quaternion.identity);
    //    playerObj.GetComponent<Player>();
    //}

    private void Update()
    {
        /*if (player != null)
        {
            if (player._touched)
            {
                float time = Mathf.Lerp(TimeController.Instance.MinTimeScale, 1, TimeController.Instance.SpeedRestorTime * Time.deltaTime);
                TimeController.Instance.TimeScale = time;
            }
            else
            {
                TimeController.Instance.ResetTime();
            }
        }*/
    }
}