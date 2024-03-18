using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GiveValue : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    
    // Start is called before the first frame update
    public void Start()
    {
        string newText = StaticData.valueToKeep;
        myText.text = newText;
    }
}
