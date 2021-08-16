using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuAstronaut : MonoBehaviour
{
    public float move;
    public bool left, right;
    public Animator animator;

    private void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(move,0,0) * Time.deltaTime;
        if (transform.position.x >= 470 && !right)
        {
            move = 0;
            animator.SetBool("Stop", true);
            left = true;
        }
        if (left == true)
        {
            StartCoroutine(Left());
        }
        StartCoroutine(LeftRun());
        left = false;
        if (transform.position.x <= -270 && !left)
        {
            move = 0;
            animator.SetBool("Stop", true);
            right = true;
        }
        if (right == true)
        {
            StartCoroutine(Right());
        }
        StartCoroutine(RightRun());
        right = false;
    }
    private IEnumerator LeftRun()
    {
        while (left)
        {
            yield return new WaitForSeconds(4);
            move = -100;
            animator.SetBool("Stop", false);
        }
    }
    private IEnumerator RightRun()
    {
        while (right)
        {
            yield return new WaitForSeconds(4);
            move = 100;
            animator.SetBool("Stop", false);
        }
    }
    private IEnumerator Left()
    {
        while (left)
        {
            yield return new WaitForSeconds(2);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } 
    }
    private IEnumerator Right()
    {
        while (right)
        {
            yield return new WaitForSeconds(2);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
