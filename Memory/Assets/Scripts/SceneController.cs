using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard templateCard;
    private void Start()
    {
        int id = Random.Range(0, GameManager.Instance.CardSprites.Count);
        var card = Instantiate<MemoryCard>(templateCard);
        card.SetCard(id, GameManager.Instance.CardSprites[id], this);
    }
    public void HandleClick(MemoryCard card)
    {
        if (card.IsFaceUp)
            card.Unreveal();
        else
            card.Reveal();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 50, 20), "Pasar nivel"))
        { GameManager.Instance.GoToNextLevel(); }
    }
}