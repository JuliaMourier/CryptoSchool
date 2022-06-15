using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public SymetricCipher _symetricCipher;
    public LetterIteration letterIterationPrefab;

    private List<LetterIteration> _letterIterationsList = new List<LetterIteration>();

    
    // Start is called before the first frame update
    void Start()
    {
        int k = 0;
        Dictionary<string, float> fqFr = SymetricCipher.FrequentialIterationGenerator();
        foreach (string l in fqFr.Keys)
        {
            
            LetterIteration li = Instantiate(letterIterationPrefab, transform);
            li.transform.localPosition = k * li.spaceBtwLettersIt * Vector3.right + 20 * Vector3.right;
            li.barForFrench.percentage = fqFr[l];
            li.letter = l;
            li.barForText.gameObject.SetActive(false);
            li.barForFrench.SetHeight();
            _letterIterationsList.Add(li);
            li.legend.text = l;
            k++;
        }
    }

    public void CalculateFrequentialIteration()
    {
        Dictionary<string, float> fqTxt = _symetricCipher.letterFrequentialIteration;

        foreach (LetterIteration li in _letterIterationsList)
        {
            li.barForText.gameObject.SetActive(true);
            li.barForText.percentage = fqTxt[li.letter];
            li.barForText.SetHeight();

        }
    }
}
