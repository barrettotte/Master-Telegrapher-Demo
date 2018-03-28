using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MorseTranslator : MonoBehaviour {

    public static MorseTranslator instance = null;
    public static Dictionary<string, string> morseDictionary;

	
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        createMorseDictionary();
    }

	
    public string translate(string key) {
        string entry = string.Empty;
        
        if(morseDictionary.ContainsKey(key)) {
            entry = morseDictionary[key];
        }
        else{
            Debug.Log("Dictionary does not contain entry for key " + key);
            entry = "Error";
        }
        return entry;
    }


    private void createMorseDictionary() {
        morseDictionary = new Dictionary<string, string>() {

            //Alpha to Morse
            {"A", "∙-"},
            {"B", "-∙∙∙"},
            {"C", "-∙-∙"},
            {"D", "-∙∙"},
            {"E", "∙"},
            {"F", "∙∙-∙"},
            {"G", "--∙"},
            {"H", "∙∙∙∙"},
            {"I", "∙∙"},
            {"J", ".---"},
            {"K", "-∙-"},
            {"L", "∙-∙∙"},
            {"M", "--"},
            {"N", "-∙"},
            {"O", "---"},
            {"P", "∙--∙"},
            {"Q", "--∙-"},
            {"R", "∙-∙"},
            {"S", "∙∙∙"},
            {"T", "-"},
            {"U", "∙∙-"},
            {"V", "∙∙∙-"},
            {"W", "∙--"},
            {"X", "-∙∙-"},
            {"Y", "-∙--"},
            {"Z", "--∙∙"},

            {"0", "-----"},
            {"1", "∙----"},
            {"2", "∙∙---"},
            {"3", "∙∙∙--"},
            {"4", "∙∙∙∙-"},
            {"5", "∙∙∙∙∙"},
            {"6", "-∙∙∙∙"},
            {"7", "--∙∙∙"},
            {"8", "---∙∙"},
            {"9", "----∙"},

            {".", "∙-∙-∙-"},
            {",", "--∙∙--"},
            {":", "---∙∙∙" },
            //{"-", "-∙∙∙∙-" },
            //{"/", "-∙∙-∙" },
            //{"[", "-∙--∙-" },
            {"?", "∙∙--∙∙" },

            //{"Error", "--------" },
            //{"Starting Signal", "-∙-∙-"},
            {"Next", "∙-∙-∙" },
            {"Pause", "∙∙∙-∙-" },
            //{"SOS", "∙∙∙---∙∙∙" }



            //Morse to Alpha
            {"∙-","A"},
            {"-∙∙∙","B"},
            {"-∙-∙", "C"},
            {"-∙∙", "D"},
            {"∙", "E"},
            {"∙∙-∙", "F"},
            {"--∙", "G"},
            {"∙∙∙∙", "H"},
            {"∙∙", "I"},
            {"∙---", "J"},
            {"-∙-", "K"},
            {"∙-∙∙", "L"},
            {"--", "M"},
            {"-∙", "N"},
            {"---", "O"},
            {"∙--∙", "P"},
            {"--∙-", "Q"},
            {"∙-∙", "R"},
            {"∙∙∙", "S"},
            {"-", "T"},
            {"∙∙-", "U"},
            {"∙∙∙-", "V"},
            {"∙--", "W"},
            {"-∙∙-", "X"},
            {"-∙--", "Y"},
            {"--∙∙", "Z"},

            {"-----", "0"},
            {"∙----", "1"},
            {"∙∙---", "2"},
            {"∙∙∙--", "3"},
            {"∙∙∙∙-", "4"},
            {"∙∙∙∙∙", "5"},
            {"-∙∙∙∙", "6"},
            {"--∙∙∙", "7"},
            {"---∙∙", "8"},
            {"----∙", "9"},

            //{"----", "Do Something" },

            {"∙-∙-∙-", "."},
            {"--∙∙--", ","},
            {"---∙∙∙", ":" },
            //{"-∙∙∙∙-", "-" },
            //{"-∙∙-∙", "/" },
            //{"-∙--∙-", "[" },
            {"∙∙--∙∙", "?" },

            //{"--------", "Error" },
            //{"-∙-∙-", "Starting Signal"},
            {"∙-∙-∙", "Next" },
            {"∙∙∙-∙-", "Pause" },
            //{"∙∙∙---∙∙∙", "SOS" }
            
        };
    }
}