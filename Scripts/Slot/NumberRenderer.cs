using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumberRenderer : MonoBehaviour {

	[SerializeField]
	private List<SpriteNumber> listDigit;//0 more significant ...
	
	public void RenderNumber(int aNum)
	{
		if (aNum < 0 || aNum > 99)
		{
			Debug.LogError("Can not submit negative numbers or triple digits");
			Debug.Break();
			return;
		}
		//Get Lengths
		int length = aNum.ToString ().Length;
		char[] strNum = aNum.ToString ().ToCharArray ();
	
		//Check to see if there is enough numbers to render the incoming number
		for (int i = 0; i < length;i++)
		{
			if (aNum<10)
			{
				if(i<length-1){
					listDigit[i].SetNumber(0);
				}else{
					listDigit[i].SetNumber(aNum);
				}
			}else{
				listDigit[i].SetNumber(int.Parse(strNum[i].ToString()));
			}
		}
	}
}
