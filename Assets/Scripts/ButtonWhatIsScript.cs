using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWhatIsScript : MonoBehaviour
{
    [SerializeField]
    GameObject infoAlgoCanvas;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WHAT_IS_ACTIVE_CLICK()
    {
        infoAlgoCanvas.SetActive(true);
    }

    public void WHAT_IS_DESACTIVE_CLICK()
    {
        infoAlgoCanvas.SetActive(false);
    }
}
