using UnityEngine;
public class FrameCounter : MonoBehaviour
{
    private long frameCounter;
    private float FPS;
    void Start()
    {
        Debug.Log("Started!");
        frameCounter = 0;
    }
    void Update()
    {
        ++frameCounter;
       if(frameCounter % 100 == 0) {
           
            Debug.Log("FPS: " + FPS.ToString()); 
        }
        
    }
}