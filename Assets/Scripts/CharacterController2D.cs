using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class CharacterController2D : MonoBehaviour
{
	private Rigidbody2D m_Rigidbody2D;
	private SpellController spellController;
	private TrailRenderer trailRenderer;

	private Vector3 m_Velocity = Vector3.zero;


	[Range(0, .3f)] [SerializeField] float m_DashForce;
	[Range(0, .3f)] [SerializeField] private float m_DashDuration = .05f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

	public bool isDashing;
	 

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		spellController = GetComponent<SpellController>();
		trailRenderer = GetComponent<TrailRenderer>();
		trailRenderer.emitting = false;

	}

	public void Move(float horizontal, float vertical)
	{		
		Vector3 targetVelocity = new Vector2(horizontal * 10f, vertical * 0.5F * 10f);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
	}

	public IEnumerator Dash()
    {
		if (spellController.getCanDash())
        {
			isDashing = true;
			trailRenderer.emitting = true;
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x * m_DashForce, m_Rigidbody2D.velocity.y * m_DashForce);
			spellController.dash();
			yield return new WaitForSeconds(m_DashDuration);
			trailRenderer.emitting = false;

			isDashing = false;
		}
    }

}