using UnityEngine;
using zhk.BehaviourTree;
public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimatorControl playerAnimatorControl;
    private SequenceNode ComboAttackRootTree;
    private PlayerInput playerInput;

    private Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimatorControl = GetComponent<PlayerAnimatorControl>();
        playerInput = GetComponent<PlayerInput>();

        AttackNode Attack = new AttackNode(playerAnimatorControl, playerInput);

        ComboAttackRootTree = new SequenceNode(3);
        ComboAttackRootTree.AttachNode(Attack);
        ComboAttackRootTree.AttachNode(Attack);
        ComboAttackRootTree.AttachNode(Attack);
    }

    private void Update()
    {
        if (playerRigidbody.velocity.y != 0)
        {
            return;
        }
        ComboAttackRootTree.Execute();
    }

    public void ResetComboAttack()
    {
        ComboAttackRootTree.ResetNode();
    }

    private class AttackNode : Node
    {
        private PlayerAnimatorControl playerAnimatorControl;
        private PlayerInput playerInput;

        public AttackNode(PlayerAnimatorControl playerAnimatorControl, PlayerInput playerInput){ 
            this.playerAnimatorControl = playerAnimatorControl;
            this.playerInput = playerInput;
        }

        public override NodeState Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimatorControl.SetTrigger("NextCombo");
                return NodeState.SUCCESS;
            }
            if (playerInput.GetPlayerMovementInput() != Vector2.zero) 
            {
                playerAnimatorControl.SetTrigger("RunTrigger");
                return NodeState.FAILURE;
            }

            return NodeState.RUNNING;
        }
    }
}

