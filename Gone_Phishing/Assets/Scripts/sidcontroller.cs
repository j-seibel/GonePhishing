using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidcontroller : MonoBehaviour {
    float horizontal;
    float vertical;

    private float speed = 5;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0) {
            
            position.x += speed * horizontal * Time.deltaTime; 
        }
        animator.SetFloat("movex", horizontal);
        if (vertical != 0) {
            
            position.y += speed * vertical * Time.deltaTime; 
        }
        animator.SetFloat("movey", vertical);
        transform.position = position;
    }
}
