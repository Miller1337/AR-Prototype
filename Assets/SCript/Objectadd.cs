using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Objectadd : MonoBehaviour
{
    // Start is called before the first frame update
    private SCR programmManagerScript;
    private Button button;
    public GameObject ChoosedObject;
    void Start()
    {
        programmManagerScript = FindObjectOfType<SCR>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseObjectFunck);

    }

    // Update is called once per frame
    void ChooseObjectFunck()
    {
        programmManagerScript.OBJS = ChoosedObject;
        programmManagerScript.ChoseOB = true;
    }
}
