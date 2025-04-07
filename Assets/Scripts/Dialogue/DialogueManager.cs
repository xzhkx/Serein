using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using Ink.Runtime;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public Action FinishDialogueEvent;

    [SerializeField] 
    private PlayerInput playerInput;

    [Header("Parameters")]

    [SerializeField] 
    private UIDocument uiDocument;

    [SerializeField] 
    private float typingSpeed;

    [Header("Text Color")]

    [SerializeField] 
    private Color yellow, red, blue;

    private CutSceneAnimatorControl cutSceneAnimatorControl;

    private VisualElement dialoguePanel;
    private TextElement dialogueText;
    private TextElement characterName;
    private List<Button> UIChoices = new List<Button>(2);
    private Dictionary<Button, int> choiceIndexDictionary = new Dictionary<Button, int>(2);

    public bool dialogueIsPlaying;
    private bool isSelectChoice, isFirstChoice, isDisplayLine;
    private Story currentStory;

    private const string SPEAKER_TAG = "speaker";
    private const string TEXT_COLOR_TAG = "textColor";
    private const string ANIM_TAG = "anim";
    private const string CUTSCENE_TAG = "cs";

    private void Awake()
    {
        if (Instance == null) Instance = this;

        cutSceneAnimatorControl = GetComponent<CutSceneAnimatorControl>();
        isSelectChoice = false; isFirstChoice = false; isDisplayLine = false;
        dialogueIsPlaying = false;
    }

    private void Start()
    {      
        dialoguePanel = uiDocument.rootVisualElement.Q<VisualElement>("DialoguePanel");
        dialoguePanel.style.display = DisplayStyle.None;

        characterName = uiDocument.rootVisualElement.Q<TextElement>("NameLabel");

        dialogueText = uiDocument.rootVisualElement.Q<TextElement>("DialogueLabel");

        UIChoices = uiDocument.rootVisualElement.Query<Button>("ChoiceButton").ToList();
        for (int i = 0; i < UIChoices.Count; i++)
        {
            UIChoices[i].RegisterCallback<ClickEvent>(MakeChoice);
            UIChoices[i].style.display = DisplayStyle.None;
            choiceIndexDictionary.Add(UIChoices[i], i);
        }
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
        dialoguePanel.style.display = DisplayStyle.Flex;
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
        DisplayChoice();
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
                case ANIM_TAG:

                    break;
                case CUTSCENE_TAG:
                    cutSceneAnimatorControl.PlayAnimation(tagValue);
                    break;
            }
        }
    }

    private void DisplayChoice()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > currentChoices.Count)
        {
            Debug.LogWarning("Choices out of bound, please check again your support choices.");
            return;
        }

        if (currentChoices.Count == 0) return;

        for (int i = 0; i < currentChoices.Count; i++)
        {
            UIChoices[i].style.display = DisplayStyle.Flex;
            UIChoices[i].text = currentChoices[i].text;
            isSelectChoice = true;
        }
    }

    public void MakeChoice(ClickEvent clickEvent)
    {
        Button button = clickEvent.target as Button;
        int index = choiceIndexDictionary[button];

        isSelectChoice = false;
        currentStory.ChooseChoiceIndex(index);
        ContinueStory();
        for (int i = 0; i < UIChoices.Count; i++)
        {
            UIChoices[i].style.display = DisplayStyle.None;
        }
    }

    private IEnumerator ExitDialogue()
    {
        yield return new WaitForSeconds(0.1f);

        dialogueIsPlaying = false;
        dialoguePanel.style.display = DisplayStyle.None;
        dialogueText.text = string.Empty;

        FinishDialogueEvent?.Invoke();

        if (isFirstChoice) //neu chon firstChoice thi
        {
            isFirstChoice = false;
            //DialogueChoiceEvent.OnChooseChoice?.Invoke();
            yield break;
        }
    }
}