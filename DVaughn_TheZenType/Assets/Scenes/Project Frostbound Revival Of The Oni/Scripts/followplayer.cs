using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 4, -12);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = player.transform.position + offset;
    }
}
