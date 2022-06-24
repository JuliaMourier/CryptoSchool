using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    //Cipher symetric
    public SymetricCipher _symetricCipher;
    //Prefab for letter iteration
    public LetterIteration letterIterationPrefab;
    //Letter iteration list
    private List<LetterIteration> _letterIterationsList = new List<LetterIteration>();

    
    // Start is called before the first frame update
    void Start()
    {   
        //Number of bar (increment to ajust position)
        int k = 0;
        //Display the first frquential iteration for the french language
        Dictionary<string, float> fqFr = SymetricCipher.FrequentialIterationGenerator();
        //Ajust each letter bar 
        foreach (string l in fqFr.Keys)
        {
            
            LetterIteration li = Instantiate(letterIterationPrefab, transform);
            //Ajust position
            li.transform.localPosition = k * li.spaceBtwLettersIt * Vector3.right + 20 * Vector3.right;
            //Set the percentage
            li.barForFrench.percentage = fqFr[l];
            //Set the string of the letter
            li.letter = l;
            //ALlow it to be visible
            li.barForText.gameObject.SetActive(false);
            //Ajust height of the bar
            li.barForFrench.SetHeight();
            //Add it to the list
            _letterIterationsList.Add(li);
            //Add legend text
            li.legend.text = l;
            k++;
        }
    }

    //Display the frequential iteration f the letter in the cipher text
    public void CalculateFrequentialIteration()
    {
        Dictionary<string, float> fqTxt = _symetricCipher.letterFrequentialIteration;

        //Ajust each bar one per one
        foreach (LetterIteration li in _letterIterationsList)
        {
            li.barForText.gameObject.SetActive(true);
            li.barForText.percentage = fqTxt[li.letter];
            li.barForText.SetHeight();

        }
    }
}
