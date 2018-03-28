using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static GameManager instance = null; //singleton
    private MorseTranslator morseTranslatorScript;
    private LetterGenerator letterGeneratorScript;
    private SoundManager soundManagerScript;
    private UIManager uiManagerScript;
    public static KeyCode telegraphButton = KeyCode.Space;

    private float startTime;
    private float timeHeld;
    private float lastInput;
    private float dotTime = 0.20f;
    private float dashTime = 0.75f;
    //private float noInputTime = 1.0f;
    public float noInputTime = 1.0f;

    public static bool isPaused = false;

    private string currentMorse = string.Empty;
    private int morseCount = 0;
    private int morseLetterSize = 7;

    public Text characterUI;
    public Animator telegraphAnimator;
    public Text moneyText;
    public static int money = 0;

    public AudioClip dotSound;
    public AudioClip dashSound;



    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    private void Start() {
        morseTranslatorScript = this.GetComponent<MorseTranslator>();
        letterGeneratorScript = this.GetComponent<LetterGenerator>();
        soundManagerScript = this.GetComponent<SoundManager>();
        uiManagerScript = this.GetComponent<UIManager>();
        characterUI.text = string.Empty;
        moneyText.text = money + "₽";
        //Debug.Log(morseTranslatorScript.translate("Sent"));
    }


    private void Update() {

        if(!isPaused) {
            if(Time.time - lastInput >= noInputTime && morseCount > 0 && !Input.anyKey) {
                //Debug.Log("No input detected, sending letter as is.");
                sendCharacter();
            }
            if(Input.GetKeyDown(telegraphButton)) {
                startTime = Time.time;
                telegraphAnimator.SetBool("isPressed", true);
            }
            if(Input.GetKeyUp(telegraphButton)) {
                timeHeld = Time.time - startTime;
                lastInput = Time.time;
                //Debug.Log("Spacebar was held " + timeHeld);
                telegraphAnimator.SetBool("isPressed", false);

                if(timeHeld <= dashTime && timeHeld > dotTime) {
                    //Debug.Log("A dash was written in morse.");
                    currentMorse += "-";
                    soundManagerScript.PlaySingle(dashSound);
                    characterUI.text = currentMorse;
                    morseCount++;
                }
                else if(timeHeld <= dashTime) {
                    //Debug.Log("A dot was written in morse.");
                    soundManagerScript.PlaySingle(dotSound);
                    currentMorse += "∙";
                    characterUI.text = currentMorse;
                    morseCount++;
                }
                if(morseCount == morseLetterSize) {
                    sendCharacter();
                }
            }
        }
    }


    public void sendCharacter() {
        //Debug.Log(currentMorse + " === " + morseTranslatorScript.Translate(currentMorse) );

        string morse = morseTranslatorScript.translate(currentMorse);
        characterUI.text = morse;
        morseCount = 0;

        if(uiManagerScript.pauseMenu.activeSelf) {
            currentMorse = string.Empty;
            return;
        }
        if(currentMorse == morseTranslatorScript.translate("Next")) {
            //Debug.Log("Trying to send letter early");
            letterGeneratorScript.loadNextLetter();
            currentMorse = string.Empty;
            return;
        }
        if(currentMorse == morseTranslatorScript.translate("Pause")) {
            uiManagerScript.pauseGame(true);
            currentMorse = string.Empty;
            return;
        }
        currentMorse = string.Empty;
        
        if(morse == letterGeneratorScript.currentCharacter.ToUpper()) {
            //Debug.Log("Typed the correct letter, " + morse);
            letterGeneratorScript.completedCharacter(letterGeneratorScript.currentCharacter, true);
            addMoney(1);
        }
        else{
            //Debug.Log("Typed the incorrect letter, " + morse);
            if(morse == "Error") {
                morse = "!";
            }
            letterGeneratorScript.completedCharacter(morse, false);
        }
    }


    public void addMoney(int m) {
        money += m;
        moneyText.text = money + "₽";
    }
}