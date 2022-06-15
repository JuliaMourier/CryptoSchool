using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cesar : MonoBehaviour
{
    //Decryption key
    public int decryptionShift = 0;
    //Private plain text to encrypt
    public string textToEncrypt = "HELLO EVERYONE";
    //Private encryption key
    public int encryptionKey = 0;
    //Used to save the encryption of the plain text
    public string cipher;
    //Used to save the list of number encryption corresponding
    private List<int> plainTextInInteger = new List<int>();
    //Alphabet 
    private List<string> _alphabet;

    private GameManager levelManager;
    //UI :
    public TextMeshProUGUI cipherText;
    public TextMeshProUGUI decryptionText;

    public Animator loose;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<GameManager>();
        //Turn the text into upper case
        textToEncrypt = textToEncrypt.ToUpper();
        //Generate a random key
        encryptionKey = Random.Range(1, 25);
        //Get an alphabet from Alphabet Generator
        _alphabet = AlphabetGenerator.GetAnAlphabet();
        //Save the integer list 
        plainTextInInteger = MessageIntoNumbers(textToEncrypt);
        //Encrypt the text 
        cipher = Encrypt(encryptionKey);
        cipherText.text = cipher;
        //Display the decryption with a key = 0 => No shifting
        Decrypt(0);
    }

    //Transform a letter into the number corresponding of the alphabet
    public int LetterIntoNumber(char letter)
    {
        if (letter.ToString() == " ")
        {
            return -1;
        }
        return _alphabet.IndexOf(letter.ToString());
    }

    //Transform a message into a list of corresponding numbers
    public List<int> MessageIntoNumbers(string message)
    {
        plainTextInInteger.Clear();
        foreach (char letter in message)
        {
            plainTextInInteger.Add(LetterIntoNumber(letter));
        }
        return plainTextInInteger;
    }

    //Transform a List of number by is equivalent string
    public string NumbersToMessage(List<int> messageInt)
    {
        string message = "";
        foreach (int letterInt in messageInt)
        {
            message += NumberToLetter(letterInt);
        }

        return message;
    }

    //Transform a number into the letter corresponding
    public string NumberToLetter(int letterInt)
    {
        if (letterInt == -1)
        {
            return " ";
        }
        return _alphabet[letterInt % 26];
    }
    
    
    //Encrypt the message with the random key 
    public string Encrypt(int key)
    {
        List<int> encryptedTextInteger = new List<int>();
        encryptedTextInteger.Clear();
        foreach (int letterInt in plainTextInInteger)
        {
            encryptedTextInteger.Add(letterInt + key);
        }

        return NumbersToMessage(encryptedTextInteger);
    }

    //Decrypt by using encryption with the key used by the user
    public void Decrypt(float key)
    {
        //Get the key from the slider (On slider changed called)
        decryptionShift = (int) key;
        plainTextInInteger = MessageIntoNumbers(cipher);
        decryptionText.text = Encrypt(decryptionShift);
    }

    public void Check()
    {
        if (decryptionText.text == textToEncrypt)
        {
            levelManager.hasWinLevel = true;
            decryptionText.gameObject.GetComponent<Animator>().SetTrigger("win");
        }
        else
        { 
            loose.SetTrigger("loose");
        }
    }

}
