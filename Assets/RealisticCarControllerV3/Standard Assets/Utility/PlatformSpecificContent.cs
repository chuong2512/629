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
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityStandardAssets.Utility
{
#if UNITY_EDITOR

    [ExecuteInEditMode]
#endif
    public class PlatformSpecificContent : MonoBehaviour
    {
        private enum BuildTargetGroup
        {
            Standalone,
            Mobile
        }

        [SerializeField] private BuildTargetGroup m_BuildTargetGroup;
        [SerializeField] private GameObject[] m_Content = new GameObject[0];
        [SerializeField] private MonoBehaviour[] m_MonoBehaviours = new MonoBehaviour[0];
        [SerializeField] private bool m_ChildrenOfThisObject;

#if !UNITY_EDITOR
	void OnEnable()
	{
		CheckEnableContent();
	}
#endif

#if UNITY_EDITOR

        private void OnEnable()
        {
            EditorUserBuildSettings.activeBuildTargetChanged += Update;
            EditorApplication.update += Update;
        }


        private void OnDisable()
        {
            EditorUserBuildSettings.activeBuildTargetChanged -= Update;
            EditorApplication.update -= Update;
        }


        private void Update()
        {
            CheckEnableContent();
        }
#endif


        private void CheckEnableContent()
        {
#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_TIZEN || UNITY_STV )
		if (m_BuildTargetGroup == BuildTargetGroup.Mobile)
		{
			EnableContent(true);
		} else {
			EnableContent(false);
		}
#endif

#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_TIZEN || UNITY_STV )
            if (m_BuildTargetGroup == BuildTargetGroup.Mobile)
            {
                EnableContent(false);
            }
            else
            {
                EnableContent(true);
            }
#endif
        }


        private void EnableContent(bool enabled)
        {
            if (m_Content.Length > 0)
            {
                foreach (var g in m_Content)
                {
                    if (g != null)
                    {
                        g.SetActive(enabled);
                    }
                }
            }
            if (m_ChildrenOfThisObject)
            {
                foreach (Transform t in transform)
                {
                    t.gameObject.SetActive(enabled);
                }
            }
            if (m_MonoBehaviours.Length > 0)
            {
                foreach (var monoBehaviour in m_MonoBehaviours)
                {
                    monoBehaviour.enabled = enabled;
                }
            }
        }
    }
}
