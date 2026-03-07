using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int id
    {
        get; private set;
    }

    private SceneController controller;
    public void SetCard(int cardId, Sprite image, SceneController ctrl)
    {
        id = cardId;
        GetComponent<SpriteRenderer>().sprite = image;
        controller = ctrl;
    }

    [SerializeField] private GameObject cardBack;
// activeSelf solo indica si el objeto está activo, pero puede que su padre esté inactivo, lo que haría que el objeto no se muestre aunque activeSelf sea true. Para verificar si el objeto está realmente visible, se puede usar la propiedad activeInHierarchy, que devuelve true solo si el objeto y todos sus padres están activos.

    public bool IsFaceUp
    {
        get { return !cardBack.activeSelf; }
    }
    public void Reveal()
    {
        cardBack.SetActive(false);
    }
    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
    public void OnMouseDown()
    {
        controller.HandleClick(this);

    }
}