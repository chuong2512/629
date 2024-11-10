/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlphaButtonClickMask : MonoBehaviour, ICanvasRaycastFilter 
{
    protected Image _image;

    public void Start()
    {
        _image = GetComponent<Image>();

        Texture2D tex = _image.sprite.texture as Texture2D;

        bool isInvalid = false;
        if (tex != null)
        {
            try
            {
                tex.GetPixels32();
            }
            catch (UnityException e)
            {
                Debug.LogError(e.Message);
                isInvalid = true;
            }
        }
        else
        {
            isInvalid = true;
        }

        if (isInvalid)
        {
            Debug.LogError("This script need an Image with a readbale Texture2D to work.");
        }
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_image.rectTransform, sp, eventCamera, out localPoint);

        Vector2 normalizedLocal = new Vector2(1.0f + localPoint.x / _image.rectTransform.rect.width, 1.0f + localPoint.y / _image.rectTransform.rect.height);
        Vector2 uv = new Vector2(
            _image.sprite.rect.x + normalizedLocal.x * _image.sprite.rect.width, 
            _image.sprite.rect.y + normalizedLocal.y * _image.sprite.rect.height );

        uv.x /= _image.sprite.texture.width;
        uv.y /= _image.sprite.texture.height;

        //uv are inversed, as 0,0 or the rect transform seem to be upper right, then going negativ toward lower left...
        Color c = _image.sprite.texture.GetPixelBilinear(uv.x, uv.y);

        return c.a> 0.1f;
    }
}
