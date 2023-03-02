using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        controller.Move(inputs * Time.timeScale * speed);


    }
}
