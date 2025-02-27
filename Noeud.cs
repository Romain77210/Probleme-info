using System.Drawing;

namespace WinFormsApp1
{
    internal class Noeud
    {
        public int ID { get; }
        public Point Position { get; set; }

        public Noeud(int id, Point position)
        {
            ID = id;
            Position = position;
        }

        public void Dessiner(Graphics g)
        {
            int rayon = 20;
            Brush fond = new SolidBrush(Color.Blue);
            Pen contour = new Pen(Color.White, 2);
            Font font = new Font("Arial", 10, FontStyle.Bold);
            Brush texte = new SolidBrush(Color.White);

            g.FillEllipse(fond, Position.X - rayon, Position.Y - rayon, 2 * rayon, 2 * rayon);
            g.DrawEllipse(contour, Position.X - rayon, Position.Y - rayon, 2 * rayon, 2 * rayon);
            g.DrawString(ID.ToString(), font, texte, Position.X - 10, Position.Y - 8);
        }
    }
}
