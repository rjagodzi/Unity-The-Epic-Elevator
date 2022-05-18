using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public static ElevatorController instance;
    [SerializeField] private bool isDoorUnlocked = false;
    [SerializeField] private GameObject elevatorText;
    [SerializeField] private bool canOpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && canOpenDoor)
       {
            GetComponent<Animator>().SetTrigger("openDoor");
            isDoorUnlocked = true;
            PlayDoorSxf();
       }
    }

    private void Awake()
    {
        instance = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorUnlocked)
        {
            elevatorText.gameObject.SetActive(true);
            canOpenDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        elevatorText.gameObject.SetActive(false);
        canOpenDoor = false;
    }

    public void PlayDoorSxf()
    {
        AudioManager.instance.PlaySfx(0);
    }

    public void PlayRideSxf()
    {
        AudioManager.instance.PlaySfx(1);
    }

    public void ElevatorDoorIsLocked()
    {
        isDoorUnlocked = false;
    }

}
