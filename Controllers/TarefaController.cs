using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_ToDoList.Models;

namespace Projeto_ToDoList.Controllers
{
    public class TarefaController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar() {
            //Caso a pessoa digite a url /tarefa/cadastrar mas não há usuário logado ele redireciona para o login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("emailUsuario"))) {
                return RedirectToAction("Login", "Usuario");
            }
            else {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form) {
            int i;
            string[] lines;
            string emaillogado = HttpContext.Session.GetString("emailUsuario");
            TarefaModel tarefa = new TarefaModel();

            tarefa.Nome = form["nome"];
            tarefa.Tipo = form["tipo"];
            tarefa.Descricao = form["descricao"];
            tarefa.DataCriacao = DateTime.Now;
            tarefa.Quando = DateTime.Parse(form["quando"]);

            //Se o arquivo já existe, conta quantas tarefas tem para setar o Id
            if (System.IO.File.Exists("tarefas.csv")) {
                lines = System.IO.File.ReadAllLines("tarefas.csv");
                tarefa.Id = lines.Length + 1;
            }
            //Se não começa de outra forma...
            else {
                tarefa.Id = 1;
            }

            //Definindo o id do usuário logado da qual é responsável pela tarefa
            if (System.IO.File.Exists("usuarios.csv")) {
                lines = System.IO.File.ReadAllLines("usuarios.csv");

                for (i=0; i<lines.Length; i++) {
                    if ( lines[i].Contains(emaillogado) ){
                        //Pega o primeiro caractere da linha que é o id
                        tarefa.IdUsuario = int.Parse( lines[i].Substring(0,1) );
                    }
                }
            }

            StreamWriter sw = new StreamWriter("tarefas.csv");
            sw.WriteLine($"{tarefa.Id};{tarefa.Nome};{tarefa.Descricao};{tarefa.Tipo};{tarefa.Quando};{tarefa.IdUsuario};{tarefa.DataCriacao}");
            sw.Close();

            ViewBag.Mensagem = "Tarefa cadastrada!!";
            return View();
        }
    }
}