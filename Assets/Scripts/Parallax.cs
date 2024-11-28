using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _scrollSpeedX;
    // [SerializeField] private Transform _player;
    private Renderer _renderer;
    private Material[] _parallaxLayers;
    
    private Vector2 _offset = Vector2.right;

    private static readonly int MainTex = Shader.PropertyToID("_MainTex");
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _parallaxLayers = _renderer.materials;
    }

    private void Update()
    {
        // if (Input.GetAxisRaw("Horizontal") != 0)
        //     transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z);
        
        _offset.x = _scrollSpeedX * Time.deltaTime;
        
        for (int i = 0; i < _parallaxLayers.Length; i++)
            _parallaxLayers[i].SetTextureOffset(MainTex, 
                _parallaxLayers[i].GetTextureOffset(MainTex) + _offset / (i + 1.0f));
    }
}
