using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SymetricCipher : MonoBehaviour
{
    //Private plain text to encrypt
    public string textToEncrypt = "HELLO EVERYONE";
    private string decrypted;
    private List<string> alphabet;
    private GameManager levelManager;
    //UI :
    public TextMeshProUGUI cipherText;
    private string cipher = "";
    public Dictionary<string, float> letterFrequentialIteration;

    private Dictionary<string, string> substitutionTable;

    public AlphabetGenerator alphabetInput;

    // Start is called before the first frame update
    void Start()
    {
        //Get game manager
        levelManager = FindObjectOfType<GameManager>();
        //Letter frequential iteration for french letter
        letterFrequentialIteration = FrequentialIterationGenerator();
        //Put the plain text in upper case
        textToEncrypt = textToEncrypt.ToUpper();
        //Generate a substitution table for the alphabet
        substitutionTable = GenerateSubtitutionTable();
        //Encrypt
        cipher = Encrypt(textToEncrypt);
        //Display the encryption
        cipherText.text = cipher;
        //Calculate the frequential iteration of the letter in the cipher text
        letterFrequentialIteration = FrequentialIterationCalculator(cipher);
        //Add the onvalue Changed listener on the input field to decrypt when value is changed
        LettersInputOnChangedValueInit();
    }

    private void LettersInputOnChangedValueInit()
    {
        //Add the onvalue Changed listener on the input field to decrypt when value is changed

        foreach (Letter letter in alphabetInput.letters)
        {
            letter.transform.Find("InputField").gameObject.GetComponent<TMP_InputField>().onValueChanged.AddListener((string s) => OnLetterChanged(s));
        }
    }

    //When a letter is changed in the textinput launch the decryption
    public void OnLetterChanged(string value)
    {
        //Creation of the new substitution table (in function of the text input)
        Dictionary<string, string> tmpSubstitutionTable = new Dictionary<string, string>();
        alphabet = AlphabetGenerator.GetAnAlphabet();
        foreach (Letter letter in alphabetInput.letters)
        {
            string tmpLetterContent = letter.GetComponentInChildren<TMP_InputField>().text;
            //if no letter has been put by the player to override, keep the based letter
            if (tmpLetterContent != "")
            {
                tmpSubstitutionTable.Add(letter.index,tmpLetterContent);
            }
        }
        //Launch the decryption with this new substitutuion table
        string decryption = Decrypt(tmpSubstitutionTable);
        cipherText.text = decryption;
        //Test if the decryption text is identical to the plain text
        if (decrypted == textToEncrypt)
        {
            //launch win
            levelManager.hasWinLevel = true;
        }
    }
    
    //Generate a random substitution table which associate letters of the alphabet to random substitution letters
    public Dictionary<string, string> GenerateSubtitutionTable()
    {
        Dictionary<string, string> tmpSubstitutionTable = new Dictionary<string, string>();
        //generate an ordered alphabet
        alphabet = AlphabetGenerator.GetAnAlphabet();
        //Create a new alphabet
        List<string> shuffledAlphabet = AlphabetGenerator.GetAnAlphabet();
        //Shuffle the alphabet to have a random substitution
        shuffledAlphabet = Ext.Shuffle(shuffledAlphabet);

        for (int i = 0; i < alphabet.Count; i++)
        {
            tmpSubstitutionTable.Add(alphabet[i], shuffledAlphabet[i]);
        }
        //Add special characters for them not to be replaced by something else
        tmpSubstitutionTable.Add("'", "'");
        tmpSubstitutionTable.Add(" ", " ");
        tmpSubstitutionTable.Add(".", ".");

        return tmpSubstitutionTable;
    }
    
    //Encrypt by replacing each letter from the text by its equivalent of the substitution table
    public string Encrypt(string plainText)
    {
        string ciph = "";
        foreach (char letter in plainText)
        {
            ciph += substitutionTable[letter.ToString()];
        }
        return ciph;
    }
    
    //Decrypt by replacing each letter from the text by its equivalent of the substitution table guven by the user
    public string Decrypt(Dictionary<string, string> substitutionTableTmp)
    {
        string plain = "";
        decrypted = "";
        foreach (char letter in cipher)
        {
            //If the subsititution table contains the character given => change it by its equivalent
            if (substitutionTableTmp.ContainsKey(letter.ToString()))
            {
                //<mark> allow to highlight the character and show to the user that it has been changed
                plain += "<mark>" + substitutionTableTmp[letter.ToString()].ToUpper() + "</mark>";
                decrypted += substitutionTableTmp[letter.ToString()].ToUpper();
            }
            else
            {
                plain += letter;
                decrypted += letter;
            }
        }
        return plain;
    }
    
    //Calculate the frequential iteration of letters in a text
    public Dictionary<string, float> FrequentialIterationCalculator(string text)
    {
        Dictionary<string, float> tmpFrequentialresult = new Dictionary<string, float>();
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        for (int i = 0; i < abc.Length; i++)
        {
            tmpFrequentialresult[abc[i].ToString()] = 0f;
        }
        tmpFrequentialresult.Add("'", 0);
        tmpFrequentialresult.Add(" ", 0);
        tmpFrequentialresult.Add(".", 0);

        foreach (char letter in text)
        {
            tmpFrequentialresult[letter.ToString()]++;
        }

        return tmpFrequentialresult;
    }

    //Return the frequential iteration of letters in the french language
    public static Dictionary<string, float> FrequentialIterationGenerator()
    {
        Dictionary<string, float> frequentialIteration = new Dictionary<string, float>();

        frequentialIteration.Add("A", 9.42f);
        frequentialIteration.Add("B", 1.02f);
        frequentialIteration.Add("C", 2.64f);
        frequentialIteration.Add("D", 3.39f);
        frequentialIteration.Add("E", 15.87f);
        frequentialIteration.Add("F", 0.95f);
        frequentialIteration.Add("G", 1.04f);
        frequentialIteration.Add("H", 0.77f);
        frequentialIteration.Add("I", 8.41f);
        frequentialIteration.Add("J", 0.89f);
        frequentialIteration.Add("K", 0.00f);
        frequentialIteration.Add("L", 5.34f);
        frequentialIteration.Add("M", 3.24f);
        frequentialIteration.Add("N", 7.15f);
        frequentialIteration.Add("O", 5.14f);
        frequentialIteration.Add("P", 2.86f);
        frequentialIteration.Add("Q", 1.06f);
        frequentialIteration.Add("R", 6.46f);
        frequentialIteration.Add("S", 7.90f);
        frequentialIteration.Add("T", 7.26f);
        frequentialIteration.Add("U", 6.24f);
        frequentialIteration.Add("V", 2.15f);
        frequentialIteration.Add("W", 0.00f);
        frequentialIteration.Add("X", 0.30f);
        frequentialIteration.Add("Y", 0.24f);
        frequentialIteration.Add("Z", 0.32f);

        return frequentialIteration;
    }
}

//Class found on the internet allowing to shuffle randomly lists
public class Ext : MonoBehaviour
{
    public static List<T> Shuffle<T>(List<T> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            T temp = _list[i];
            int randomIndex = Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }

        return _list;
    }
}
