using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject barrier;

    public int artifacts = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (artifacts >=13)
        {
            Destroy(barrier);
        }
    }
    public void AddArtifact()
    {
        artifacts++;

    }
}
