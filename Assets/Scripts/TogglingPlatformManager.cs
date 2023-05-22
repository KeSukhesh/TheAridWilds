using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglingPlatformManager : MonoBehaviour
{

	// This script got improved DRASTICALLY and is no longer used for platforms but that was the initial goal for the script, now it just toggles text.
	[SerializeField]
	GameObject[] platforms; // Array of platforms this manager will control

	int numberOfPlatforms; // How many platforms this manager controls

	public float toggleTime; // Time till the platform wll toggle

	public float cycleTime = 2f; // Rate at which platforms under this manager toggle at

	// Use this for initialization
	void Start()
	{
		numberOfPlatforms = platforms.Length; // Ammount of platofrms = biggest index in array of platforms

		if (numberOfPlatforms - 1 == 0) // Countdown till toggle
			toggleTime = 1;
		else
			toggleTime = numberOfPlatforms - 1; // Countdown till toggle

		StartCoroutine(StartManagingPlatforms()); // using IEnumerator for in built waitforseconds function
	}

	IEnumerator StartManagingPlatforms()
	{
		for (int i = 0; i < numberOfPlatforms; i++) // For the current index of the platforms array
		{
			StartCoroutine(ManagePlatform(platforms[i])); // Call our toggler function
			yield return new WaitForSeconds(cycleTime); // Wait this many seconds
		}
	}

	IEnumerator ManagePlatform(GameObject platform)
	{
		while (true)
		{
			platform.SetActive(true); // Set the platform's gameobject active
			yield return new WaitForSeconds(cycleTime); // Wait for the ammount of specificed time
			platform.SetActive(false); // Disable the paltform's gameobject
			yield return new WaitForSeconds(toggleTime * cycleTime); // Wait for this many seconds before going again (While true)
		}
	}

}
