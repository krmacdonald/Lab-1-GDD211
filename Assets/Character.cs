using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Character : MonoBehaviour
{
    public CharacterController charControl;

    private float verticalMove;
    private float horizontalMove;
    private float randomX;
    private float randomZ;

    public float score;
    public float speed;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private float timer;
    public Animator animatorManager;
    private Vector3 moveDirection;
    private AnimatorClipInfo[] currentClip;
    void Start()
    {
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        currentClip = animatorManager.GetCurrentAnimatorClipInfo(0);

        if (timer > 0)
        {
            if (currentClip[0].clip.name == "Punching")
            {
                animatorManager.SetFloat("Collected", 0);
            }


            if (horizontalMove != 0 || verticalMove != 0)
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
            timer -= Time.deltaTime;
            timerText.text = "TIME: " + Mathf.RoundToInt(timer).ToString();
        }
        else
        {
            timerText.text = "TIME'S UP!";
        }
    }

    void OnTriggerEnter(Collider thing)
    {
        if(thing.gameObject.tag == "Collectable")
        {
            animatorManager.SetFloat("Collected", 1);
            Debug.Log("Moving");
            randomX = Random.Range(-4f, 4f);
            randomZ = Random.Range(-4f, 5f);
            thing.gameObject.transform.position = new Vector3(randomX, 2f, randomZ);
            score += 1;
            scoreText.text = "SCORE: " + score.ToString();
        }
    }
}
