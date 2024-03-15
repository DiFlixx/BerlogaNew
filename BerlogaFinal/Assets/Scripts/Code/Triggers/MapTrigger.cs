using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    [SerializeField] private int index;

    [SerializeField] private Maps _maps;

    private bool _entered;

    private void Update()
    {
        if (_entered && Input.GetKeyDown(KeyCode.E))
        {
            _maps.mapsOnUI[index].SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _entered = false;
        }
    }
}