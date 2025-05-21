using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using Ink.Runtime;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public Action FirstChoiceEvent;
    public Action StartDialogueEvent, FinishDialogueEvent;
    public Action FreezePlayerAction, EnablePlayerAction;

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
    private CharacterAnimators characterAnimators;
    private Animator currentAnimator;
    private FadePresenter fadePresenter;

    private VisualElement dialoguePanel;
    private TextElement dialogueText;
    private TextElement characterName;
    private List<Button> UIChoices = new List<Button>(3);
    private Dictionary<Button, int> choiceIndexDictionary = new Dictionary<Button, int>(3);

    public bool dialogueIsPlaying;
    private bool isSelectChoice, isFirstChoice, isDisplayLine;
    private Story currentStory;

    private const string SPEAKER_TAG = "speaker";
    private const string TEXT_COLOR_TAG = "textColor";
    private const string ANIMATORID_TAG = "animatorID";
    private const string ANIM_TAG = "anim";
    private const string CUTSCENE_TAG = "cs";

    private WaitForSeconds waitForSeconds1;
    private WaitForSeconds waitForSeconds0_5;
    private WaitForSeconds waitForSeconds0_1;
    private WaitForSeconds waitForTypingSpeed;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        characterAnimators = GetComponent<CharacterAnimators>();

        cutSceneAnimatorControl = GetComponent<CutSceneAnimatorControl>();
        cutSceneAnimatorControl.DisableCamera();

        isSelectChoice = false; isFirstChoice = false; isDisplayLine = false;
        dialogueIsPlaying = false;

        waitForSeconds1 = new WaitForSeconds(1);
        waitForSeconds0_5 = new WaitForSeconds(0.5f);
        waitForSeconds0_1 = new WaitForSeconds(0.1f);
        waitForTypingSpeed = new WaitForSeconds(typingSpeed);
    }

    private void Start()
    {
        fadePresenter = FadePresenter.Instance;

        characterName = uiDocument.rootVisualElement.Q<TextElement>("NameLabel");
        dialogueText = uiDocument.rootVisualElement.Q<TextElement>("DialogueLabel");

        UIChoices = uiDocument.rootVisualElement.Query<Button>("ChoiceButton").ToList();
        for (int i = 0; i < UIChoices.Count; i++)
        {
            UIChoices[i].RegisterCallback<ClickEvent>(MakeChoice);
            UIChoices[i].style.display = DisplayStyle.None;
            choiceIndexDictionary.Add(UIChoices[i], i);
        }

        dialoguePanel = uiDocument.rootVisualElement.Q<VisualElement>("DialoguePanel");
        dialoguePanel.visible = false;
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
        StartCoroutine(StartDialogue(inkJson));
    }

    private IEnumerator StartDialogue(TextAsset inkJson)
    {
        fadePresenter.PlayFadeAnimation();
        yield return waitForSeconds0_5;

        dialogueIsPlaying = true;
        dialoguePanel.visible = true;
        currentStory = new Story(inkJson.text);

        StartDialogueEvent?.Invoke();
        FreezePlayerAction?.Invoke();
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
        dialogueText.text = string.Empty;
        isDisplayLine = true;

        char[] lineArray = line.ToCharArray();
        for (int i = 0; i < lineArray.Length; i++)
        {
            dialogueText.text += lineArray[i];
            yield return waitForTypingSpeed;
        }
        DisplayChoice();
        isDisplayLine = false;
    }

    private void HandleTags(List<string> currentTags)
    {
        if (currentTags.Count > 0)
        {
            characterName.text = "";
            characterName.style.display = DisplayStyle.Flex;
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
                case ANIMATORID_TAG:
                    currentAnimator = characterAnimators.GetCurrentAnimator(int.Parse(tagValue));
                    break;
                case ANIM_TAG:
                    currentAnimator.Play(tagValue);
                    break;
                case CUTSCENE_TAG:
                    cutSceneAnimatorControl.EnableCamera();
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
        if(index == 0)
        {
            isFirstChoice = true;
        } else isFirstChoice = false;

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
        yield return waitForSeconds0_1;

        dialogueText.text = string.Empty;
        dialoguePanel.visible = false;

        fadePresenter.PlayFadeAnimation();
        yield return waitForSeconds1;
        cutSceneAnimatorControl.DisableCamera();

        FinishDialogueEvent?.Invoke();
        EnablePlayerAction?.Invoke();

        dialogueIsPlaying = false;

        if (isFirstChoice)
        {
            isFirstChoice = false;
            FirstChoiceEvent?.Invoke();
            yield break;
        }
    }
}