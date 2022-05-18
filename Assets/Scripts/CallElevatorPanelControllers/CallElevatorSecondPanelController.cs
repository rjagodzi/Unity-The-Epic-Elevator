using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevatorSecondPanelController : MonoBehaviour
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
            elevator.GetComponent<Animator>().SetTrigger("upSecondFloor");
            FloorPanelController.instance.SetGroundFloor(false);
            FloorPanelController.instance.SetFirstFloor(false);
            FloorPanelController.instance.SetSecondFloor(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && canCallElevator && FloorPanelController.instance.GetFirstFloor())
        {
            elevator.GetComponent<Animator>().SetTrigger("openDoor");
            elevator.GetComponent<Animator>().SetTrigger("upSecondFloor(2)");
            FloorPanelController.instance.SetGroundFloor(false);
            FloorPanelController.instance.SetFirstFloor(false);
            FloorPanelController.instance.SetSecondFloor(true);
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
