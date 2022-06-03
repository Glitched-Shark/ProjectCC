using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager gmInstance { get; private set; }
    public AudioManager audioManager { get; private set; }
    public PlayerController playerController { get; private set; }

    void Awake()
    {
        if (gmInstance != null && gmInstance != this)
        {
            Destroy(this);
        }
        else
        {
            gmInstance = this;
            audioManager = GetComponentInChildren<AudioManager>();
            playerController = GetComponentInChildren<PlayerController>();
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
