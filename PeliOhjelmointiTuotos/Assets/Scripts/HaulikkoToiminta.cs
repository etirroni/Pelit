using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaulikkoToiminta : MonoBehaviour
{
    //[SerializeField]
    // GameObject m_kohde;
    // Start is called before the first frame update



    void Start()
    {
       // m=GameObject.Find("Hahmo2");
       // pyssy =GameObject.Find("haulikko");
       Debug.Log("aukaseeko tämä vittu ees tätä scriptiä");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onCollisionEnter(Collision collisioninfo)
    
    {
     Debug.Log("Haulikkoon osui"+collisioninfo.gameObject.name);
       
       // if(other.gameObject.CompareTag("Player"))
      //  {
        
      //  Debug.Log("Onnistui" );
      //  }   
    }
}
