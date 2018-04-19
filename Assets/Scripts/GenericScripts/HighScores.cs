using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("HighScores")]
public class HighScores
{
    private const int HIGH_SCORES_NUMBER = 10;
    [XmlArray("Scores")]
    public List<Score> scores;

    public HighScores()
    {
        this.scores = new List<Score>(HIGH_SCORES_NUMBER);
    }
}