using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

public class XmlHelpers
{
    public static T LoadFromTextAsset<T>(TextAsset textAsset, Type[] extraTypes = null)
    {
        if (textAsset == null)
        {
            throw new ArgumentNullException("textAsset");
        }

        TextReader textStream = null;

        try
        {
            textStream = new StringReader(textAsset.text);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T data = (T)serializer.Deserialize(textStream);

            textStream.Close();

            return data;
        }
        catch (Exception exception)
        {
            Debug.LogError("The database of type '" + typeof(T) + "' failed to load the asset. The following exception was raised:\n " + exception.Message);
        }
        finally
        {
            if (textStream != null)
            {
                textStream.Close();
            }
        }

        return default(T);
    }

    public static T LoadFromFile<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            T data = (T)serializer.Deserialize(stream);

            stream.Close();

            return data;
        }
    }

    public static void SaveToXML<T>(string path, T objectToSerialize) where T : class
    {
        if (string.IsNullOrEmpty(path))
        {
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StreamWriter stream = new StreamWriter(path, false, new UTF8Encoding(false)))
        {
            //Debug.Log(stream.ToString());

            serializer.Serialize(stream, objectToSerialize);
            stream.Close();
        }
    }
}