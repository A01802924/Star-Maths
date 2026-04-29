using Assets.Scripts.Core;
using UnityEngine;

public class BuildTrail : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Sprite newTrail = Sprite.Create(
            SessionData.CurrentTrailItem.itemIcon,
            new Rect(0, 0, SessionData.CurrentTrailItem.itemIcon.width, SessionData.CurrentTrailItem.itemIcon.height),
            new Vector2(0.5f, 0.5f)
        );
        spriteRenderer.sprite = newTrail;
    }
}
