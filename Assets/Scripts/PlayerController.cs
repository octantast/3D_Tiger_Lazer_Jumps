using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GeneralController general;   
    public Animator animator;
    public Vector2 touchPos;
    public Vector2 swipeStartPos;
    public bool blocked;
    public bool touchbegan;
    public bool touchcontinues;

    private bool jumped;
    private bool blockdone;


    private float holdingSens;
    public float holdingSensTimer;

    public float swipeSensitivity;

    private Vector3 startPos;
    private Vector3 currentRotation;

    private bool tutordone;

    private void Start()
    {
        currentRotation = animator.gameObject.transform.eulerAngles;
        startPos = animator.gameObject.transform.localPosition;
    }


    // touch input
    public void Update()
    {
        if (!general.paused)
        {
            touchInput();
        }

        animator.gameObject.transform.rotation = Quaternion.Euler(currentRotation);

    }
    public void touchInput()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchPos = Input.mousePosition;
                swipeStartPos = touchPos;
                startTouch();
            }
            if (Input.GetMouseButton(0))
            {
                touchPos = Input.mousePosition;
                continueTouch();
            }
            if (Input.GetMouseButtonUp(0))
            {
                endTouch();
            }

        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    touchPos = touch.position;
                    swipeStartPos = touchPos;
                    startTouch();
                    break;
                case TouchPhase.Moved:
                    touchPos = touch.position;
                    continueTouch();
                    break;
                case TouchPhase.Ended:
                    endTouch();

                    break;

            }
        }
    }

    public void startTouch()
    {
        if (!general.paused )
        {
            if (blocked)
            {
                blocked = false;
            }
            else
            {
                touchbegan = true;
                touchcontinues = false;
                resetValues();
            }
        }

    }
    public void continueTouch()
    {
        if (!general.paused && !blocked)
        {
            touchbegan = false;
            touchcontinues = true;

            float swipeDelta = touchPos.y - swipeStartPos.y;

            if (!jumped && !blockdone)
            {
                if (swipeDelta > swipeSensitivity && !jumped)
                {
                    animator.gameObject.transform.localPosition = Vector3.zero;
                    jumped = true;
                    general.ui.sounds[2].Play();
                    animator.Play("Jump");
                    tutorialcheck();
                }
                else
                {
                    if (jumped && animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                    {

                    }
                    else if (!blockdone && !animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
                    {
                        if (holdingSens < holdingSensTimer)
                        {
                            holdingSens += Time.deltaTime;
                        }
                        else
                        {
                            animator.gameObject.transform.localPosition = Vector3.zero;
                            blockdone = true;
                            // block = true;

                            if (general.turel.currentImpulse > 0)
                            {
                                animator.gameObject.transform.localPosition = Vector3.zero;
                                animator.Play("BlockMiror");
                            }
                            else
                            {
                                animator.gameObject.transform.localPosition = Vector3.zero;
                                animator.Play("Block");
                            }
                            tutorialcheck();
                        }
                    }
                }
            }
        }
    }

    public void tutorialcheck()
    {
        if (general.ui.tutorial1 == 0)
        {
            general.ui.tutorial1 = 1;
            PlayerPrefs.SetInt("tutorial1", 1);
            PlayerPrefs.Save();
            general.ui.tipAnimator.Play("Start2");
            general.ui.tipAnimator.enabled = true;
        }
    }
    public void tutorialcheck2()
    {
        if (general.ui.tutorial2 == 0)
        {
            general.ui.tutorial2 = 1;
            PlayerPrefs.SetInt("tutorial2", 1);
            PlayerPrefs.Save();
            general.ui.tipAnimator.gameObject.SetActive(false);
            general.ui.tipAnimator.enabled = false;
        }
    }

    public void endTouch()
    {
        if (!general.paused)
        {
            if (!blocked)
            {
                touchbegan = false;
                touchcontinues = false;

            }
            resetValues();
        }
    }

    private void resetValues()
    {
        blockdone = false;
        jumped = false;
        holdingSens = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lazer"))
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("BlockMiror") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Block") && !general.ui.a2active)
            {
               // animator.gameObject.transform.localPosition = Vector3.zero;
               
                animator.Play("Hit");
                general.ui.hpLost();
                general.ui.sounds[3].Play();
            }
            else
            {
                if (!tutordone)
                {
                    tutordone = true;
                }
                else
                {
                    tutorialcheck2();
                }
                general.ui.sounds[6].Play();
            }
        }
    }

}
