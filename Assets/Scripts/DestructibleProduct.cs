using System;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Collider))]
public class DestructibleProduct : MonoBehaviour
{
	[SerializeField] private AudioClip m_clip;
	[SerializeField] private AudioSource m_audioSource;
	[SerializeField] private MeshRenderer m_meshRenderer;
	[SerializeField] private MeshFilter m_meshFilter;
	[SerializeField] private Collider m_collider;

	[BoxGroup("Options")]
	[SerializeField, MinMaxSlider(100, 1000)] private Vector2 m_force = new Vector2(100,200);

	[BoxGroup("Options")]
	[SerializeField] private float m_destroyPieceAfterSecounds = 2;

	[BoxGroup("Options")]
	[SerializeField] private int m_maxPieces = 5;

	private void OnEnable()
	{
		m_meshFilter = GetComponent<MeshFilter>();
		m_meshRenderer = GetComponent<MeshRenderer>();
		m_collider = GetComponent<Collider>();
	}

	private void Awake()
	{
		m_meshFilter = GetComponent<MeshFilter>();
		m_meshRenderer = GetComponent<MeshRenderer>();
		m_collider = GetComponent<Collider>();
	}

	[Button()]
	public void DestructProduct()
	{
		if (!EditorApplication.isPlaying)
		{
			Debug.LogError("Better don't destroy at yet, you should enter the play mode!");
			return;
		}

		if (m_meshFilter == null || m_meshRenderer == null)
		{
			return;
		}

		if (m_collider)
		{
			m_collider.enabled = false;
		}

		var originMesh = new Mesh();
		if (m_meshFilter)
		{
			originMesh = m_meshFilter.mesh;
		}


		var materials = m_meshRenderer.materials;

		var vertices = originMesh.vertices;
		var normals = originMesh.normals;
		var uvs = originMesh.uv;
		var pieceCount = 0;

		for (var submesh = 0; submesh < originMesh.subMeshCount; submesh++)
		{
			var indices = originMesh.GetTriangles(submesh);

			for (var i = 0; i < indices.Length; i += 3)
			{
				if (pieceCount == m_maxPieces) break;

				var newVertices = new Vector3[3];
				var newNormals = new Vector3[3];
				var newUvs = new Vector2[3];
				for (var n = 0; n < 3; n++)
				{
					var index = indices[i + n];
					newVertices[n] = vertices[index];
					newUvs[n] = uvs[index];
					newNormals[n] = normals[index];
				}

				var mesh = new Mesh
				{
					vertices = newVertices,
					normals = newNormals,
					uv = newUvs,
					triangles = new int[] {0, 1, 2, 2, 1, 0}
				};


				var piece = new GameObject("ProductPiece");
				piece.transform.position = transform.position;
				piece.transform.rotation = transform.rotation;
				piece.AddComponent<MeshRenderer>().material = materials[submesh];
				piece.AddComponent<MeshFilter>().mesh = mesh;
				var collider = piece.AddComponent<BoxCollider>();
				var size = collider.size;
				size.z = 0.3f;
				collider.size = size;
				var explosionPos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f),
											   transform.position.y + Random.Range(0f, 0.5f),
											   transform.position.z +
											   Random.Range(-0.5f, 0.5f));
				piece.AddComponent<Rigidbody>()
					 .AddExplosionForce(Random.Range(m_force.x, m_force.y), explosionPos, 5);
				Destroy(piece, m_destroyPieceAfterSecounds);
				pieceCount++;
			}
		}
		m_audioSource.PlayOneShot(m_clip);
		if (GetComponent<OVRGrabbable>().grabbedBy != null)
		{
			GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(GetComponent<OVRGrabbable>());
		}

		m_meshRenderer.enabled = false;
		Destroy(gameObject);
	}
}