using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildPlace : MonoBehaviour {
    public bool isBuildplace;
    // The Tower that should be built
    public GameObject towerPrefab;
    private void Start()
    {
        isBuildplace = Random.value < 0.10;
    }
    void OnMouseDown()
    {
        if (isBuildplace)
        {
            // Build Tower above Buildplace
            GameObject g = (GameObject)Instantiate(towerPrefab);
            g.transform.position = transform.position + Vector3.up;
        }
    }
 

}
