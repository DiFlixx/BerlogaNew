using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    [SerializeField] private int index;

    [SerializeField] private Maps _maps;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                _maps.mapsOnUI[index].SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}