using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManger : MonoBehaviour
{
    public static NetworkManger instance;

    public GameObject prefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("存在Client实例，删除多余单例");
            Destroy(this);
        }
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
#if UNITY_EDITOR
        Debug.Log("build the project to start the server!");
#else
        Server.Start(50,26950);
#endif
    }

    public Player InstantiatePlayer()
    {
        return Instantiate(prefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
    }
}
