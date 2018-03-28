using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	
    public GameObject morsePanel;
    public GameObject letterPanel;
    public GameObject pauseMenu;
    public GameObject moneyText;
    public GameObject aboutPanel;
    public GameObject settingsPanel;

    public GameObject volumeSlider;
    public GameObject pitchSlider;
    public GameObject submitSlider;

    private GameManager gameManagerScript;
    private SoundManager soundManagerScript;
    public AudioClip dotSound;
    public AudioClip startSound;


    public void Start() {
        gameManagerScript = this.GetComponent<GameManager>();
        soundManagerScript = this.GetComponent<SoundManager>();

        soundManagerScript.PlaySingle(startSound);
    }



    public void pauseGame(bool isPaused) {

        morsePanel.SetActive(!isPaused);
        letterPanel.SetActive(!isPaused);
        moneyText.SetActive(!isPaused);
        pauseMenu.SetActive(isPaused);
        
        if(!isPaused) {
            aboutPanel.SetActive(false);
            settingsPanel.SetActive(false);
            gameManagerScript.characterUI.text = " ";
        }

        soundManagerScript.PlaySingle(dotSound);
    }


    public void aboutButton() {
        soundManagerScript.PlaySingle(dotSound);
        aboutPanel.SetActive(!aboutPanel.activeSelf);

        if(settingsPanel.activeSelf) {
            settingsPanel.SetActive(false);
        }
    }


    public void settingsButton() {
        soundManagerScript.PlaySingle(dotSound);
        settingsPanel.SetActive(!settingsPanel.activeSelf);

        if(aboutPanel.activeSelf) {
            aboutPanel.SetActive(false);
        }
    }




    public void exitGame() {
        soundManagerScript.PlaySingle(dotSound);
        Application.Quit();
    }



    public void volume() {
        
        soundManagerScript.volume = volumeSlider.GetComponent<Slider>().value;
    }

    public void pitch() {

        soundManagerScript.pitch = pitchSlider.GetComponent<Slider>().value;
    }

    public void submit() {

        gameManagerScript.noInputTime = submitSlider.GetComponent<Slider>().value;
    }


    public void resetSliders() {
        volumeSlider.GetComponent<Slider>().value = 1.0f;
        pitchSlider.GetComponent<Slider>().value = 1.0f;
        submitSlider.GetComponent<Slider>().value = 1.0f;

        volume();
        pitch();
        submit();
    }

}
