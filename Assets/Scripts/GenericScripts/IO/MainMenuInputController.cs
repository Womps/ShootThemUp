using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuInputController : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;
    [SerializeField]
    private GameObject selectedObject;
    private bool buttonSelected;

    // Use this for initialization
    void Start ()
    {
		
	}

	// Update is called once per frame
	void Update ()
    {
		if((Input.GetAxisRaw("Vertical") != 0) && (!this.buttonSelected))
        {
            this.eventSystem.SetSelectedGameObject(this.selectedObject);
            this.buttonSelected = true;
        }
	}

    private void OnDisable()
    {
        this.buttonSelected = false;
    }
}