using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

    private void encrypt(string s) {
        string n = string.Empty;
        char x = ' ';

        for(int i = 0; i < s.Length; i++) {
            switch(s[i]) {
                case 'A': x = 'S'; break;
                case 'B': x = 'N'; break;
                case 'C': x = 'V'; break;
                case 'D': x = 'F'; break;
                case 'E': x = 'R'; break;
                case 'F': x = 'G'; break;
                case 'G': x = 'H'; break;
                case 'H': x = 'J'; break;
                case 'I': x = 'O'; break;
                case 'J': x = 'K'; break;
                case 'K': x = 'L'; break;
                case 'L': x = 'A'; break;
                case 'M': x = 'Z'; break;
                case 'N': x = 'M'; break;
                case 'O': x = 'P'; break;
                case 'P': x = 'Q'; break;
                case 'Q': x = 'W'; break;
                case 'R': x = 'T'; break;
                case 'S': x = 'D'; break;
                case 'T': x = 'Y'; break;
                case 'U': x = 'I'; break;
                case 'V': x = 'B'; break;
                case 'W': x = 'E'; break;
                case 'X': x = 'C'; break;
                case 'Y': x = 'U'; break;
                case 'Z': x = 'X'; break;
                case '0': x = '0'; break;
                case '1': x = '2'; break;
                case '2': x = '3'; break;
                case '3': x = '1'; break;
                case '4': x = '5'; break;
                case '5': x = '6'; break;
                case '6': x = '4'; break;
                case '7': x = '8'; break;
                case '8': x = '9'; break;
                case '9': x = '7'; break;
                default:  x = ' '; break;
            }
            n += x;
        }
        Debug.Log(n);
    }
}