 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float vanToc;
    private float Speed = 5f;
    private bool chuyenHuong = false;
    private bool huongQuay = true;
    public float nhay;
    public float delayDie= 2f;
    private bool Ground = true;
    private bool water = true;
    private Animator animatorPlayer;
    private Rigidbody2D rigidbody2D;
  
    public AudioSource audio;
    public AudioClip audioDie;
    public GameObject die;

    public GameObject pauseUI;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        animatorPlayer.SetFloat("Speed", Speed);
        animatorPlayer.SetBool("Ground", Ground);
  
        Nhay();
       
       

    
}
   
    private void FixedUpdate()
    {
        Dichuyen();

    
    }

  

  public void Dichuyen()
    {
      
        float phaiTrai = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(vanToc * phaiTrai, rigidbody2D.velocity.y);
        Speed = Mathf.Abs(vanToc * phaiTrai);
        float d = Input.GetAxis("Vertical");
        if (phaiTrai > 0 && !huongQuay) Huongquay();
        if (phaiTrai < 0 && huongQuay) Huongquay();
        
    }
    void Huongquay()
    {
        huongQuay = !huongQuay;
        transform.Rotate(0f, 180f, 0f);
        
    }
    void Nhay()
    {

        if (Input.GetKeyDown(KeyCode.W) && Ground == true)
        {
              Debug.Log("bay lên");
            if (Ground)
                rigidbody2D.AddForce((Vector2.up) * nhay);
            Ground = false;
        }
    }

    public void died()
    {
        // biud lai màn chơi
         if (audio && audioDie)
         {
           audio.PlayOneShot(audioDie);
           //  Destroy(Instantiate(die, transform.position, Quaternion.identity), 1.5f);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           

        }
      
      // Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 1.5f);
    }
    // public void Addhp(int cuuthuong)
    // {
    //     luongmau += cuuthuong;
    // }
    // public void Damage(int dame)
    // {
    //     luongmau -= dame;
      
    // }
    void OnTriggerEnter2D(Collider2D collision) { 
     if (collision.tag == "Ground")
      {
        Ground = false;
       
         }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
          {
        Ground = true;
     
          water = false;
          }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
          if (collision.tag == "Ground")
          {
        Ground = false;
        
          }

    }
}

