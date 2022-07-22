using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] CrashDetector crashDetector;
    float torqueAmount=3f;
    [SerializeField] float boostSpeed=25f;
    [SerializeField] float baseSpeed=15f;
    [SerializeField] float crashedSpeed=2f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();
        crashDetector=GetComponent<CrashDetector>();
        rb2d.drag=0.5f;
        rb2d.angularDrag=5f;
        rb2d.gravityScale=1.5f;
        torqueAmount=3f;
        crashDetector.crashed=false;
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.D)&&crashDetector.crashed==false)
        {
            rb2d.AddTorque(-torqueAmount);
        }
        else if (Input.GetKey(KeyCode.A)&&crashDetector.crashed==false)
        {
            rb2d.AddTorque(torqueAmount);
        }
    }
    void RespondToBoost(){
        if (crashDetector.crashed==true){
            surfaceEffector2D.speed=crashedSpeed;
        }
        else if (Input.GetKey(KeyCode.W)){
            surfaceEffector2D.speed=boostSpeed;
        }
        else {
            surfaceEffector2D.speed=baseSpeed;
        }
    }
}
