using UnityEngine;
using System.Collections;

public class hill : MonoBehaviour
{

    public Transform Player;
    public Transform hill1Transform;
    public Transform hill2Transform;
    public Transform grass;

    public float timer = 0;
    public float timer1 = 0;

    public bool hill1Move;
    public bool hill2Move;
    //public bool timerTrue;
    //public bool timer1True;
    public bool canTransform;
    public bool canTransform1;

    int hill1frames;
    int hill2frames; 

    void Start()
    {
        //hill1Move = true;
        //hill2Move = false;
    }

    void Update() { 
    

        if (timer == 1 && canTransform) {
            Vector3 increase = new Vector3(178, 206, 0);
            hill2Transform.transform.position += increase;
            Debug.Log("hill 1 move");
            hill2Move = true;
            hill1Move = false;
            canTransform = false;
            //timer = 0;
        }
        if (timer > 2)
        {
            timer = 0;
            //timerTrue = false;
        }
        if (timer1 == 1 && canTransform1)
        {
            Vector3 increase2 = new Vector3(-178, -206, 0);
            hill1Transform.transform.position += increase2;
            Debug.Log("hill 2 move");
            hill1Move = true;
            hill2Move = false;
            timer1 = 0;
            canTransform1 = false;
        }
        if (timer1 > 2)
        {
            timer1 = 0;
            //timer1True = false;
        }

       // grass.transform.position += increase;

        if (!hill1Move && !hill2Move)
        {
            hill1Move = true;
        }
        if (Player.position.x > hill1Transform.position.x + 15) {
            //hill1Move = false;
            if (hill1Move)
            {
                //Vector3 increase = new Vector3(-10, -60, 0);
                hill1frames += 1;
                Debug.Log("hill 1 frames = " + hill1frames);
                //timerTrue = true;
                canTransform = true;
                if (canTransform)
                {
                    timer += Time.deltaTime;
                }
            }
            //if (timerTrue) 
                 //timer += Time.deltaTime;
            //startCoroutine(hill1Coroutine());
        }
        if (Player.position.x > hill2Transform.position.x + 15)
        {    
            if (hill2Move)
            {
                hill2frames += 1;
                Debug.Log("hill 2 frames = " + hill2frames);
                //timer1True = true; 
                canTransform1 = true;
                if (canTransform1)
                {
                    timer1 += Time.deltaTime;
                }
            }
            //if (timer1True)
                //timer1 += Time.deltaTime;
        }

     /* IEnumerator hill1Coroutine()
       {
          StopCoroutine(hill1Coroutine());
       }*/
    }
}
