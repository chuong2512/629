/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2016 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class RCC_LabelEditor {

	public enum LabelIcon {
		Gray = 0,
		Blue,
		Teal,
		Green,
		Yellow,
		Orange,
		Red,
		Purple
	}

	public enum Icon {
		CircleGray = 0,
		CircleBlue,
		CircleTeal,
		CircleGreen,
		CircleYellow,
		CircleOrange,
		CircleRed,
		CirclePurple,
		DiamondGray,
		DiamondBlue,
		DiamondTeal,
		DiamondGreen,
		DiamondYellow,
		DiamondOrange,
		DiamondRed,
		DiamondPurple
	}

	private static GUIContent[] labelIcons;
	private static GUIContent[] largeIcons;

	public static void SetIcon( GameObject gObj, LabelIcon icon ) {
		if ( labelIcons == null ) {
			labelIcons = GetTextures( "sv_label_", string.Empty, 0, 8 );
		}

		SetIcon( gObj, labelIcons[(int)icon].image as Texture2D );
	}

	public static void SetIcon( GameObject gObj, Icon icon ) {
		if ( largeIcons == null ) {
			largeIcons = GetTextures( "sv_icon_dot", "_pix16_gizmo", 0, 16 );
		}

		SetIcon( gObj, largeIcons[(int)icon].image as Texture2D );
	}

	private static void SetIcon( GameObject gObj, Texture2D texture ) {
		var ty = typeof( EditorGUIUtility );
		var mi = ty.GetMethod( "SetIconForObject", BindingFlags.NonPublic | BindingFlags.Static );
		mi.Invoke( null, new object[] { gObj, texture } );
	}

	private static GUIContent[] GetTextures( string baseName, string postFix, int startIndex, int count ) {
		GUIContent[] guiContentArray = new GUIContent[count];

		var t = typeof( EditorGUIUtility );
		var mi = t.GetMethod( "IconContent", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof( string ) }, null );

		for ( int index = 0; index < count; ++index ) {
			guiContentArray[index] = mi.Invoke( null, new object[] { baseName + (object)(startIndex + index) + postFix } ) as GUIContent;
		}

		return guiContentArray;
	}
}
