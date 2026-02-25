//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections.Generic;  // Für List<>

//public class GameManager : MonoBehaviour
//{
//    // DEINE alten Felder (draggen!)
//    public GameObject startPanel, scoreScreen, gameUI;
//    public InputField startNameInput, scoreNameInput;
//    public Text scoreText;
//    public Button playButton, submitButton;
//    public ScoreManager scoreManager;

//    // NEU: Highscore Felder (draggen!)
//    public Transform highscoreContent;      // ScrollView/Viewport/Content
//    public GameObject highscoreRowPrefab;   // Dein Prefab (Name + Score)
//    public Text highscoreHeader;            // "HIGHSCORES:" Text

//    private string playerName = "";
//    private int currentKills = 0;  // Oder currentScore

//    void Start()
//    {
//        // DEIN alter Start-Code bleibt!
//        startPanel.SetActive(true);
//        gameUI.SetActive(false);
//        scoreScreen.SetActive(false);

//        playButton.onClick.AddListener(StartGame);
//        submitButton.onClick.AddListener(OnSubmitScore);
//    }

//    public void StartGame()
//    {
//        playerName = startNameInput.text;
//        if (string.IsNullOrEmpty(playerName)) playerName = "Anonymous";
//        PlayerPrefs.SetString("PlayerName", playerName);

//        startPanel.SetActive(false);
//        gameUI.SetActive(true);
//        scoreNameInput.text = playerName;
//        currentKills = 0;  // Reset
//    }

//    public void OnZombieKilled()
//    {
//        currentKills++;
//    }

//    public void PlayerDied()
//    {
//        // Dein Score
//        scoreText.text = playerName + "\nKills: " + currentKills + "\nScore: " + (currentKills * 100);

//        // Highscores anzeigen
//        ShowHighscores();

//        scoreScreen.SetActive(true);
//        Time.timeScale = 0;
//    }

//    // NEU: Highscores anzeigen
//    private void ShowHighscores()
//    {
//        // Alte Rows löschen
//        for (int i = highscoreContent.childCount - 1; i >= 0; i--)
//            Destroy(highscoreContent.GetChild(i).gameObject);

//        // Highscores laden (ScoreManager)
//        var highscores = scoreManager.GetHighscores(10);

//        if (highscoreHeader) highscoreHeader.text = "HIGHSCORES:";

//        // Rows erstellen
//        for (int i = 0; i < highscores.Count; i++)
//        {
//            GameObject row = Instantiate(highscoreRowPrefab, highscoreContent);
//            // Dein Prefab hat 2 Texts? NameText.text = highscores[i].name; ScoreText.text = highscores[i].score;
//            Text rowText = row.GetComponentInChildren<Text>();  // Oder passe an
//            rowText.text = (i + 1) + ". " + highscores[i].name + " - " + highscores[i].kills;  // .score später
//        }
//    }

//    void OnSubmitScore()
//    {
//        string finalName = scoreNameInput.text;
//        if (string.IsNullOrEmpty(finalName)) finalName = playerName;
//        scoreManager.SubmitZombieKills(finalName, currentKills);  // Deine DB

//        // Neustart
//        startPanel.SetActive(true);
//        scoreScreen.SetActive(false);
//        Time.timeScale = 1;
//        currentKills = 0;
//    }
//}
