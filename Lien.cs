namespace WinFormsApp1
{
    internal class Lien
    {
        public Noeud Noeud1 { get; }
        public Noeud Noeud2 { get; }

        public Lien(Noeud n1, Noeud n2)
        {
            Noeud1 = n1;
            Noeud2 = n2;
        }
    }
}
