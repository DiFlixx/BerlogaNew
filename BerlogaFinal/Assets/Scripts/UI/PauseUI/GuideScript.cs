using UnityEngine;

public class GuideScript : MonoBehaviour
{
    [SerializeField] private GameObject guideTextEsc, infoText, guideTextTab, guideTextY, guideTextSpace;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Destroy(guideTextEsc);
            Destroy(infoText);
        }
        else if (Input.GetKey(KeyCode.Tab))
        {
            Destroy(guideTextTab);
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            Destroy(guideTextY);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Destroy(guideTextSpace);
        }
    }
}