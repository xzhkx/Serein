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

        AttackNode Attack01 = new AttackNode(playerAnimatorControl, "Attack01");
        AttackNode Attack02 = new AttackNode(playerAnimatorControl, "Attack02");
        AttackNode Attack03 = new AttackNode(playerAnimatorControl, "Attack03");

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
        private string animationName;

        public AttackNode(PlayerAnimatorControl playerAnimatorControl, string animationName)
        {
            this.playerAnimatorControl = playerAnimatorControl;
            this.animationName = animationName;
        }

        public override NodeState Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimatorControl.PlayAnimation(animationName);
                playerAnimatorControl.SetTriggerNextComboAttack();
                return NodeState.SUCCESS;
            }
            if (playerAnimatorControl.CheckAnimationLength(0.6f)) 
            {
                playerAnimatorControl.SetIdle(true);
                return NodeState.FAILURE;
            }
            return NodeState.RUNNING;
        }
    }
}

