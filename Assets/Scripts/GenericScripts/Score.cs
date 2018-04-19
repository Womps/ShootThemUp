using System.Xml.Serialization;

public class Score
{
    [XmlAttribute("nickName")]
    public string nickName;
    [XmlAttribute("scoreValue")]
    public int scoreValue;

    public Score()
    {
        this.nickName = "";
        this.scoreValue = 0;
    }
}