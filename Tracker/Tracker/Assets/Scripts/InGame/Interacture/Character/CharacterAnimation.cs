using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Rigidbody2D rigid;

    public Animator animator;

    private bool freeMoving = false;
    private bool downMoving = false;
    public bool fakeColor;

    public SpriteRenderer spriteColor;
    Color[] color = new Color[5] { Color.red, Color.yellow, new Color(255, 190, 0), new Color(60, 255, 0), new Color(165, 0, 155) };

    private Vector3 prevVec;

    private bool frontStanding = false;

    private bool flip = false;
    private void Start()
    {
        prevVec = gameObject.transform.position;
        if (fakeColor)
        {
            int randomColor = Random.Range(1, 5);
            spriteColor.color = color[randomColor];
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (prevVec != gameObject.transform.position)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("FrontStanding", false);
            animator.SetBool("Standing", false);
            prevVec = gameObject.transform.position;
        }
        else 
        {   
            animator.SetBool("Standing", true);
            animator.SetBool("Walking", false);
        }

        if(freeMoving)
        {
            RandomMoving();
        }

        if(downMoving)
        {
            downMoving = false;
            gameObject.transform.DOMove(gameObject.transform.position + new Vector3(Random.Range(3, 80), Random.Range(-80, -10)), 10);
        }

        if(frontStanding)
        {
            frontStanding = false;
            animator.SetBool("FrontStanding", true);
            animator.SetBool("Walking", false);
        }
    }

    private void RandomMoving()
    {
        int randomMoving = Random.Range(1, 3);
        if (randomMoving == 1)
        {
            if(flip)
            {
                flip = false;
                spriteColor.flipX = false;
            }
            freeMoving = false;
            gameObject.transform.DOMove(gameObject.transform.position + Vector3.right * 5, 10);
            Invoke("StopMoving", 10);
        }
        else if (randomMoving == 2)
        {
            if (flip == false)
            {
                flip = true;
                spriteColor.flipX = true;
            }
            freeMoving = false;
            gameObject.transform.DOMove(gameObject.transform.position - Vector3.right * 5, 10);
            Invoke("StopMoving", 10);
        }
    }

    private void StopMoving()
    {
        freeMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameManager"))
        {
            frontStanding = true;
        }
        if(collision.CompareTag("OnField"))
        {
            downMoving = true;
            Invoke("StopMoving", 10);
        }
    }
}
