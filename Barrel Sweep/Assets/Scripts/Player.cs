using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Animator anim;
    public GameObject player;
    public Enemy enemy;
    public int health = 3;
    public int TimeLeft = 60;
        
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
        if (Input.GetKeyDown(KeyCode.Z))
            anim.SetTrigger("BS3");
        if (Input.GetKeyDown(KeyCode.X))
            anim.SetTrigger("BS4");
    }

    //channeling/stationary while holding, see field that can blink to, teleport to location of mouse direction on button release
	public void Blink()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("Blink");
           
    }

    // collect gems to increase time and kill enemies with animations or take damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            // collect and detroy gameobject adding 10 seconds to timeleft counter
            Debug.Log(other.name);
        }


        if (other.CompareTag("Enemy"))
        {
            //animations for Q,E,Z,X kill enemies
            //otherwise deal 1 point damage to player health per second
            Debug.Log("ENEMIES!!!!!");
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
