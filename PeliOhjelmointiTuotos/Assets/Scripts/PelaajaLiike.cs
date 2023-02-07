using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajaLiike : MonoBehaviour
{
    Vector3 pelaajanmaanvetovoima;
    CharacterController pelaajakontrolleri;
    Animation pelaajaanimaatiot;
    float maanvetovoima=-9.81f;
    float hyppyvoima=8.0f;
    bool pelaajaonmaassa;
    public float speed;
    private float ySpeed;
    public float rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        pelaajakontrolleri=GetComponent<CharacterController>();
       // float correctHeight=pelaajakontrolleri.center.y + pelaajakontrolleri.skinWidth;
        //pelaajakontrolleri.center = new Vector3(0, correctHeight, 0);
        pelaajaanimaatiot=GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float eteenpäinliike=Input.GetAxis("Vertical");
        float sivuttaisliike=Input.GetAxis("Horizontal");
        pelaajaonmaassa=pelaajakontrolleri.isGrounded;
        Vector3 movementDirection=new Vector3(0,0,eteenpäinliike);
        transform.Rotate(0f, sivuttaisliike, 0f);     
        float magnitude=Mathf.Clamp01(movementDirection.magnitude)*speed;
        movementDirection.Normalize();
        transform.Translate(movementDirection*speed*Time.deltaTime);
        ySpeed+=Physics.gravity.y*Time.deltaTime;
        pelaajakontrolleri.Move(transform.forward*0.01f*eteenpäinliike);

        //if(movementDirection != Vector3.zero)
          //  {
            //    Quaternion toRotation= Quaternion.LookRotation(movementDirection, Vector3.up);
              //  transform.rotation=Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);
          //  }   
        if(pelaajaonmaassa && pelaajanmaanvetovoima.y < 0)
            {
                pelaajanmaanvetovoima.y=0f;
            }
        if (!pelaajaonmaassa)
            {
                pelaajaanimaatiot.Play("Armature|Action");
            }
        //float eteenpäinliike=Input.GetAxis("Vertical");
        if(eteenpäinliike==0f  && sivuttaisliike==0f )
            {
                pelaajaanimaatiot.Play("Armature|Idle.001");
            }
        else
            {
                pelaajaanimaatiot.Play("Armature|Run.001");        
            }
       // transform.position = transform.position+transform.forward*0.01f*eteenpäinliike;
       // pelaajakontrolleri.Move( transform.forward*0.01f*eteenpäinliike );
        if(pelaajakontrolleri.isGrounded)
        {
            ySpeed=0f;
            if(Input.GetButtonDown("Jump") )//&& pelaajaonmaassa)
            {
           //pelaajanmaanvetovoima.y =pelaajanmaanvetovoima.y +Mathf.Sqrt( hyppyvoima * -3.0f * maanvetovoima );
            ySpeed=hyppyvoima;
            }
        }
        Vector3 velocity=movementDirection*magnitude;
        velocity.y=ySpeed;
        pelaajakontrolleri.Move(velocity*Time.deltaTime);
      
        
        
        pelaajanmaanvetovoima.y +=maanvetovoima*Time.deltaTime;
        pelaajakontrolleri.Move(pelaajanmaanvetovoima*Time.deltaTime);
        
    }
}
