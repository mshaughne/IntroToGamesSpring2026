using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimation : MonoBehaviour
{
	[SerializeField] Animator animator;

	[Header("Audio")]
	[SerializeField] AudioSource src;
	[SerializeField] AudioClip jumpSound, pressSound, releaseSound;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown("Jump"))
		{
			//src.clip = pressSound;
			//src.Play();
			AudioSource.PlayClipAtPoint(pressSound, transform.position, 1f);

			animator.SetBool("isSpaceBarHeld", true);
		}
		else if (Input.GetButtonUp("Jump"))
		{
            //src.clip = releaseSound;
            //src.Play();
            AudioSource.PlayClipAtPoint(releaseSound, transform.position, 1f);

            animator.SetBool("isSpaceBarHeld", false);
		}
	}

	public void PlaySound()
	{
		src.clip = jumpSound;
		src.Play();
	}
}
