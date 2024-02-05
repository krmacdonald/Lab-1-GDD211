using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterController charControl;
    private float verticalMove;
    private float horizontalMove;
    public float speed;
    public Animator animatorManager;
    private Vector3 moveDirection;
    private AnimatorClipInfo[] currentClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        currentClip = animatorManager.GetCurrentAnimatorClipInfo(0);

        if (currentClip[0].clip.name == "Punching")
        {
            animatorManager.SetFloat("Collected", 0);
        }

       
        if(horizontalMove != 0 || verticalMove != 0)
        {
            animatorManager.SetFloat("Speed", 1);
        }
        else
        {
            animatorManager.SetFloat("Speed", 0);
        }

        moveDirection = new Vector3((horizontalMove * speed * Time.deltaTime), 0, (verticalMove * speed * Time.deltaTime));
        charControl.Move(moveDirection);
        if (moveDirection != new Vector3(0, 0, 0))
        {
            this.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    void OnTriggerEnter(Collider thing)
    {
        if(thing.gameObject.tag == "Collectable")
        {
            animatorManager.SetFloat("Collected", 1);
            Debug.Log("DID");
        }
    }
}
