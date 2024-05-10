using UnityEngine;

public class LevelController : MonoBehaviour
{
    void Start()
    {
        LevelFinder _levelFinder = Resources.Load<LevelFinder>("Sctipts/LevelFinder");
        int i = PlayerPrefs.GetInt("Level", 1);
        string Monologue = _levelFinder.Level[i].Text;
    }
}