using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectWithTrigger : MonoBehaviour
{
    public GameObject ObjectActiveWhenInsideTrigger;
    public GameObject ObjectActiveWhenOutsideTrigger;

    private void OnTriggerEnter(Collider other)
    {
        ObjectActiveWhenInsideTrigger.SetActive(true);
        ObjectActiveWhenOutsideTrigger.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectActiveWhenInsideTrigger.SetActive(false);
        ObjectActiveWhenOutsideTrigger.SetActive(true);
    }
}
