using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private AsyncOperation asyncOperation;

    public GeneralController general;

    private float volume;
    public List<AudioSource> sounds;
    
    public int hp;
    public List<Heart> hearts;

    private bool reloadThis;
    private bool reload;
    private float loadingtimer = 3;

    public GameObject volumeOn;
    public GameObject volumeOff;
    public GameObject loadingScreen;
    public GameObject settingScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    private float mode; // unique level
    public int howManyLevelsDone; // real number of last level
    private int levelMax; // how many levels total
    public float chosenLevel; // real number of level

    // all ui
    public int levelreward;
    public TMP_Text levelcoins;
    public int coins;
    public int price1;
    public int price2;
    public TMP_Text price1text;
    public TMP_Text price2text;
    public List<TMP_Text> coinsText;
      
    // skills
    public float a2timer;
    public float a2timerMax;
    public Image a2activeskale;
    public bool a2active;

    // tips
    public Animator tipAnimator;

    public int tutorial1;
    public int tutorial2;
    public int tutorial3;


    public void Start()
    {
        Time.timeScale = 1;
        asyncOperation = SceneManager.LoadSceneAsync("MainMenu");
        asyncOperation.allowSceneActivation = false;

        coins = PlayerPrefs.GetInt("coins");
        mode = PlayerPrefs.GetFloat("mode");
        levelMax = PlayerPrefs.GetInt("levelMax");
        volume = PlayerPrefs.GetFloat("volume");
        chosenLevel = PlayerPrefs.GetFloat("chosenLevel");
        howManyLevelsDone = PlayerPrefs.GetInt("howManyLevelsDone");
       
        tutorial1 = PlayerPrefs.GetInt("tutorial1");
        tutorial2 = PlayerPrefs.GetInt("tutorial2");
        tutorial3 = PlayerPrefs.GetInt("tutorial3");

        a2activeskale.fillAmount = 0;

        sounds[0].Play();
        if (volume == 1)
        {
            Sound(true);
        }
        else
        {
            Sound(false);
        }

        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        settingScreen.SetActive(false);
        loadingScreen.SetActive(false);

        tipAnimator.enabled = false;
        price1text.text = price1.ToString("0");
        price2text.text = price2.ToString("0");


        // levels
        if (mode == 0)
        {
            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 3;
            general.hp2platform = 3;
            general.hp3platform = 3;
            foreach (AnimalController script in general.animals)
            {
                script.jumppossibility -= 10;
                   script.hitpossibility = 35;
            }
        }
        else if (mode == 1)
        {
            general.monkeyPlatform.SetActive(false);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(false);
            general.hp1platform = 0;
            general.hp2platform = 2;
            general.hp3platform = 0;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 25;
            }

        }
        else if (mode == 2)
        {
            general.monkeyPlatform.SetActive(false);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 0;
            general.hp2platform = 1;
            general.hp3platform = 1;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 20;
            }
        }
        else if (mode == 3)
        {

            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 2;
            general.hp2platform = 2;
            general.hp3platform = 2;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 15;
            }
        }
        else if (mode == 4)
        {

            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(false);
            general.panteraPlatform.SetActive(false);
            general.hp1platform =3;
            general.hp2platform = 0;
            general.hp3platform = 0;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }

        }
        else if (mode == 5)
        {

            general.monkeyPlatform.SetActive(false);
            general.bearPlatform.SetActive(false);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 0;
            general.hp2platform = 0;
            general.hp3platform = 5;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }
        }
        else if (mode == 6)
        {


            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 5;
            general.hp2platform = 5;
            general.hp3platform = 5;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }
        }
        else if (mode == 7)
        {

            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(false);
            general.hp1platform = 6;
            general.hp2platform = 6;
            general.hp3platform = 0;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }

        }
        else if (mode == 8)
        {
            
            general.monkeyPlatform.SetActive(false);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 0;
            general.hp2platform = 6;
            general.hp3platform = 6;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }

        }
        else if (mode == 9)
        {
            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(false);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 6;
            general.hp2platform = 0;
            general.hp3platform = 6;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }
        }
        else if (mode == 10)
        {
            general.monkeyPlatform.SetActive(true);
            general.bearPlatform.SetActive(true);
            general.panteraPlatform.SetActive(true);
            general.hp1platform = 6;
            general.hp2platform = 6;
            general.hp3platform = 6;
            foreach (AnimalController script in general.animals)
            {
                script.hitpossibility = 10;
            }
        }

        general.animals[0].thisHP = general.hp1platform;
        general.animals[1].thisHP = general.hp2platform;
        general.animals[2].thisHP = general.hp3platform;

        levelreward = 100;
        levelcoins.text = "+" + levelreward.ToString("0");

        if (tutorial1 == 0)
        {
            tipAnimator.Play("Start");
            tipAnimator.enabled = true;
        }
        else if (tutorial1 != 0 && tutorial3 == 0 && coins >= price1)
        {
            tipAnimator.Play("Bonuses");
            tipAnimator.enabled = true;
        }
        else
        {
            tipAnimator.enabled = false;
        }
    }

   public void hpLost()
    {
        hp -= 1;
        if (hp >= 0)
        {
            hearts[hp].gameObject.SetActive(false);
        }
        if (hp <= 0)
        {
            lose();
        }
    }


    public void win()
    {
        general.turel.rb.isKinematic = true;
        general.paused = true;
        Debug.Log("win");
        winScreen.SetActive(true);
        if (chosenLevel > howManyLevelsDone)
        {
            PlayerPrefs.SetInt("howManyLevelsDone", (int)chosenLevel);
        }

        coins += levelreward;
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.Save();
    }

    public void lose()
    {
       sounds[5].Play();
        general.turel.rb.isKinematic = true;

        general.paused = true;
        loseScreen.SetActive(true);

        PlayerPrefs.Save();
    }

    public void Update()
    {
        if(general.animals[0].thisHP == 0 && general.animals[1].thisHP == 0 && general.animals[2].thisHP == 0 && !winScreen.activeSelf)
        {
            win();
        }

        foreach (TMP_Text text in coinsText)
        {
            text.text = coins.ToString("0");
        }

     

        if (loadingScreen.activeSelf == true)
        {
            foreach (AudioSource audio in sounds)
            {
                audio.volume = 0;
            }

            if (loadingtimer > 0)
            {
                loadingtimer -= Time.deltaTime;
            }
            else
            {
                if (!reload)
                {
                    reload = true;
                    if (reloadThis)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    else
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }
           }
        }
        if (!loadingScreen.activeSelf)
        {
            foreach (AudioSource audio in sounds)
            {
                audio.volume = volume;
            }
        }
    }

    public void ExitMenu()
    {
        Time.timeScale = 1;
        sounds[1].Play();
        general.paused = false;
        loadingScreen.SetActive(true);
    }
    public void reloadScene()
    {
        Time.timeScale = 1;
        sounds[1].Play();
        //general.paused = false;
        reloadThis = true;
        loadingScreen.SetActive(true);
    }
    public void Sound(bool volumeBool)
    {
        if (volumeBool)
        {
            volumeOn.SetActive(true);
            volumeOff.SetActive(false);
            volume = 1;
        }
        else
        {
            volume = 0;
            volumeOn.SetActive(false);
            volumeOff.SetActive(true);
        }

        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void closeIt()
    {
        Time.timeScale = 1;
        sounds[1].Play();
        general.player.blocked = true;
        general.paused = false;
        settingScreen.SetActive(false);
        general.player.enabled = true;
    }

    public void Settings()
    {
        Time.timeScale = 0;
        general.player.enabled = false;
        sounds[1].Play();
        general.player.blocked = true;
        general.paused = true;
        settingScreen.SetActive(true);
    }

    public void tutorialcheck3()
    {
        if (general.ui.tutorial3 == 0)
        {
            general.ui.tutorial3 = 1;
            PlayerPrefs.SetInt("tutorial3", 1);
            PlayerPrefs.Save();
            general.ui.tipAnimator.gameObject.SetActive(false);
            general.ui.tipAnimator.enabled = false;
        }
    }
    public void a1()
    {
        tutorialcheck3();
        sounds[1].Play();
        general.player.blocked = true;
        if (hp < 5)
        {
            if (coins >= price1)
            {
                coins -= price1;
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.Save();
                hearts[hp].gameObject.SetActive(true);
                hp += 1;
            }
            else
            {
                general.ui.tipAnimator.gameObject.SetActive(true);
                tipAnimator.enabled = true;
                tipAnimator.Play("Warning", 0, 0);

            }
        }
    }

    public void a2()
    {
        tutorialcheck3();
        //sounds[1].Play();
        general.player.blocked = true;

        if (coins >= price2)
        {
            if (!a2active)
            {
                sounds[4].Play();
                coins -= price2;
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.Save();
                a2active = true;
                a2timer = a2timerMax;
                general.shield.SetActive(true);
            }
        }
        else
        {
            general.ui.tipAnimator.gameObject.SetActive(true);
            tipAnimator.enabled = true;
            tipAnimator.Play("Warning", 0, 0);

        }
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        sounds[1].Play();
        if (chosenLevel <= howManyLevelsDone + 1 && chosenLevel != levelMax)
        {
            chosenLevel += 1;
            mode += 1;
            if (mode > 10)
            {
                mode = 1;
            }

            PlayerPrefs.SetFloat("chosenLevel", chosenLevel);
            PlayerPrefs.SetFloat("mode", mode);
            PlayerPrefs.Save();
            reloadScene();
        }
    }
}
