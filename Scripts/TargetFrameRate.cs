using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    [SerializeField]
    int vSyncState;
    [SerializeField]
    int frameRate;
    
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = vSyncState;
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
