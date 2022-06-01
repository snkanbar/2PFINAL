using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook2
    {
        public float XSensitivity02 = 20f;
        public float YSensitivity02 = 20f;
        public bool clampVerticalRotation02 = true;
        public float MinimumX02 = -90F;
        public float MaximumX02 = 90F;
        public bool smooth02;
        public float smoothTime02 = 5f;
        public bool lockCursor02 = true;


        private Quaternion m_CharacterTargetRot02;
        private Quaternion m_CameraTargetRot02;
        private bool m_cursorIsLocked02 = true;

        public void Init02(Transform character, Transform camera)
        {
            m_CharacterTargetRot02 = character.localRotation;
            m_CameraTargetRot02 = camera.localRotation;
        }


        public void LookRotation02(Transform character, Transform camera)
        {
            float yRot02 = CrossPlatformInputManager.GetAxis("RightJoyX2") * YSensitivity02;
            float xRot02 = CrossPlatformInputManager.GetAxis("RightJoyY2") * XSensitivity02;
            
            m_CharacterTargetRot02 *= Quaternion.Euler (0f, yRot02, 0f);
            m_CameraTargetRot02 *= Quaternion.Euler (xRot02, 0f, 0f);

            if (clampVerticalRotation02)
                m_CameraTargetRot02 = ClampRotationAroundXAxis02(m_CameraTargetRot02);

            if(smooth02)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot02,
                    smoothTime02 * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot02,
                    smoothTime02 * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot02;
                camera.localRotation = m_CameraTargetRot02;
            }

            UpdateCursorLock02();
        }

        public void SetCursorLock02(bool value)
        {
            lockCursor02 = value;
            if(!lockCursor02)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock02()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor02)
                InternalLockUpdate02();
        }

        private void InternalLockUpdate02()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked02 = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked02 = true;
            }

            if (m_cursorIsLocked02)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked02)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis02(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX02, MaximumX02);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
