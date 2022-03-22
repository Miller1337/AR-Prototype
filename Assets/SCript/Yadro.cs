using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yadro : MonoBehaviour
{

    private GameObject Yad;
    private Rigidbody YadRB;
    private Vector3 speed;
    public int force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = transform.forward * force;
    }
}
