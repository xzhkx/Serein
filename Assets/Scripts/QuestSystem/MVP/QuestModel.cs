using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class QuestModel : MonoBehaviour
{
    private Dictionary<Button, Quest> buttonQuestDictionary = new Dictionary<Button, Quest>(10);
    private Dictionary<Quest, Button> questButtonDictionary = new Dictionary<Quest, Button>(10);

    public void CreateNewQuest(Button button, Quest quest)
    {
        buttonQuestDictionary.Add(button, quest);
        questButtonDictionary.Add(quest, button);
    }

    public void RemoveQuest(Button button, Quest quest) 
    {
        buttonQuestDictionary.Remove(button);
        questButtonDictionary.Remove(quest);
    }

    public Quest GetQuest(Button button)
    {
        if (!buttonQuestDictionary.ContainsKey(button))
        {
            return null;
        }
        return buttonQuestDictionary[button];
    }

    public Button GetButton(Quest quest)
    {
        if (!questButtonDictionary.ContainsKey(quest))
        {
            return null;
        }
        return questButtonDictionary[quest];
    }
}
