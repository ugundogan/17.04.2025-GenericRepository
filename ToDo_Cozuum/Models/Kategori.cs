namespace ToDo_Cozuum.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Eylem>? Eylemler { get; set; }
    }
}
