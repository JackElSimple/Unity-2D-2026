using UnityEditor.EditorTools;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class Rotate : MonoBehaviour
{
    public float degreesPerSecond = 72.0f;
    public GameObject objeto;

    //GameObject parentObject = objeto.GetComponentInParent<GameObject.transform>();
    // obtener el gameobject padre
    


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, degreesPerSecond * Time.deltaTime);

    }
}
