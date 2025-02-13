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
        ComboAttackRootTree.Execute();
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
                return NodeState.SUCCESS;
            }
            if (!Input.GetMouseButtonDown(0)) //-> Check animation Time
            {
                playerAnimatorControl.SetIdle(true);
                return NodeState.FAILURE;
            }
            else return NodeState.RUNNING;
        }
    }
}

