using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode()]
public class FlexibleUI : MonoBehaviour {

	public FlexibleUIData skinData;

	protected virtual void OnSkinUI()
	{

	}

	public virtual void Awake()
	{
		OnSkinUI();
	}

}