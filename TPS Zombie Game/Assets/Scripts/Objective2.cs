using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective2 : MonoBehaviour
{
    public static ObjectiveComplete occurrence;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //complete objective
            ObjectiveComplete.occurrence.GetObjectivesDone(true, true, false, false);

            Destroy(gameObject, 2f);
        }
    }
}
