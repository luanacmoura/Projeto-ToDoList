using System;

namespace Projeto_ToDoList.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime Quando { get; set; }
    }
}