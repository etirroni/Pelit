using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KarhuLiike : MonoBehaviour
{
    Animator m_karhunAnimaatiot;
    NavMeshAgent m_karhunPolunetsinta;  
       void Start()
    {
        m_karhunAnimaatiot=GetComponent<Animator>();
        m_karhunPolunetsinta=GetComponent<UnityEngine.AI.NavMeshAgent>();

        GameObject target=GameObject.FindWithTag("Player");
        m_karhunPolunetsinta.destination=target.transform.position;
    }
       void Update()
    {   //tähän sight ja attack rangen tarkkailu
        
    }

    void OnCollisionEnter(Collision osumainfo)
    {
        Debug.Log("Karhuun osui"+osumainfo.gameObject.name);
        if(osumainfo.gameObject.name.Contains("Ammus"));
        {
            m_karhunAnimaatiot.SetTrigger("KarhuunOsuiAmmus");
        }
    }
  
}
