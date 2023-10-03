using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Objective2 : MonoBehaviour
{
    public ObjectiveComplete mission;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //complete objective
            mission.obj2 = true;
            mission.GetObjectivesDone(true, true, false, false);

            Destroy(gameObject, 2f);
        }
    }
}
