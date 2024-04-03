using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    public string eyewearId;
    private void Start()
    {
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(ActivateEyewear);
    }
    void ActivateEyewear(bool value)
    {
        if(value)
        {
            ExperienceHandler.GetInstance().LoadEyeglass(eyewearId);
        }
    }
}
