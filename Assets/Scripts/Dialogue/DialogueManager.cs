using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private PlayerInput playerInput;

    [Header("Parameters")]
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private float typingSpeed;

    [Header("Text Color")]
    [SerializeField] private Color yellow, red, blue;

    private VisualElement dialoguePanel;
    private TextElement dialogueText;
    private TextElement characterName;
    private GameObject[] UIChoices;

    public bool dialogueIsPlaying;
    private bool isSelectChoice, isFirstChoice, isDisplayLine;
    private Story currentStory;

    private const string SPEAKER_TAG = "speaker";
    private const string TEXT_COLOR_TAG = "textColor";

    private void Awake()
    {
        if (Instance == null) Instance = this;

        isSelectChoice = false; isFirstChoice = false; isDisplayLine = false;
        dialogueIsPlaying = false;
    }

    private void Start()
    {
        //for (int i = 0; i < UIChoices.Length; i++)
        //{
        //    UIChoices[i].SetActive(false);
        //}
        
        dialoguePanel = uiDocument.rootVisualElement.Q<VisualElement>("DialoguePanel");
        dialoguePanel.visible = false;

        characterName = uiDocument.rootVisualElement.Q<TextElement>("NameLabel");
        characterName.visible = false;

        dialogueText = uiDocument.rootVisualElement.Q<TextElement>("DialogueLabel");
    }

    private void Update()
    {
        if (!dialogueIsPlaying) return;
        if (isDisplayLine) return;
        if (playerInput.GetInteractPressed() && !isSelectChoice)
        {
            ContinueStory();
        }
    }

    public void EnterDialogue(TextAsset inkJson)
    {
        dialogueIsPlaying = true;
        dialoguePanel.visible = true;
        currentStory = new Story(inkJson.text);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue && !isDisplayLine)
        {
            StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogue());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        isDisplayLine = true;

        char[] lineArray = line.ToCharArray();
        for (int i = 0; i < lineArray.Length; i++)
        {
            dialogueText.text += lineArray[i];
            //SoundManager.Instance.PlaySound(SoundType.DIALOGUETEXT, 0.4f);
            yield return new WaitForSeconds(typingSpeed);
        }
        //DisplayChoice();
        isDisplayLine = false;
    }

    private void HandleTags(List<string> currentTags)
    {
        if (currentTags.Count > 0)
        {
            characterName.text = "";
            characterName.visible = true;
        }

        for (int i = 0; i < currentTags.Count; i++)
        {
            string[] splitTag = currentTags[i].Split(':');
            if (splitTag.Length != 2)
            {
                characterName.text = "";
                return;
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    characterName.text = tagValue;
                    break;
                case TEXT_COLOR_TAG:
                    if (tagValue == "yellow") characterName.style.color = yellow;
                    if (tagValue == "red") characterName.style.color = red;
                    if (tagValue == "blue") characterName.style.color = blue;
                    break;
            }
        }
    }

    //private void DisplayChoice()
    //{
    //    List<Choice> currentChoices = currentStory.currentChoices;

    //    if (currentChoices.Count > currentChoices.Count)
    //    {
    //        Debug.LogWarning("Choices out of bound, please check again your support choices.");
    //        return;
    //    }

    //    if (currentChoices.Count == 0) return;

    //    for (int i = 0; i < currentChoices.Count; i++)
    //    {
    //        UIChoices[i].SetActive(true);
    //        UIChoices[i].GetComponentInChildren<TextMeshProUGUI>().text = currentChoices[i].text;
    //        isSelectChoice = true;
    //    }

    //    StartCoroutine(SelectFirstChoice());
    //}

    //public void MakeChoice(int choiceIndex)
    //{
    //    if (choiceIndex == 0)
    //    {
    //        isFirstChoice = true;
    //    }

    //    isSelectChoice = false;
    //    currentStory.ChooseChoiceIndex(choiceIndex);
    //    ContinueStory();
    //    for (int i = 0; i < UIChoices.Length; i++)
    //    {
    //        UIChoices[i].SetActive(false);
    //    }
    //}

    private IEnumerator ExitDialogue()
    {
        yield return new WaitForSeconds(0.1f);

        dialogueIsPlaying = false;
        dialoguePanel.visible = false;
        dialogueText.text = "";

        if (isFirstChoice)
        {
            isFirstChoice = false;
            //DialogueChoiceEvent.OnChooseChoice?.Invoke();
            yield break;
        }
    }

    //private IEnumerator SelectFirstChoice()
    //{
    //    EventSystem.current.SetSelectedGameObject(null);
    //    yield return new WaitForEndOfFrame();
    //    EventSystem.current.SetSelectedGameObject(UIChoices[0].gameObject);
    //}
}