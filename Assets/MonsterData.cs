using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterLevel
{
	public int cost;
	public GameObject visualization;
    public GameObject bullet;
    public float fireRate;
}


public class MonsterData : MonoBehaviour {

    public List<MonsterLevel> levels;
    private MonsterLevel currentLevel;

	//Unity lifecycle methods
	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnEnable()
	{
		CurrentLevel = levels[0];
	}

    //Instance methods

	public MonsterLevel GetNextLevel()
	{
        int currentLevelIndex = levels.IndexOf(currentLevel);
        return currentLevelIndex + 1 < levels.Count ? levels[currentLevelIndex + 1] : null;
	}

	public void IncreaseLevel()
	{
		int currentLevelIndex = levels.IndexOf(currentLevel);
		if (currentLevelIndex < levels.Count - 1)
		{
			CurrentLevel = levels[currentLevelIndex + 1];
		}
	}

	//Properties

	public MonsterLevel CurrentLevel
	{
		get
		{
			return currentLevel;
		}
		set
		{
			currentLevel = value;
			int currentLevelIndex = levels.IndexOf(currentLevel);

            // Set visualization to the correct sprite
			GameObject levelVisualization = levels[currentLevelIndex].visualization;
			for (int i = 0; i < levels.Count; i++)
			{
				if (levelVisualization != null)
				{
					if (i == currentLevelIndex)
					{
						levels[i].visualization.SetActive(true);
					}
					else
					{
						levels[i].visualization.SetActive(false);
					}
				}
			}
		}
	}

}
