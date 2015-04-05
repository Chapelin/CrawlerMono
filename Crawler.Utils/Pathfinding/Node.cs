using System;
using Microsoft.Xna.Framework;

namespace Crawler.Utils.Pathfinding
{
    public class Node
    {
        private Node _parent;
        private int _G;
        private int _H;
        public Vector2 pos;
        public bool Obstacle;


        public Node(int x, int y, bool ob = false)
        {
            this.Parent = null;
           this.pos = new Vector2(x,y);
            this.Obstacle = ob;
        }



        public Node Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int G
        {
            get { return _G; }
            set { _G = value; }
        }

        public int H
        {
            get { return _H; }
            set { _H = value; }
        }

        public int F
        {
            get { return G+H; }
        }

        public void CalculerG(int horizontal, int diagonal)
        {
            if (this.Parent != null)
            {
                var temp = this;
                var g = DifferenceSurDeuxAxes(this.pos,this._parent.pos) ? diagonal : horizontal; // si diagonale : 140 au depart
                while (temp.Parent != null)
                {
                    temp = temp.Parent;
                    g += temp.G;
                }
                this._G = g;
            }
        }

        public void CalculerH(Vector2 cible, int horizontal, int diagonal)
        {
            int h = 0;
            var diff = (pos - cible);
            diff = new Vector2(Math.Abs(diff.X),Math.Abs(diff.Y));
            if (diagonal < 2 * horizontal) //si diagonal est utile
            {
                while (diff.X > 0 && diff.Y > 0)
                {
                    h += diagonal;
                    diff -= new Vector2(1, 1);
                }

                while (diff.X + diff.Y > 0)
                {
                    h += horizontal;
                    diff.X -= 1;

                }
            }
            else //sinon inutile : on compte le nombre de deplacement
            {
                while (diff.X + diff.Y > 0)
                {
                    h += horizontal;
                    diff.X -= 1;

                }
            }

            this._H = h;
        }


        public int SimulateCalculerG(Node parent, int horizontal, int diagonal)
        {
            if (parent != null)
            {
                Node temp;
                var g = DifferenceSurDeuxAxes(this.pos,parent.pos) ? diagonal : horizontal; // si diagonale : 140 au depart
                temp = parent;
                g += temp.G;
                while (temp.Parent != null)
                {
                    temp = temp.Parent;
                    g += temp.G;
                }
                return g;
            }
            return -1;
        }

        public bool DifferenceSurDeuxAxes(Vector2 v1, Vector2 v2)
        {
            var tx = v1.X - v2.X;
            var ty = v1.Y - v2.Y;
            return Math.Abs(tx + ty) > 1;
        }
    }
}
