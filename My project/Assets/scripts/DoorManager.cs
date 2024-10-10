using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private bool locked;
    public bool keyPickedUp;

    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if(!locked && distance < 0.5f)
        {
            SceneManager.LoadScene(0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            locked = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyPickedUp)
        {
            locked = true;
        }
    }
}
