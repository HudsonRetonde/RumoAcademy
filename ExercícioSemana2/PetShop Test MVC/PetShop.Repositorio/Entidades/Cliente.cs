using System;
using System.Collections.Generic;

namespace PetShop.Repositorio.Entidades;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public DateTime DataNascimento { get; set; }
}
