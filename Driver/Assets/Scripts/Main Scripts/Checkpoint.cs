using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    public static Checkpoint instance;
    public int checkPointCount;
    public Collider objCollider;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       // Collider objCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            checkPointCount++;
            Debug.Log("Kontrol: " + checkPointCount);
            gm.lastCheckPointPos = transform.position;
            Invoke("CheckPointCollider", 5f);
        }
    }
    public void CheckPointCollider()
    {
        objCollider.isTrigger = false;
    }
}
