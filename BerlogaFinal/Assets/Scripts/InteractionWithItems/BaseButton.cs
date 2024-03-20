using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    [SerializeField] private UnityEngine.GameObject target;
    [SerializeField] GameObject MaleCharacter, FemaleCharacter;

    public void Create()
    {
        foreach (PlayerController controller in FindObjectsOfType<PlayerController>())

        if (controller._isMain)
        {
            Instantiate(target.gameObject, controller.transform.position - new Vector3(0, 0.2f, 0.1f), Quaternion.identity);
        }
    }
}
