using UnityEngine;
using System;

public class ReSkinAnimation : MonoBehaviour
{

    public string spriteSheetName;

    void LateUpdate()
    {

        var subSprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName);
        Debug.Log(subSprites.Length);
        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            string spriteName = renderer.sprite.name;
            Debug.Log("SpriteName: " + spriteName);
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);
            Debug.Log("NewSprite: " + newSprite);
            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
}
    