using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Crawler.Utils.Pathfinding
{
    public class PathfindingAStart
    {

        private static PathfindingAStart _singleton;

        private int vertical;
        private int diag;

        public static PathfindingAStart Singleton(int vertical=100, int diag=140, bool force = false)
        {
            if(_singleton==null || force)
                _singleton = new PathfindingAStart(vertical,diag);
            return _singleton;
        }

        private PathfindingAStart(int vertical, int diag)
        {
            this.vertical = vertical;
            this.diag = diag;
        }


        /// <summary>
        /// REtourne le chemin possible entre le depart et son arrivée
        /// </summary>
        /// <param name="tab">Labyrinthe, avec 9 = 0bstacle, int[y,x]</param>
        /// <param name="depart"></param>
        /// <param name="arrive"></param>
        /// <returns></returns>
        public List<Node> FindPath(int[,] tab, Vector2 depart, Vector2 arrive)
        {
            var tabNode = PreparerTableau(tab);
            var result = new List<Node>();
            var listeOuverte = new List<Node>();
            var listeFerme = new List<Node>();
            if (!tabNode[(int) depart.X, (int) depart.Y].Obstacle && !tabNode[(int) arrive.X, (int) arrive.Y].Obstacle)
            {
                listeOuverte.Add(tabNode[(int) depart.X, (int) depart.Y]);
                while (listeOuverte.Count>0 && !listeFerme.Contains(tabNode[(int) arrive.X,(int) arrive.Y]))
                {
                    //on recupere le plus petit F de la liste ouverte
                    listeOuverte = listeOuverte.OrderBy(cont => cont.F).ToList();
                    var current = listeOuverte.First();
                    //on le vire de la liste ouverte
                    listeOuverte.Remove(current);
                    //on ajoute à la liste fermé
                    listeFerme.Add(current);
                    foreach (var node in GetAdjacents(current.pos, tabNode))
                    {
                        //obstalce ou deja dans liste fermée, ou c'est le depart; on skipe
                        if (node.Obstacle || listeFerme.Contains(node) || node.pos==depart)
                            continue;

                        //si pas dans liste ouverte
                        if (!listeOuverte.Contains(node))
                        {//on l'ajoute et on indique son parent
                            listeOuverte.Add(node);
                            node.Parent = current;
                            node.CalculerG(this.vertical,this.diag);
                            node.CalculerH(arrive, this.vertical,this.diag);

                        }
                        else if (listeOuverte.Contains(node))
                        {
                            var newG = node.SimulateCalculerG(current, this.vertical,this.diag);
                            if (newG < node.G && newG > 0)
                            {
                                node.Parent = current;
                                node.CalculerG(this.vertical, this.diag);
                            }
                        }
                    }
                }

            }

            var t = tabNode[(int) arrive.X, (int) arrive.Y];
            //si l'arrivée à un parent, le chemin est faisable
            while(t.Parent!=null)
            {
                result.Add(t);
                t = t.Parent;
            }
            if(result.Count>0)
                result.Add(t);
            return result;
        }


        private Node[,] PreparerTableau(int[,] tab)
        {

            int t1 = tab.GetLength(0);
            int t2 = tab.GetLength(1);
            var temp = new Node[t1, t2];
            for (int x = 0; x < t1; x++)
            {
                for (int j = 0; j < t2; j++)
                {
                    temp[x, j] = new Node(x, j, tab[x, j] == 9);
                }
            }
            return temp;
        }


        public List<Node> GetAdjacents(Vector2 c, Node[,] table)
        {
            List<Node> list = new List<Node>();
            bool flagXMin = c.X > 0;
            bool flagXMax = c.X < table.GetLength(0) - 1;
            bool flagYMin = c.Y > 0;
            bool flagYMax = c.Y < table.GetLength(1) - 1;
            var flagDiagoOk = this.diag < 2*this.vertical;

            if (flagXMin)
                list.Add(table[(int) (c.X - 1), (int) c.Y]);
            if (flagXMax)
                list.Add(table[(int) (c.X + 1), (int) c.Y]);

            if (flagYMin)
                list.Add(table[(int) c.X, (int) (c.Y - 1)]);
            if (flagYMax)
                list.Add(table[(int) c.X, (int) (c.Y + 1)]);
            
            var flagUseDiago = list.Count(x => !x.Obstacle) < 2; //necessité utiliser diago pour avancer
            if(flagDiagoOk || (flagUseDiago)) //si les diago sont ok pour utiliser ou si on a pas le choix
            {
                if(flagXMin&&flagYMin)
                    list.Add(table[(int) (c.X - 1), (int) (c.Y - 1)]);
                if(flagXMin&&flagYMax)
                    list.Add(table[(int) (c.X - 1), (int) (c.Y + 1)]);

                if(flagXMax&&flagYMin)
                    list.Add(table[(int) (c.X + 1), (int) (c.Y - 1)]);
                if(flagXMax&&flagYMax)
                    list.Add(table[(int) (c.X + 1), (int) (c.Y + 1)]);
            }

            return list;
        }
    }
}
