using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Shop : MonoBehaviour, Interactable {
    
    [SerializeField] private UnityEvent interactEvent;
    [SerializeField] private Transform itemSpawnPoint, itemDisplayPoint;
    [SerializeField] private TMP_Text priceDisplay;
    public int cost = 0, purchaseLimit = 1;
    GameManager gameManager;
    public GameObject good;

    private void Start() {
        gameManager = GameManager.instance;

        if(good != null)
        {
            GameObject displayItem = Instantiate(good, itemDisplayPoint.position, itemDisplayPoint.rotation, itemDisplayPoint);

            //remove the collider so the item cannot be interacted with
            if(displayItem.GetComponent<Collider>() != null)
            {
                displayItem.GetComponent<Collider>().enabled = false;
            }
        }

        priceDisplay.text = $"${cost}";
    }

    public void Interact()
    {
        if(gameManager.playerScore >= cost && purchaseLimit > 0){
            interactEvent.Invoke();
            gameManager.AddScore(-cost);
            --purchaseLimit;
            Debug.Log($"player just bought {good.name}");
        }
    } 

    public void SpawnGood()
    {
        Instantiate(good, itemSpawnPoint.position, Quaternion.identity);
    }
}