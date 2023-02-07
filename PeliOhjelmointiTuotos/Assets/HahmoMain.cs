using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HahmoMain : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody m_hahmoFysiikka;
    Animation HahmoAnimaatiot;
    [SerializeField]
    float m_hahmoHyppyVoimaYlosPain=300f;
     [SerializeField]
    float m_hahmoEteenPainJuoksuVoima=300f;
     [SerializeField]
    float m_hahmoKaantoVoima=10f;
    [SerializeField]
    GameObject m_ammuksenprefab;
    bool unarmed;
    
    
    void Start()
    {
        m_hahmoFysiikka=GetComponent<Rigidbody>();
        HahmoAnimaatiot=GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") )
        {
          
            //ylöspäin voimaa hahmolle vector3.up*500= 0.0.1*500
            m_hahmoFysiikka.AddForce(Vector3.up*m_hahmoHyppyVoimaYlosPain);
        }
        if( Input.GetKeyDown("w") ||    Input.GetKey("w"))
        {
            m_hahmoFysiikka.AddRelativeForce(Vector3.forward*m_hahmoEteenPainJuoksuVoima); 
            HahmoAnimaatiot.Play("Armature|Run.001"); 
           
        }
        if(Input.GetKeyDown("s") || Input.GetKey("s") )
        {
            m_hahmoFysiikka.AddRelativeForce(Vector3.back*m_hahmoEteenPainJuoksuVoima);
        }
        if(Input.GetKeyDown("d") || Input.GetKey("d"))
        {
            m_hahmoFysiikka.AddRelativeTorque(Vector3.up*m_hahmoKaantoVoima);
        }
        if(Input.GetKeyDown("a") || Input.GetKey("a"))
        {
            m_hahmoFysiikka.AddRelativeTorque(Vector3.down*m_hahmoKaantoVoima);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            AmmuAmmus();                                   
        }
        if(  Input.GetKey("e") || Input.GetKeyDown("e") )
        {   
            OlalleVie();   
        }
        

        
    }
    //animaatiot jos haluaa toimimaan if(Input.GetKeyDown("space")-->void hyppy--> voidissa hyppy ominaisuudet + play animation.. sama muille liikkeile
    //input GetKeyDown w --> void eteenoäinliike-->etenemisen määrittely + play animation run
    //}
    public void AmmuAmmus()
    {   if (!unarmed)  {
        GameObject ammuksenStarttipaikka=GameObject.Find("AmmuksenLahtoPaikka");
        GameObject ammus=Instantiate(m_ammuksenprefab);//GameObject.Find("Ammus");
        ammus.transform.position= ammuksenStarttipaikka.transform.position;
        Rigidbody ammuksenFysiikka=ammus.GetComponent<Rigidbody>();
        ammuksenFysiikka.velocity=Vector3.zero;
        ammuksenFysiikka.AddForce(ammuksenStarttipaikka.transform.forward*1500f);
        }
        else{return;}
    }

    public void OlalleVie()
    {
          if (!unarmed)
            {
               GameObject haulikko=GameObject.Find("haulikko");
               GameObject haulikkoSelassa=GameObject.Find("AseSelassa");
              haulikko.transform.position=haulikkoSelassa.transform.position;
               haulikko.transform.rotation=haulikkoSelassa.transform.rotation;
               unarmed=true;
            }
        
            else
            {   
           GameObject haulikko=GameObject.Find("haulikko");
           GameObject haulikkoKadessa=GameObject.Find("AseKadessa");
           HahmoAnimaatiot.Play("Armature|Action");
            haulikko.transform.position=haulikkoKadessa.transform.position;
            haulikko.transform.rotation=haulikkoKadessa.transform.rotation;
            unarmed=false;
            }
    }
}
