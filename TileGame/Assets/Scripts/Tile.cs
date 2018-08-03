using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{

    public class Tile
    {
        Color normalColor;
        GameObject gameObject;
        Terrain terrain;
        static Color selectColor = Color.red;

        public Tile()
        {

        }

        public Tile(Terrain terrain)
        {
            this.terrain = terrain;
        }

        public GameObject GameObject
        {
            get
            {
                return gameObject;
            }
        }

        public GameObject Instantiate(int x, int y)
        {
            gameObject = GameObject.Instantiate(terrain.prefab, new Vector3(x, 0, y), new Quaternion(0, 0, 0, 0));
            gameObject.name = string.Join("-", new string[] { "tile", x.ToString(), y.ToString() });
            terrain.Color = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
            return gameObject;
        }

        public void Select()
        {
            MeshRenderer mr;
            mr = GameObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = selectColor;
        }

        public void Unselect()
        {
            MeshRenderer mr;
            mr = GameObject.gameObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = terrain.Color;
        }
    }
}
