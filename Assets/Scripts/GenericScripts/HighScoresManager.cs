using UnityEngine;
using UnityEngine.UI;

public class HighScoresManager : MonoBehaviour
{
    private const string HIGH_SCORES_FILENAME = "HighScores.xml";
    private const int TABLE_COLUMNS_NUMBER = 3;
    private const int TABLE_ROWS_NUMBER = 10;
    private HighScores highScores;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject text;

    public HighScores HighScores
    {
        get;
        private set;
    }

    public void Awake()
    {
        string highScoresFilePath = Application.dataPath + HIGH_SCORES_FILENAME;
        // Load high scores from saved XML file.
        this.highScores = XmlHelpers.LoadFromFile<HighScores>(highScoresFilePath);
        this.highScores.scores.Sort((x, y) => y.scoreValue.CompareTo(x.scoreValue));
        this.CreatePlayerLabels();
    }

    public void CreatePlayerLabels()
    {
        GameObject newPlayerHighScore = null;
        Text playerText = null;

        for (int i = 0; i < TABLE_ROWS_NUMBER; i++)
        {
            for (int j = 0; j < TABLE_COLUMNS_NUMBER; j++)
            {
                newPlayerHighScore = Instantiate(this.text, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                newPlayerHighScore.transform.SetParent(this.panel.transform);
                newPlayerHighScore.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                playerText = newPlayerHighScore.GetComponent<Text>();

                if(j == 0) { playerText.text = (i+1).ToString(); }
                else if(j == 1) { playerText.text = this.highScores.scores[i].nickName; }
                else if(j == 2) { playerText.text = this.highScores.scores[i].scoreValue.ToString(); }
            }
        }
    }
}