namespace WindowsFormsAppGMmatos.Models
{
    public class Materiel
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Designation { get; set; }
        public string Categorie { get; set; }
        public int Quantite { get; set; }
        public decimal PrixJour { get; set; }
        public string Etat { get; set; }
    }
}
