﻿using System.Collections.ObjectModel;

namespace APIPontoColaborador.Models;

public class Cargos
{
    public Cargos() 
    {
        Funcionarios = new Collection<Funcionarios>();
    }
    public int CargoId { get; set; }
    public string? DescricaoCargo { get; set; }
    public ICollection<Funcionarios> Funcionarios { get; set; } 
}
