using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SymetricCipher : MonoBehaviour
{
    //Private plain text to encrypt
    public string textToEncrypt = "HELLO EVERYONE";
    //Private encryption key
    public int encryptionKey = 0;
    //Used to save the list of number encryption corresponding
    private List<int> plainTextInInteger = new List<int>();
    private List<string> alphabet;
    private GameManager levelManager;
    //UI :
    public TextMeshProUGUI cipherText;
    public TextMeshProUGUI decryptionText;

    public Dictionary<string, float> letterFrequentialIteration = new Dictionary<string, float>();

    private Dictionary<string, string> substitutionTable;
    // Start is called before the first frame update
    void Start()
    {
        letterFrequentialIteration = FrequentialIterationGenerator();
        textToEncrypt = textToEncrypt.ToUpper();
        substitutionTable = GenerateSubtitutionTable();
        cipherText.text = Encrypt(textToEncrypt);
    }

    public Dictionary<string, string> GenerateSubtitutionTable()
    {
        Dictionary<string, string> tmpSubstitutionTable = new Dictionary<string, string>();
        alphabet = AlphabetGenerator.GetAnAlphabet();

        List<string> shuffledAlphabet = AlphabetGenerator.GetAnAlphabet();
        shuffledAlphabet = Ext.Shuffle(shuffledAlphabet);

        for (int i = 0; i < alphabet.Count; i++)
        {
            tmpSubstitutionTable.Add(alphabet[i], shuffledAlphabet[i]);
        }
        
        tmpSubstitutionTable.Add("'", "'");
        tmpSubstitutionTable.Add(" ", " ");
        tmpSubstitutionTable.Add(".", ".");

        return tmpSubstitutionTable;
    }

    private string TestString(List<string> list)
    {
        string liststring = "string : ";
        foreach (string s in list)
        {
            liststring += s;
        }

        return liststring;
    }
    public string Encrypt(string plainText)
    {
        string cipher = "";
        foreach (char letter in plainText)
        {
            cipher += substitutionTable[letter.ToString()];
        }
        return cipher;
    }
    
    public string Decrypt(string cipherText)
    {
        string plain = "";
        foreach (char letter in cipherText)
        {
            plain += substitutionTable[letter.ToString()];
        }

        return plain;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

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
