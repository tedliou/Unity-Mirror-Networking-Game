using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerProfile : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text stateText;
    [SerializeField] Text joinTimeText;
    [SerializeField] Color highlightColor;

    public bool isLocalPlayer;

    private void Update() {
        if (isLocalPlayer)
            nameText.color = highlightColor;
    }
}
