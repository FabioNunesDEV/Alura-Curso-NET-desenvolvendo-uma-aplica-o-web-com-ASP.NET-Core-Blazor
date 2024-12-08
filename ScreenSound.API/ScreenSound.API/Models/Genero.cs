namespace ScreenSound.API.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } = string.Empty;

        public virtual ICollection<Musica> Musicas { get; set; } //Propriedade de navegação

        public override string ToString()
        {
            return $"Nome: {Nome} - Descrição: {Descricao}";
        }
    }
}
