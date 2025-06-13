using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Gravity;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Turning;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace UnityEngine.XR.Content.Interaction
{
    public class LocomotionManager : MonoBehaviour
    {
        public enum LocomotionType
        {
            /// <summary>
            /// �ε巴�� �����̰� �ϴ� ��Ʈ��
            /// </summary>
            MoveAndStrafe,

            /// <summary>
            /// �ڷ���Ʈ �������� �����̴� ��Ʈ��
            /// </summary>
            TeleportAndTurn,
        }

        public enum TurnStyle
        {
            /// <summary>
            /// Snap������ �÷��̾��� ȭ�� ���� ����
            /// </summary>
            Snap,

            /// <summary>
            /// �ε巴�� �����̰� �ϴ� �÷��̾��� ȭ�� ���� ����
            /// </summary>
            Smooth,
        }

        [SerializeField]
        [Tooltip("Stores the locomotion provider for smooth (continuous) movement.")]
        DynamicMoveProvider m_DynamicMoveProvider;

        //������Ƽ
        public DynamicMoveProvider DynamicMoveProvider
        {
            get => m_DynamicMoveProvider;
            set => m_DynamicMoveProvider = value;
        }
    }
}