using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public GeneralController general;
    public Animator animator;

    public float thisHP;

    public float reactionalTimerMax;

    private int randomreaction;
    private Vector3 startPos;
    private Vector3 currentRotation;
    public int jumppossibility;
    public int hitpossibility;

    public string currentAnimation;

    public bool mirorispossible;

    private bool firstpunchcantbe;

    private void Start()
    {
        currentRotation = animator.gameObject.transform.eulerAngles;
        startPos = animator.gameObject.transform.localPosition;
    }
    private void Update()
    {
        if (!general.paused)
        {
            animator.gameObject.transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
    public void hitreaction()
    {
        animator.gameObject.transform.localPosition = Vector3.zero;
        //reactionalTimer = reactionalTimerMax;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.Play("Hit");
        }
        thisHP -= 1;
        general.ui.sounds[3].Play();

    }

    public void OnCollisionEnter(Collision collision) // hit
    {        
        if (collision.gameObject.CompareTag("Lazer"))
        {
            if (!mirorispossible)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Block")) //reactionalTimer > 0 && 
                {
                    hitreaction();
                }
                else
                {
                    general.ui.sounds[6].Play();
                }
            }
            else
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Block") && !animator.GetCurrentAnimatorStateInfo(0).IsName("BlockMirror")) //reactionalTimer > 0 && 
                {
                    hitreaction();
                }
                else
                {
                    general.ui.sounds[6].Play();
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // predicts reaction
        if (other.gameObject.CompareTag("Lazer"))
        {
            if (!general.ui.sounds[2].isPlaying)
            {
                animator.gameObject.transform.localPosition = Vector3.zero;
            }
                  
                   randomreaction = Random.Range(0, 100);
                // jump
                if (randomreaction < jumppossibility || !firstpunchcantbe)
                {
                if(!firstpunchcantbe)
                {
                    firstpunchcantbe = true;
                }
                general.ui.sounds[2].Play();
                animator.Play("Jump");
                }
                // or block
                else if (randomreaction < (100 - hitpossibility))
            {
                if (mirorispossible)
                {
                    if (general.turel.currentImpulse > 0)
                    {
                        animator.Play("Block");
                    }
                    else
                    {
                        // mirrored
                        animator.Play("BlockMirror");
                    }
                }
                else
                {
                    animator.Play("Block");
                }
                }
           
        }
    }

}
