using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPanelController : MonoBehaviour
{
    public static FloorPanelController instance;
    [SerializeField] private bool canSelectFloors;
    [SerializeField] private bool isOnTheGroundFloor = true;
    [SerializeField] private bool isOnTheFirstFloor = false;
    [SerializeField] private bool isOnTheSecondFloor = false;
    [SerializeField] private GameObject panelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundUpOneFloor();
        GroundUpTwoFloors();
        SecondDownOneFloor();
        SecondDownTwoFloors();
        FirstDownOneFloor();
        FirstUpOneFloor();
    }

    public void FirstUpOneFloor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && canSelectFloors && isOnTheFirstFloor)
        {
            GetComponentInParent<Animator>().SetTrigger("upSecondFloor(2)");
            isOnTheGroundFloor = false;
            isOnTheFirstFloor = false;
            isOnTheSecondFloor = true;
        }
    }

    public void FirstDownOneFloor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && canSelectFloors && isOnTheFirstFloor)
        {
            GetComponentInParent<Animator>().SetTrigger("downGroundFloor");
            isOnTheGroundFloor = true;
            isOnTheFirstFloor = false;
            isOnTheSecondFloor = false;
        }
    }

    public void SecondDownTwoFloors()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && canSelectFloors && isOnTheSecondFloor)
        {
            //GetComponentInParent<Animator>().SetTrigger("downFirstFloor");
            GetComponentInParent<Animator>().SetTrigger("downGroundFloor(2)");
            isOnTheGroundFloor = true;
            isOnTheFirstFloor = false;
            isOnTheSecondFloor = false;
        }
    }

    public void SecondDownOneFloor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canSelectFloors && isOnTheSecondFloor)
        {
            GetComponentInParent<Animator>().SetTrigger("downFirstFloor");
            isOnTheSecondFloor = false;
            isOnTheFirstFloor = true;
            isOnTheGroundFloor = false;
        }
    }

    public void GroundUpTwoFloors()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && canSelectFloors && isOnTheGroundFloor)
        {
            //GetComponentInParent<Animator>().SetTrigger("upFirstFloor");
            GetComponentInParent<Animator>().SetTrigger("upSecondFloor");
            isOnTheGroundFloor = false;
            isOnTheFirstFloor = false;
            isOnTheSecondFloor = true;
        }
    }

    public void GroundUpOneFloor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canSelectFloors && isOnTheGroundFloor)
        {
            GetComponentInParent<Animator>().SetTrigger("upFirstFloor");
            isOnTheGroundFloor = false;
            isOnTheFirstFloor = true;
            isOnTheSecondFloor = false;

        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelText.gameObject.SetActive(true);
            canSelectFloors = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panelText.gameObject.SetActive(false);
        canSelectFloors = false;
    }

    public bool GetGroundFloor()
    {
        return isOnTheGroundFloor;
    }
    public bool GetFirstFloor()
    {
        return isOnTheFirstFloor;
    }

    public bool GetSecondFloor()
    {
        return isOnTheSecondFloor;
    }

    public void SetGroundFloor(bool state)
    {
        this.isOnTheGroundFloor = state;
    }

    public void SetFirstFloor(bool state)
    {
        this.isOnTheFirstFloor = state;
    }

    public void SetSecondFloor(bool state)
    {
        this.isOnTheSecondFloor = state;
    }

}
