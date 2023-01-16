using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class SoundManager : SingeltonBase<SoundManager>
{
    /* -------------- 	Game specific sounds --------------- */
    public AudioClip levelUpSound;
    // Done
    public AudioClip buttonClickSound;
	public AudioClip clockTick;
	public AudioClip wheelTick;
	public AudioClip miniGame;
	public AudioClip correctAnswer;
	public AudioClip wrongAnswer;

	public Button musicON;
	public Button musicOFF;
	public Button musicON1;
	public Button musicOFF1;
    // with menus
    public AudioClip menuBGSound;
    // Done
    public AudioClip gamePlayBGSound;
    // Done
    public AudioClip levelCompleteSound;
    // Done
    public AudioClip levelFailSound;
    public AudioClip playerRunSound;
    public AudioClip playerAttackSound;

	public AudioClip joinRoomSound;
	public AudioClip calculatorTap;
	public AudioClip problemSolved;
	public AudioClip startSound;
   
    /* Audio Source */
    public AudioSource gamePlayEffectsSource;
    public AudioSource BackgroundSoundSource;
    public AudioSource CarEnvSound;
    public AudioSource runSoundSource;
    public AudioSource healthSoundSource;





    public bool isDualSound = false;
    private bool isGamePlaySound = false;

    void Start()
    {
		
        DontDestroyOnLoad(this);
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();
        }

		//MusicONOFF(PlayerPrefs.GetString("music", "ON"));
    }
	public void MusicONOFF(string str)
	{
		if (str == "ON") 
		{
			UnMuteMusic();
			UnMuteSound();
			musicON.gameObject.SetActive(true);
			musicOFF.gameObject.SetActive(false);

			musicON1.gameObject.SetActive(true);
			musicOFF1.gameObject.SetActive(false);


		} 
		else if (str == "OFF")
		{
			MuteMusic();
			MuteSound();
			musicON.gameObject.SetActive(false);
			musicOFF.gameObject.SetActive(true);
			musicON1.gameObject.SetActive(false);
			musicOFF1.gameObject.SetActive(true);


		}
	}
  
	public void ButtonClickSound()
    {
        gamePlayEffectsSource.PlayOneShot(buttonClickSound);
    }

	#region Mute/UnMute_Handling
    public void MuteSound()
    {
        gamePlayEffectsSource.mute = true;
    }

    public void UnMuteSound()
    {
        gamePlayEffectsSource.mute = false;
    }

    public void MuteMusic()
    {
        GetComponent<AudioSource>().mute = true;
    }

    public void UnMuteMusic()
    {
        GetComponent<AudioSource>().mute = false;
    }
	#endregion
    public  void PlayMenuBGSound()
    {
        this.GetComponent<AudioSource>().clip = menuBGSound;
        this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = 0.7f;
       // CarEnvSound.Play();
    }

    public void PlayGamePlaySound()
    {
        this.GetComponent<AudioSource>().clip = gamePlayBGSound;
        this.GetComponent<AudioSource>().Play();
		this.GetComponent<AudioSource>().volume = 0.4f;
       // CarEnvSound.Play();
    }


    
	public void buttonClick()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = buttonClickSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }
	public void clockTickTick()
	{
		//gamePlayEffectsSource.GetComponent<AudioSource>().clip = clockTick;
		//gamePlayEffectsSource.GetComponent<AudioSource>().Play();
	}

	public void WheelTickTick()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(wheelTick);
		//gamePlayEffectsSource.GetComponent<AudioSource>().Play();
	}

	public void slotMachineON()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(miniGame);
		//runSoundSource.GetComponent<AudioSource>().Play();
	}

	public void CorrectAnswer()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(correctAnswer);
		//runSoundSource.GetComponent<AudioSource>().Play();
	}
	public void WrongAnwser()
	{
		gamePlayEffectsSource.GetComponent<AudioSource>().PlayOneShot(wrongAnswer);
		//runSoundSource.GetComponent<AudioSource>().Play();
	}

	public void menuBG()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = menuBGSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void levelComplete()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = levelCompleteSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void levelFail()
    {
		gamePlayEffectsSource.GetComponent<AudioSource>().clip = levelFailSound;
        gamePlayEffectsSource.GetComponent<AudioSource>().Play();
    }

	public void clockTickTock()
	{
		gamePlayEffectsSource.GetComponent<AudioSource> ().PlayOneShot (clockTick);
	}


	public void RoomSound()
	{
		gamePlayEffectsSource.GetComponent<AudioSource> ().PlayOneShot (joinRoomSound);
	}
	public void Tap()
	{
		gamePlayEffectsSource.GetComponent<AudioSource> ().PlayOneShot (calculatorTap);
	}
	public void ProblemCompleted()
	{
		gamePlayEffectsSource.GetComponent<AudioSource> ().PlayOneShot (problemSolved);

		}

	public void GOSound()
	{
		gamePlayEffectsSource.GetComponent<AudioSource> ().PlayOneShot (startSound);
	}
}