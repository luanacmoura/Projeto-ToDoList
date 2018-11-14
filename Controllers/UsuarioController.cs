using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_ToDoList.Models;

namespace Projeto_ToDoList.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar() {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection form) {
            UsuarioModel usuario = new UsuarioModel();
            string[] lines;


            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.Tipo = form["tipo"];
            usuario.DataCriacao = DateTime.Now;

            //Se o arquivo existe, conta as linhas e seta o valor do próximo Id
            if (System.IO.File.Exists("usuarios.csv")) {
                lines = System.IO.File.ReadAllLines("usuarios.csv");

                usuario.Id = lines.Length + 1;
            }
            //Se não existe começa no 1.
            else {
                usuario.Id = 1;
            }
                        
            StreamWriter sw = new StreamWriter("usuarios.csv", true);
            sw.WriteLine($"{usuario.Id};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Tipo};{usuario.DataCriacao}");
            sw.Close();
            
            ViewBag.Mensagem = "Usuário cadastrado!";
            return View();
        }

        [HttpGet]
        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form) {
            string[] lines;
            UsuarioModel usuario = new UsuarioModel();
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];

            StreamReader sr = new StreamReader("usuarios.csv");

            while(!sr.EndOfStream) {
                lines = sr.ReadLine().Split(";");
                if (lines[2]==usuario.Email && lines[3]==usuario.Senha) {
                    //Está setando o email que está logado
                    HttpContext.Session.SetString("emailUsuario", usuario.Email); //Aceita como parâmetro um objeto
                    return RedirectToAction("Cadastrar", "Tarefa");
                }
            }
            ViewBag.Mensagem = "Usuário inválido!";
            return View();
        }
    }
}