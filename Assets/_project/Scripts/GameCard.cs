using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public RectTransform cardArt;
    public CardData data;

    public float useHeight = 10f;
    public float useScaleFactor = 1.1f;
    public float useScaleSpeed = 0.2f;

    Vector3 holderScale;
    bool moving = false;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        holderScale = transform.parent.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        moving = true;
        //will get the canvas
        cardArt.transform.SetParent(transform.parent.parent);

        var r = PlayerResources.instance;
        ResourceUI.instance.energyText.text = $"Energy:{r.energy - data.cardCost}/{r.maxEnergy}";
        ResourceUI.instance.energyText.color = Color.red;

        AudioManager.instance.Play("CardGrab");

        foreach (var e in data.effects)
            e.ShowGuides();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (moving)
        {
            var pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            if (pos.y > useHeight)
            {
                UseVisuals(true);
            }
            else
            {
                UseVisuals(false);
            }

            cardArt.position = pos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moving = false;
        //gets card
        cardArt.transform.SetParent(transform);

        bool canUse = true;
        foreach (var e in data.effects)
        {
            if (!e.IsUsable())
            {
                canUse = false;
            }
        }

        if (cardArt.position.y > useHeight && data.cardCost <= PlayerResources.instance.energy && canUse)
        {
            //USE CARD
            foreach (var e in data.effects)
                e.HideGuides();
            PlayerResources.instance.AddEnergy(-data.cardCost);
            foreach (var e in data.effects)
                e.OnUse();
            DiscardCard();
        }
        else
        {
            cardArt.DOKill();
            cardArt.DOScale(Vector3.one, useScaleSpeed);
            cardArt.DOLocalMove(Vector3.zero, 0.2f);

            foreach(var e in data.effects)
                e.HideGuides();
        }
    }
    
    public void UseVisuals(bool active)
    {
        if (active)
        {
            cardArt.DOScale(holderScale * useScaleFactor, useScaleSpeed);
            return;
        }

        cardArt.DOScale(holderScale, useScaleSpeed);
    }

    public void DiscardCard()
    {
        CardData.OnCardDiscarded.Invoke(data);
        Destroy(gameObject);
    }
}
