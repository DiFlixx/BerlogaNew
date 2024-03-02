using Unity.VisualScripting;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
	[SerializeField] private GameObject _button;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "MainCharacter2")
		{
			_button.SetActive(true);
		}
	}
}