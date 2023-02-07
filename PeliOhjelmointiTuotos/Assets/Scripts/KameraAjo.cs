using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraAjo : MonoBehaviour
{
    [SerializeField]
    GameObject m_kohde;
    // Start is called before the first frame update
     [SerializeField]
      float etaisyys=10f;

     [SerializeField]
     float korkeus=3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_kohde.transform);

        Vector3 loppuPositio=transform.position=m_kohde.transform.position-(m_kohde.transform.forward*etaisyys)+ (m_kohde.transform.up*korkeus);

        transform.position=Vector3.Lerp(transform.position, loppuPositio, 1f);//Ei pelitä jostaki syystä ollenkaan
    }
}
