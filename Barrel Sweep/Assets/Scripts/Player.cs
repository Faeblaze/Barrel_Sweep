using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    private Animator anim;
    public GameObject player;
    public Enemy enemy;
        
    public float tweenSpeed = 2f;
    
   

    private void Start()
    {
        anim = GetComponent<Animator>();
     
    }

    private void Update()
    {
        Movement();
        BarrelSweep();
        Blink();

    }

    // moving only w,a,d, forward left and right- constant movement while holding down button 
    //Adding S because on gameplay aspects, can remove later

    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
           transform.Translate(Vector3.up * Time.deltaTime * 10f);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * 10f);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * 10f);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * Time.deltaTime * 10f);
    }

    // faster movement  in sweep spiral direction. Deals damage to enemies, also allows you to go over walls
    public void BarrelSweep()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            anim.SetTrigger("BarrelSweep01");
        if (Input.GetKeyDown(KeyCode.E)) 
            anim.SetTrigger("BarrelSweep");
    }

    //channeling/stationary while holding, see field that can blink to, teleport to location of mouse direction on button release
	public void Blink()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("Blink");
           
    }

    

}
