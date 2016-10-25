using UnityEngine;
using System.Collections;

public class ScreenCursor : MonoBehaviour
{
	//3D贴图是Material,2D贴图是Texture
	public Texture CurosrTexture;
	// Use this for initialization
	void Start()
	{
		// 禁止显示鼠标指针
		Screen.showCursor = false;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnGUI()
	{
		// 计算图片左上角的坐标
		float left = Input.mousePosition.x - CurosrTexture.width / 2;
		float top = Screen.height - Input.mousePosition.y - CurosrTexture.height / 2;

		GUI.DrawTexture(new Rect(left, top, CurosrTexture.width, CurosrTexture.height), CurosrTexture);
	}
}
