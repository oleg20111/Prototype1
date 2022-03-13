using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloewPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,11,-10);
    
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
