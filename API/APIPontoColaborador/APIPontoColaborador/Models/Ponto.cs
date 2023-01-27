﻿using System.ComponentModel.DataAnnotations;

namespace APIPontoColaborador.Models
{
    public class Ponto
    {
        [Key] 
        public int PontoId { get; set; }
        public DateTime DataHorarioPonto { get; set; }
        public string? Justificativa { get; set; }
        public int Funcionario_FuncionarioId { get; set; }
        public virtual Funcionario? Funcionarios { get; set; }
    }
}
