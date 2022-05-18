using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevatorGroundPanelController : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.E) && canCallElevator && FloorPanelController.instance.GetFirstFloor())
        {
            elevator.GetComponent<Animator>().SetTrigger("openDoor");
            elevator.GetComponent<Animator>().SetTrigger("downGroundFloor");
            FloorPanelController.instance.SetGroundFloor(true);
            FloorPanelController.instance.SetFirstFloor(false);
            FloorPanelController.instance.SetSecondFloor(false);
        }
        else if(Input.GetKeyDown(KeyCode.E) && canCallElevator && FloorPanelController.instance.GetSecondFloor()) 
        {
            elevator.GetComponent<Animator>().SetTrigger("openDoor");
            elevator.GetComponent<Animator>().SetTrigger("downGroundFloor(2)");
            FloorPanelController.instance.SetGroundFloor(true);
            FloorPanelController.instance.SetFirstFloor(false);
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
