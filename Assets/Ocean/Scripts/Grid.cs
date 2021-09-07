using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Unprogressed.Ocean
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(BoxCollider))]
    [RequireComponent(typeof(MovementInWater), typeof(Volume))]
    class Grid : MonoBehaviour
    {
        [SerializeField] private int _xSize, _zSize;
        [SerializeField] private int yHeight;
        [SerializeField] private Material _material;
        [SerializeField] private int _cellSize;
        [SerializeField] private float _oceanDepth;
        [SerializeField] private LayerMask _layer;
        private Vector3 _center;

        private void Awake()
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            gameObject.layer = 4;
            _center = new Vector3((_xSize * _cellSize) / 2, yHeight, (_zSize * _cellSize) / 2);
            GenerateGrid();
            transform.position -= _center;
            collider.isTrigger = true;
            collider.center = _center + Vector3.down * (_oceanDepth / 2);
            collider.size = new Vector3(_xSize * _cellSize, _oceanDepth, _zSize * _cellSize);
        }
        private void GenerateGrid()
        {
            Mesh _mesh = GetComponent<MeshFilter>().mesh = new Mesh();
            _mesh.name = "Ocean Grid";
            GetComponent<MeshRenderer>().material = _material;
            Vector3[] _vertecies = new Vector3[(_xSize + 1) * (_zSize + 1)];
            int[] _triangles = new int[_xSize * _zSize * 6];
            Vector2[] _uv = new Vector2[_vertecies.Length];
            Vector4[] _tangents = new Vector4[_vertecies.Length];
            Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
            for (int z = 0, i = 0; z <= _zSize; z++)
            {
                for (int x = 0; x <= _xSize; x++, i++)
                {
                    _vertecies[i] = new Vector3(x * _cellSize, yHeight, z * _cellSize);
                    _uv[i] = new Vector2((float)x / _xSize, (float)z / _zSize);
                    //_uv[i] = new Vector2(x, z);
                    _tangents[i] = tangent;
                }
            }
            _mesh.vertices = _vertecies;
            for (int z = 0, ti = 0, vi = 0; z < _zSize; z++, vi++)
            {
                for (int x = 0; x < _xSize; x++, ti += 6, vi++)
                {
                    _triangles[ti] = vi;
                    _triangles[ti + 2] = _triangles[ti + 3] = vi + 1;
                    _triangles[ti + 4] = _triangles[ti + 1] = vi + _xSize + 1;
                    _triangles[ti + 5] = vi + _xSize + 2;
                }
            }
            _mesh.triangles = _triangles;
            _mesh.RecalculateNormals();
            _mesh.uv = _uv;
            _mesh.tangents = _tangents;
        }
        //private void OnDrawGizmos()
        //{
        //    if (_vertecies == null)
        //    {
        //        return;
        //    }
        //    Gizmos.color = Color.black;
        //    int i = 0;
        //    foreach (Vector3 v in _vertecies)
        //    {
        //        //Gizmos.DrawSphere(v, 0.1f);
        //        Gizmos.DrawLine(v, _mesh.normals[i]);
        //        i++;
        //    }
        //}
    }
}
