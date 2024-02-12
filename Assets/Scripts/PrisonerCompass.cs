using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonerCompass : MonoBehaviour
{
    public Transform player;
    public Transform prisoner;
    public TMP_Text displayLocation;

  
    void Update()
    {
        int dist = (int)Vector3.Distance(player.transform.position, prisoner.transform.position);
        displayLocation.text = "PRISONER DISTANCE: " + dist.ToString();
    }
}
