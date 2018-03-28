using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class LetterGenerator : MonoBehaviour {

    public Text headerText;
    public Text bodyText;
    public Text footerText;

    public TextAsset staticLetters;
    public Dictionary<int, string[]> letterDictionary;
    public string charactersCompleted;
    public string charactersLeft;

    public string currentCharacter;
    public int incorrectCount = 0;
    public int currentLetter = 0;
    private int totalLetters = 14;


    private void Awake() {
        breakupFile(staticLetters);
    }

    private void Start() {
        assembleStaticLetter(currentLetter);
    }


    public void assembleStaticLetter(int i) {
        string[] x = letterDictionary[i];
        assembleLetter(x[0], x[1], x[2]);
    }


    public void assembleLetter(string h, string b, string f) {
        charactersCompleted = null;
        charactersLeft = b;
        currentCharacter = "" + b[0];
        incorrectCount = 0;

        headerText.text = "To:\n" + h;
        bodyText.text = "<color=white>" + charactersCompleted + "</color>" + charactersLeft;
        footerText.text = "From:\n" + f;
    }



    public void breakupFile(TextAsset t) {
        string[] s = t.text.Split('\n');
        string[] x = new string[3];
        
        letterDictionary = new Dictionary<int, string[]>();
        for(int i = 0; i < s.Length; i++) {
            x = s[i].Split('#');
            letterDictionary.Add(i, x);            
        }
    }



    public void completedCharacter(string m, bool isCorrect) {
        string tmp = string.Empty;

        if(charactersLeft.Length > 1) {
            for(int i = 1; i < charactersLeft.Length; i++) {
                tmp += charactersLeft[i];
            }
            charactersLeft = tmp;
            currentCharacter = "" + charactersLeft[0];
        }
        else{
            loadNextLetter();
        }
        
        if(!isCorrect) {
            charactersCompleted += "<color=red>" + m + "</color>";
            incorrectCount++;
        }
        else{
            charactersCompleted += m;
        }
        
        //blank space protection
        if(currentCharacter == " ") {
            completedCharacter(currentCharacter, true);
        }
        bodyText.text = "<color=green>" + charactersCompleted + "</color>" + charactersLeft;
    }


    public void loadNextLetter() {
        if(currentLetter == totalLetters-1) {
            currentLetter = 0;
        }
        else{
            currentLetter++;
        }
        assembleStaticLetter(currentLetter);
    }
}