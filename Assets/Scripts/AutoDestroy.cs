using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	// 当离开摄像头可视范围时触发的事件
	void OnBecameInvisible()
	{
		// 销毁当前游戏对象
		Destroy(this.gameObject);
	}
}
