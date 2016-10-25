using UnityEngine;
using System.Collections;

public class InitScene : MonoBehaviour
{
	private GameObject goPlane;

	// Use this for initialization
	void Start()
	{
		// 获取Plane对象
		goPlane = GameObject.Find("Plane");
		// 初始化4*4个箱子群
		CreateCubes();
	}

	void CreateCubes()
	{
		// 创建4*4个Cube立方体作为箱子
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				GameObject goCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				goCube.transform.position = new Vector3(i - 1, j, -1);
				// 增加刚体组件使其具有重力
				goCube.AddComponent<Rigidbody>();
				// 增加脚本使对象自动销毁
				goCube.AddComponent<AutoDestroy>();
				// 增加渲染贴图
				goCube.renderer.material.mainTexture =
					Resources.LoadAssetAtPath("Assets/Images/CubeImage.jpg", typeof(Texture)) as Texture;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		// 控制Sphere朝着鼠标指定的坐标发起冲击
		if (Input.GetMouseButtonDown(0))
		{
			// 创建要发出的小球Sphere
			GameObject goBullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			goBullet.transform.position = Camera.main.transform.position;
			goBullet.AddComponent<Rigidbody>();
			goBullet.AddComponent<AutoDestroy>();
			goBullet.renderer.material.mainTexture =
				Resources.LoadAssetAtPath("Assets/Images/AngryBird.jpg", typeof(Texture)) as Texture;

			// 获取目标位置的世界坐标
			Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
				Input.mousePosition.y, 3));
			Vector3 dirPos = targetPos - Camera.main.transform.position;

			// 进击吧！疯狂的小球！
			goBullet.rigidbody.AddForce(dirPos * 10, ForceMode.Impulse);

			// 播放爆炸音效
			goPlane.GetComponent<AudioSource>().Play();
		}
	}

	void OnGUI()
	{
		GUILayout.Label("欢迎试玩 CrazySphere（疯狂击箱子）游戏");
	}
}
