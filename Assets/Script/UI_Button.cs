using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    public GameObject pnlName, inputText, displayText, sucText;
    public Button  btnOK, btnCancel;

    public string theName;

    public void showName()
    {
        theName = inputText.GetComponent<Text>().text;
        displayText.GetComponent<Text>().text = "Hello: " + theName;
        sucText.SetActive(true);
    }

    public void backMenu()
    {
        pnlName.SetActive(false);
    }

    public void changeName()
    {
        pnlName.SetActive(true);
    }
}
