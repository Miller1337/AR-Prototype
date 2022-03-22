using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    private Button button;
    private SCR programmManagerScript; 
    // Start is called before the first frame update
    void Start()
    {
        programmManagerScript = FindObjectOfType<SCR>();
        button = GetComponent<Button>();
        button.onClick.AddListener(RotationFunction);
    }

    // Update is called once per frame
    void RotationFunction()
    {
        if (programmManagerScript.Rot)
        {
            programmManagerScript.Rot = false;
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            programmManagerScript.Rot = true;
            GetComponent<Image>().color = Color.gray;

        }
    }
}
