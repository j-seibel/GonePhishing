using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidcontroller : MonoBehaviour {
    float horizontal;
    float vertical;

    private float speed = 3f;

    Animator animator;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        transform.position = position;
        rigidbody2d.MovePosition(position);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        animator.SetFloat("movex", horizontal);
        animator.SetFloat("movey", vertical);
        if(Input.GetKeyDown(KeyCode.X)){
               RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, Vector2.up, 1.5f, LayerMask.GetMask("NPC")); 
               if(hit.collider != null){
                  Debug.Log(hit.collider.gameObject);
                  PhishIntro npc = hit.collider.GetComponent<PhishIntro>();
                  DogeInteraction doge = hit.collider.GetComponent<DogeInteraction>();
                  ParticleSystem printer = hit.collider.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
                  FirstGma npc2 = hit.collider.GetComponent<FirstGma>();
                  if(npc != null){
                      npc.DisplayDialogue();
                  }
                  if(doge != null){
                      doge.DisplayDialogue();
                  }
                  if(printer != null){
                      printer.Stop();
                  }
                  if(npc2 != null){
                      npc2.DisplayDialogue();
                  }
               }
           }
        
    }
}
