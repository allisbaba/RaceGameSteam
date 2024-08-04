using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapController : MonoBehaviour
{
    public int lapCount = 0;
    public GameObject rampBarrier;
    public GameObject roadBarrier;
    public TextMeshProUGUI lapDisplay;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
       
            lapCount++;
            lapDisplay.text = lapCount.ToString();
            Debug.Log("Tur say�n�z :" + lapCount);
            Checkpoint.instance.objCollider.isTrigger=true;
            Debug.Log("Instance �al��t�");
            
            if (lapCount == 3)
            {
                Debug.Log("rampbariyer kalkt�");
                rampBarrier.SetActive(false);
                Debug.Log("Rampa Aktif");
                roadBarrier.SetActive(true);
            }

        }
    }

   
}
