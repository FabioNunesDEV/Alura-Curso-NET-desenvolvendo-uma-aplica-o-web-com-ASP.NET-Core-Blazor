﻿namespace ScreenSound.API.Requests;
public record ArtistaRequestEdit(
    int Id,
    string nome,
    string bio,
    string fotoPerfil
    ) : ArtistaRequest(nome, bio);