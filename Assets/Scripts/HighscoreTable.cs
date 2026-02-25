using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f; 
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRecttransform = entryTransform.GetComponent<RectTransform>(); 
            entryRecttransform.anchoredPosition = new Vector2(0, -templateHeight * i );
            entryTransform.gameObject.SetActive(true);
        }
    }
}
