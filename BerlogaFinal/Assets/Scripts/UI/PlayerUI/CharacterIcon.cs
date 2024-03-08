using UnityEngine;

public class CharacterIcon : MonoBehaviour
{
    [SerializeField] private GameObject MaleIcon, FemaleIcon;
    [SerializeField] PlayerController MaleCharacter, FemaleCharacter;
    
    void Update()
    {
        if (MaleCharacter._isMain)
        {
            MaleIcon.SetActive(true);
            FemaleIcon.SetActive(false);
        }
        else
        {
            MaleIcon.SetActive(false);
            FemaleIcon.SetActive(true);
        }
    }
}
