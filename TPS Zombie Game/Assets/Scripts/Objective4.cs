using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective4 : MonoBehaviour
{
    public ObjectiveComplete mission;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vehicle")
        {
            //complete objective
            mission.obj4 = true;
            mission.GetObjectivesDone(true, true, true, true);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
