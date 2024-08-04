using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
        
    }

    IEnumerator CountdownToStart(){
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "GO!";

        //TruckController.instance.Move();

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }
}
