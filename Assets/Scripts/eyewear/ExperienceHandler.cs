using UnityEngine;

public class ExperienceHandler : MonoBehaviour
{
    private static ExperienceHandler Instance;
    public string activeEyeGlass = "glass1";
    public GameObject textMessage, panel;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static ExperienceHandler GetInstance()
    {
        return Instance;
    }
    public void DeleteExistingGlasses()
    {
        GameObject go;
        try
        {
            go = GameObject.FindGameObjectWithTag("glassparent");
            foreach(Transform child in go.transform)
            {
                Destroy(child.gameObject);
            }
        }
        catch { Debug.LogError("Error in deleting existing eyeglass"); }
    }

    public void LoadEyeglass(string _name=null)
    {
        DeleteExistingGlasses();
        if(_name==null)
        {
            _name = activeEyeGlass;
        }
        try
        {
            GameObject prefab = Resources.Load<GameObject>("glassprefabs/" + _name);
            GameObject _parent = GameObject.FindGameObjectWithTag("glassparent");

            if (prefab != null)
            {
                GameObject instantiatedPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                instantiatedPrefab.transform.SetParent(_parent.transform);
                instantiatedPrefab.transform.localPosition = Vector3.zero;
                instantiatedPrefab.transform.localScale = Vector3.one;
                instantiatedPrefab.transform.localRotation = Quaternion.identity;
            }
            else { Debug.Log("asset prefab missing"); }
        }
        catch { Debug.LogError("instantiating seleted prefab failed"); }
    }

    public void HandleInstructions(bool value)//false-> show, true->hide
    {
        textMessage.SetActive(value);
        panel.SetActive(!value);
    }
}
