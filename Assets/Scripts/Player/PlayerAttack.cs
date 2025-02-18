using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zhk.BehaviourTree;
public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimatorControl playerAnimatorControl;
    private SequenceNode ComboAttackRootTree;

    private void Awake()
    {
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();

        AttackNode Attack01 = new AttackNode(playerAnimatorControl);
        AttackNode Attack02 = new AttackNode(playerAnimatorControl);
        AttackNode Attack03 = new AttackNode(playerAnimatorControl);

        ComboAttackRootTree = new SequenceNode(3);
        ComboAttackRootTree.AttachNode(Attack01);
        ComboAttackRootTree.AttachNode(Attack02);
        ComboAttackRootTree.AttachNode(Attack03);
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        ComboAttackRootTree.Execute();
    }

    public void ResetComboAttack()
    {
        ComboAttackRootTree.ResetNode();
    }

    private class AttackNode : Node
    {
        private PlayerAnimatorControl playerAnimatorControl;

        public AttackNode(PlayerAnimatorControl playerAnimatorControl){ 
            this.playerAnimatorControl = playerAnimatorControl;
        }

        public override NodeState Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimatorControl.SetTrigger("NextCombo");
                return NodeState.SUCCESS;
            }
            if (playerAnimatorControl.CheckAnimationLength(0.6f)) //Change to when move - > Failure
            {
                playerAnimatorControl.PlayAnimation("Idle");
                Debug.Log("UH");
                return NodeState.FAILURE;
            }
            return NodeState.RUNNING;
        }
    }
}

