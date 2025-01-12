namespace ScreenSound.API.Response;
//public record MusicaResponse(
//    int Id,
//    string Nome,
//    int ArtistaId,
//    string NomeArtista
//    );

public record MusicaResponse(
    int Id,
    string Nome,
    int ArtistaId,
    string NomeArtista,
    List<string> Generos
    );