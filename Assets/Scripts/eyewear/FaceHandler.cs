using UnityEngine;

public class FaceHandler : MonoBehaviour
{
    private void OnEnable()
    {
        ExperienceHandler.GetInstance().LoadEyeglass();
    }
}
