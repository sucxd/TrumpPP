using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class dialogue : MonoBehaviour
{
    [SerializeField, Header("the list with the text")]
    private List<string> text = new List<string>();

    [SerializeField, Header("the amount of text you have"), Tooltip("amount of lines")]
    private int page = 0;

    [SerializeField, Header("the input you have")]
    private InputAction next;

    [SerializeField]
    private TMP_Text InputText;


    // Start is called before the first frame update
    void Start()
    {
        //text you add
        text.Add("hello");
        text.Add("i'm peter");
        text.Add("trumpets and politics");

        //the binding with the you want to press
        next.AddBinding("<Keyboard>/e");
        next.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //checking if you pressed it
        if (next.triggered) Flipper();
    }
    void Flipper() 
    {
        //does the page check with how much their is left
        if (page < text.Count)
        {
            //flips
            InputText.text = text[page]; 
            page++;
        }
        else Debug.Log("text done");
    }
}
