using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevatorFirstPanelController : MonoBehaviour
{
    [SerializeField] private GameObject callElevatorText;
    [SerializeField] private bool canCallElevator;
    [SerializeField] private GameObject elevator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCallElevator && FloorPanelController.instance.GetGroundFloor())
        {
            elevator.GetComponent<Animator>().SetTrigger("openDoor");
            elevator.GetComponent<Animator>().SetTrigger("upFirstFloor");
            FloorPanelController.instance.SetGroundFloor(false);
            FloorPanelController.instance.SetFirstFloor(true);
            FloorPanelController.instance.SetSecondFloor(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && canCallElevator && FloorPanelController.instance.GetSecondFloor())
        {
            elevator.GetComponent<Animator>().SetTrigger("openDoor");
            elevator.GetComponent<Animator>().SetTrigger("downFirstFloor");
            FloorPanelController.instance.SetGroundFloor(false);
            FloorPanelController.instance.SetFirstFloor(true);
            FloorPanelController.instance.SetSecondFloor(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            callElevatorText.gameObject.SetActive(true);
            canCallElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        callElevatorText.gameObject.SetActive(false);
        canCallElevator = false;
    }
}
