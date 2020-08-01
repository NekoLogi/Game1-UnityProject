using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    bool isInRange;
    public Text interactTextEvent;
    public Item item;
    public UnityEvent interactAction;
    int interactObject; // 1 Item, 2 NPC
    string itemName;
    GameObject game;
    public void Start()
    {
       game = GameObject.Find("DialogueBox");
    }
    void Update()
    {
        if (isInRange){
            if (Input.GetKeyDown("f")) {
                if (interactObject == 1) {
                    PickUp();
                } else if (interactObject == 2) {
                    interactAction.Invoke();
                    game.SetActive(true);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        if (other.gameObject.CompareTag("NPC")) {
            interactTextEvent.gameObject.SetActive(true);
            interactTextEvent.text = "Talk";
            interactObject = 2;
        } else if (other.gameObject.CompareTag("Item")) {
            interactTextEvent.gameObject.SetActive(true);
            interactTextEvent.text = "Interact";
            interactObject = 1;
            itemName = other.gameObject.name;
        }
        Debug.Log(interactObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        interactTextEvent.gameObject.SetActive(false);
    }
    void PickUp()
    {
        Debug.Log("Picking up " + itemName);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }

}
