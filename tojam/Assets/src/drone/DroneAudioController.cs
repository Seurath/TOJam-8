using UnityEngine;
using System.Collections;

public class DroneAudioController : MonoBehaviour
{

	[SerializeField] private AudioSource bulletSound;
	[SerializeField] private AudioSource deathSound;
	
	public void PlayBulletSound ()
	{
		this.bulletSound.Play();
	}
	
	public void PlayDeathSound ()
	{
		this.deathSound.Play();
	}
	
}

