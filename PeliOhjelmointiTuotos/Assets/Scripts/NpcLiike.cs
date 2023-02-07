using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLiike : MonoBehaviour
{
    public float movSpeed;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotL = false;
    private bool isRotR = false;
    private bool isWalking = false;

    Rigidbody rb;
    Animation poroanimaatiot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        poroanimaatiot=GetComponent<Animation>();
    }
    private void Update()
    {
        if (isWandering == false)
        {
           // poroanimaatiot.Play("Idle Loop ");
            StartCoroutine(Wander());
        }
        if (isRotR == true)
        {   
           // poroanimaatiot.Play("Idle Loop ");
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotL == true)
        {   
          //  poroanimaatiot.Play("Idle Loop ");
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            poroanimaatiot.Play("Sprint Loop");
            rb.transform.position += transform.forward * movSpeed;            
        }
         if (isWalking == false)
         {
             poroanimaatiot.Play("Idle Loop");
         }
    }
    IEnumerator Wander()
    {
        int rottime = Random.Range(1, 3);
        int rotwait = Random.Range(1, 3);
        int rotatelorR = Random.Range(1, 3);
        int walkwait = Random.Range(1, 3);
        int walktime = Random.Range(1, 10);


        isWandering = true;

        yield return new WaitForSeconds(walkwait);
        isWalking = true;
        yield return new WaitForSeconds(walktime);
        isWalking = false;
        yield return new WaitForSeconds(rotwait);
        if (rotatelorR == 1)
        {
            isRotR = true;
            yield return new WaitForSeconds(rottime);
            isRotR = false;
        }
        if (rotatelorR == 2)
        {
            isRotL = true;
            yield return new WaitForSeconds(rottime);
            isRotL = false;
        }
        isWandering = false;
    }
}