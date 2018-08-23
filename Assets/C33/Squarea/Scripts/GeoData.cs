using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using C33.XR;

namespace C33.Squarea
{
    public class GeoData : MonoBehaviour
    {
        const string SHADER_NAME = "Legacy Shaders/Transparent/Diffuse";
        const float MIN_DIST = 0.05f;
        const int MIN_PNTS = 3;
        Stack<Marker> markers;
        public float area;
        public string areaString;
        Marker prefab;
        Marker previous;
        Anchor anchor;
        Marker[] markPoints;
        MeshRenderer meshRend;
        MeshFilter meshFilter;

        public GeoData(Anchor anchor, Marker prefab)
        {
            setup( anchor, prefab );
        }
        public GeoData setup( Anchor anchor, Marker prefab )
        {
            this.anchor = anchor;
            this.prefab = prefab;
            transform.SetParent( anchor.transform, true );
            return this;
        }

        private void Awake()
        {
            markers = new Stack<Marker>();
            if( !meshRend && !( meshRend = gameObject.GetComponent<MeshRenderer>() ) )
            {
                meshRend = gameObject.AddComponent<MeshRenderer>();
                Color color = Random.ColorHSV( 0, 1, 0.72f, 1, 0.9f, 1 );
                color.a = 0.75f;
                Material material = new Material(Squarea.main.areaMaterial);//new Material( Shader.Find( SHADER_NAME ) );
                material.color = color;
                meshRend.material = material;

            }
            if( !meshFilter && !( meshFilter = gameObject.GetComponent<MeshFilter>() ) )
                meshFilter = gameObject.AddComponent<MeshFilter>();
        }
        public string undoMarker()
        {
            if(previous)
                Destroy( markers.Pop().gameObject );
            markPoints = markers.ToArray();
            System.Array.Reverse( markPoints );
            previous = markers.Peek();
            return areaString = evalArea();
        }

        public bool addMarker(Vector3 position)
        {
            if(previous)
            {
                if( Vector3.Distance( position, previous.transform.position ) < MIN_DIST )
                    return false;
            }
            markers.Push( Instantiate( prefab,transform,true ) );
            markers.Peek().setup( position, previous );
            markPoints = markers.ToArray();
            System.Array.Reverse( markPoints );
            areaString = evalArea();
            previous = markers.Peek();
            return true;
        }
        public string reEval()
        {
            foreach(Marker m in markPoints)
            {
                m.setDistance();
            }
            return areaString = evalArea();
        }

        public string evalArea()
        {
            string s = "";
            if( markPoints.Length < MIN_PNTS || markPoints == null )
            {
                area = 0;
            }
            else
            {
                area = SuperficieIrregularPolygon( markPoints );
                s = Units.convert( area, true );
            }
            StartCoroutine( "drawMesh" );
            return s;
        }

        IEnumerator drawMesh()
        {
            Mesh mesh = new Mesh();
            int n = markPoints.Length;
            if(n < MIN_PNTS )
            {
                meshFilter.mesh = mesh;
                yield return null;
            }

            Vector3[] realVert = new Vector3[n];
            Vector2[] flatVert = new Vector2[n];
            Vector2[] uvs = new Vector2[n];//TODO: uvs are all wrong
            Vector2 origin = new Vector2();
            float rot = 0;
            for( int i = 0; i < n; i++ )
            {
                realVert[i] = markPoints[i].transform.position;
                flatVert[i] = new Vector2( realVert[i].x, realVert[i].z );
                if(i==0)
                {
                    origin = flatVert[0];
                    uvs[0] = new Vector2();
                    continue;
                }
                else if(i==1)
                {
                    rot = Vector2.Angle( Vector2.right, flatVert[1] - origin );
                }
                uvs[i] = Quaternion.Euler(0, 0, rot ) * ( flatVert[i] - origin );
                uvs[i] *= Units.alphaFactor;
            }
            Triangulator tr = new Triangulator(flatVert);
            int[] indices = tr.Triangulate();
            mesh.vertices = realVert;
            mesh.triangles = indices;
            mesh.uv = uvs;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            meshFilter.mesh = mesh;
        }

        public static float SuperficieIrregularPolygon( MonoBehaviour[] vertex )
        {
            float temp = 0;
            int i = 0;
            for( ; i < vertex.Length; i++ )
            {
                if( i != vertex.Length - 1 )
                {
                    float mulA = vertex[i].transform.position.x * vertex[i+1].transform.position.z;
                    float mulB = vertex[i+1].transform.position.x * vertex[i].transform.position.z;
                    temp = temp + ( mulA - mulB );
                }
                else
                {
                    float mulA = vertex[i].transform.position.x * vertex[0].transform.position.z;
                    float mulB = vertex[0].transform.position.x * vertex[i].transform.position.z;
                    temp = temp + ( mulA - mulB );
                }
            }
            temp *= 0.5f;
            Main.Log( temp.ToString() );
            return Mathf.Abs( temp );
        }
    }
}