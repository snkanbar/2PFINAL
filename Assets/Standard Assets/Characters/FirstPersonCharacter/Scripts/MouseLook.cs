using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity01 = 20f;
        public float YSensitivity01 = 20f;
        public bool clampVerticalRotation01 = true;
        public float MinimumX01 = -90F;
        public float MaximumX01 = 90F;
        public bool smooth01;
        public float smoothTime01 = 5f;
        public bool lockCursor01 = true;


        private Quaternion m_CharacterTargetRot01;
        private Quaternion m_CameraTargetRot01;
        private bool m_cursorIsLocked01 = true;

        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot01 = character.localRotation;
            m_CameraTargetRot01 = camera.localRotation;
        }


        public void LookRotation(Transform character, Transform camera, string joyX, string joyY)
        {
            float yRot01 = CrossPlatformInputManager.GetAxis(joyX) * YSensitivity01;
            float xRot01 = CrossPlatformInputManager.GetAxis(joyY) * XSensitivity01;

            m_CharacterTargetRot01 *= Quaternion.Euler (0f, yRot01, 0f);
            m_CameraTargetRot01 *= Quaternion.Euler (xRot01, 0f, 0f);

            if(clampVerticalRotation01)
                m_CameraTargetRot01 = ClampRotationAroundXAxis (m_CameraTargetRot01);

            if(smooth01)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot01,
                    smoothTime01 * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot01,
                    smoothTime01 * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot01;
                camera.localRotation = m_CameraTargetRot01;
            }

            UpdateCursorLock();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor01 = value;
            if(!lockCursor01)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor01)
                InternalLockUpdate();
        }

        private void InternalLockUpdate()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked01 = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked01 = true;
            }

            if (m_cursorIsLocked01)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked01)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX01, MaximumX01);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
