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
            /// 부드럽게 움직이게 하는 컨트롤
            /// </summary>
            MoveAndStrafe,

            /// <summary>
            /// 텔레포트 형식으로 움직이는 컨트롤
            /// </summary>
            TeleportAndTurn,
        }

        public enum TurnStyle
        {
            /// <summary>
            /// Snap형식의 플레이어의 화면 돌림 형식
            /// </summary>
            Snap,

            /// <summary>
            /// 부드럽게 움직이게 하는 플레이어의 화면 돌림 형식
            /// </summary>
            Smooth,
        }

        [SerializeField]
        [Tooltip("Stores the locomotion provider for smooth (continuous) movement.")]
        DynamicMoveProvider m_DynamicMoveProvider;

        //프로퍼티
        public DynamicMoveProvider DynamicMoveProvider
        {
            get => m_DynamicMoveProvider;
            set => m_DynamicMoveProvider = value;
        }
    }
}