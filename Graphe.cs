using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    internal class Graphe
    {
        private List<Noeud> noeuds;
        private List<Lien> liens;

        public Graphe()
        {
            noeuds = new List<Noeud>();
            liens = new List<Lien>();
        }

        public void AjouterNoeud(int id)
        {
            if (!noeuds.Exists(n => n.ID == id))
            {
                noeuds.Add(new Noeud(id, new Point(0, 0)));
            }
        }

        public void AjouterLien(int id1, int id2)
        {
            Noeud noeud1 = noeuds.Find(n => n.ID == id1);
            Noeud noeud2 = noeuds.Find(n => n.ID == id2);
            if (noeud1 != null && noeud2 != null &&
                !liens.Exists(l => (l.Noeud1 == noeud1 && l.Noeud2 == noeud2) || (l.Noeud1 == noeud2 && l.Noeud2 == noeud1)))
            {
                liens.Add(new Lien(noeud1, noeud2));
            }
        }

        public void PositionnerNoeuds(int width, int height)
        {
            int rayon = Math.Min(width, height) / 3;
            int centerX = width / 2;
            int centerY = height / 2;
            int count = noeuds.Count;

            for (int i = 0; i < count; i++)
            {
                double angle = 2 * Math.PI * i / count;
                int x = centerX + (int)(rayon * Math.Cos(angle));
                int y = centerY + (int)(rayon * Math.Sin(angle));
                noeuds[i].Position = new Point(x, y);
            }
        }

        public void Dessiner(Graphics g, int width, int height)
        {
            Pen lienPen = new Pen(Color.Gray, 2);
            foreach (var lien in liens)
            {
                g.DrawLine(lienPen, lien.Noeud1.Position, lien.Noeud2.Position);
            }

            foreach (var noeud in noeuds)
            {
                noeud.Dessiner(g);
            }
        }
    }
}
