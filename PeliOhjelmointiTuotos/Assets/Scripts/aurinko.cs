 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class aurinko : MonoBehaviour
 {
     public float maxRange = 11f;
     public float minRange = 6f;
     public float flickerSpeed = 0.1f;
 
     private Light lightSource;
 
    void Start()
     {
         lightSource = GetComponent<Light>();
     }
 
     void Update()
     { 
        lightSource.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, flickerSpeed));


     }
 }