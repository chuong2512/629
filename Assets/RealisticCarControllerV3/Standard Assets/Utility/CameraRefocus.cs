/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class CameraRefocus
    {
        public Camera Camera;
        public Vector3 Lookatpoint;
        public Transform Parent;

        private Vector3 m_OrigCameraPos;
        private bool m_Refocus;


        public CameraRefocus(Camera camera, Transform parent, Vector3 origCameraPos)
        {
            m_OrigCameraPos = origCameraPos;
            Camera = camera;
            Parent = parent;
        }


        public void ChangeCamera(Camera camera)
        {
            Camera = camera;
        }


        public void ChangeParent(Transform parent)
        {
            Parent = parent;
        }


        public void GetFocusPoint()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Parent.transform.position + m_OrigCameraPos, Parent.transform.forward, out hitInfo,
                                100f))
            {
                Lookatpoint = hitInfo.point;
                m_Refocus = true;
                return;
            }
            m_Refocus = false;
        }


        public void SetFocusPoint()
        {
            if (m_Refocus)
            {
                Camera.transform.LookAt(Lookatpoint);
            }
        }
    }
}
