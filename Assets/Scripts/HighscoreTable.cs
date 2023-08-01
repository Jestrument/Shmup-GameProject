using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
	[SerializeField] GameObject entryContainer;
	[SerializeField] GameObject entryTemplate;
	private List<HighscoreEntry> highscoreEntryList;
	private List<Transform> highscoreEntryTransformList;
	
    void Awake()
    {
        entryTemplate.SetActive(false);
		
		string jsonString = PlayerPrefs.GetString("highscoreTable");
		Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
		
		AddHighscoreEntry(000000, "AAA");
		
		highscoreEntryTransformList = new List<Transform>();
		foreach(HighscoreEntry highscoreEntry in highscoreEntryList)
		{
			CreateHighscoreEntryTransform(highscoreEntry, entryContainer.transform, highscoreEntryTransformList);
		}
		
		if (highscores.highscoreEntryList.Count > 10)
		{
            for (int h = highscores.highscoreEntryList.Count; h>10; h--)
			{
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }
    }
	
	private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList )
	{
		float templateHeight = 20;
		Transform entryTransform = Instantiate(entryTemplate.transform, container);
		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
		entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight * transformList.Count);
		entryTransform.gameObject.SetActive(true);
		
		int rank = transformList.Count + 1;
		string rankString;
		switch(rank)
		{
			default:
			rankString = rank + "TH"; 
			break;
			
			case 1:
			rankString = rank + "ST";
			break;
			
			case 2:
			rankString = rank + "ND";
			break;
			
			case 3:
			rankString = rank + "RD";
			break;
		}
		
		entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;
		
		int score = highscoreEntry.score;
		entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
		
		string name = highscoreEntry.name;
		entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;
		transformList.Add(entryTransform);
	}
	
	private void AddHighscoreEntry(int score ,string name)
	{
		HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name };
		
		string jsonString = PlayerPrefs.GetString("highscoreTable");
		Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
		
		highscores.highscoreEntryList.Add(highscoreEntry);
		if (highscores.highscoreEntryList.Count > 10)
		{
            for (int h = highscores.highscoreEntryList.Count; h>10; h--)
			{
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }
		string json = JsonUtility.ToJson(highscores);
		PlayerPrefs.SetString("highscoreTable",json);
		PlayerPrefs.Save();
	}
	
	private class Highscores
	{
		public List<HighscoreEntry> highscoreEntryList;
	}
	
	[System.Serializable]
	private class HighscoreEntry
	{
		public int score;
		public string name;
	}
	
}
