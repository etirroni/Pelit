using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmuksenAivot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine("TuhoaAmmus"); 
    }

    // Update is called once per frame
    IEnumerator TuhoaAmmus()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Ammus Tuhottu");
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        Debug.Log("Ammus osui" + collisioninfo.gameObject.name);
    }
}
