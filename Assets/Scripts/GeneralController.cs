using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GeneralController : MonoBehaviour
{
    public List<AnimalController> animals;
    public PlayerController player;
    public UI ui;

    public GameObject shield;

    public TurelController turel;

    public bool paused;

    public float hp1platform; // monkey
    public float hp2platform; // bear
    public float hp3platform; // panther

    public TMP_Text hp1;
    public TMP_Text hp2;
    public TMP_Text hp3;

    public GameObject monkeyPlatform;
    public GameObject bearPlatform;
    public GameObject panteraPlatform;

    // effects
    public List<ParticleSystem> effects;
  
    public void Update()
    {
        if (monkeyPlatform.activeSelf && animals[0].thisHP > 0)
        {
            hp1.text = animals[0].thisHP.ToString("0");
        }
        else if(monkeyPlatform.activeSelf && animals[0].thisHP <= 0)
        {
            ui.sounds[5].Play();
            hp1.text = "";
            ParticleSystem newParticleSystem = Instantiate(effects[1], monkeyPlatform.transform.position, Quaternion.identity);
            monkeyPlatform.SetActive(false);
        }
        else
        {
            animals[0].animator.enabled = false;
        }
        if (bearPlatform.activeSelf && animals[1].thisHP > 0)
        {
            hp2.text = animals[1].thisHP.ToString("0");
        }
        else if (bearPlatform.activeSelf && animals[1].thisHP <= 0)
        {
            ui.sounds[5].Play();
            hp2.text = "";
            ParticleSystem newParticleSystem = Instantiate(effects[1], bearPlatform.transform.position, Quaternion.identity);
            bearPlatform.SetActive(false);
        }
        else
        {
            animals[1].animator.enabled = false;
        }

        if (panteraPlatform.activeSelf && animals[2].thisHP > 0)
        {
            hp3.text = animals[2].thisHP.ToString("0");
        }
        else if (panteraPlatform.activeSelf && animals[2].thisHP <= 0)
        {
            ui.sounds[5].Play();
            hp3.text = "";
            ParticleSystem newParticleSystem = Instantiate(effects[1], panteraPlatform.transform.position, Quaternion.identity);
            panteraPlatform.SetActive(false);
        }
        else
        {
            animals[2].animator.enabled = false;
        }

        if (!paused)
        {
            if (ui.a2timer > 0)
            {
                ui.a2timer -= Time.deltaTime;
                ui.a2activeskale.fillAmount = ui.a2timer / ui.a2timerMax;
            }
            else if (ui.a2active)
            {
                ui.a2activeskale.fillAmount = 0;
                ui.a2active = false;
                shield.SetActive(false);

            }
        }
    }

    

}
