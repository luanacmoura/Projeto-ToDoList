using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_ToDoList.Models;
using TaskCentral.Repositorios;

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
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            usuario.Nome = form["nome"];
            usuario.Email = form["email"];
            usuario.Senha = form["senha"];
            usuario.Tipo = form["tipo"];
            usuario.DataCriacao = DateTime.Now;
            
            usuarioRepositorio.Cadastrar(usuario);
            ViewBag.Mensagem = "Usuário cadastrado!";
            return View();
        }

        [HttpGet]
        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form) {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            UsuarioModel usuario = usuarioRepositorio.Login(form["email"], form["senha"]);

            StreamReader sr = new StreamReader("usuarios.csv");
            if (usuario!=null){
                //Está setando o email que está logado
                HttpContext.Session.SetString("emailUsuario", usuario.Email); //Aceita como parâmetro um objeto
                return RedirectToAction("Cadastrar", "Tarefa");
            }
            ViewBag.Mensagem = "Usuário inválido!";
            return View();
        }

        [HttpGet]
        public IActionResult Listar () {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            ViewData["Usuarios"] = usuarioRepositorio.Listar();

            return View ();
        }

        [HttpGet]
        public IActionResult Excluir (int id) {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

            usuarioRepositorio.Excluir(id);

            TempData["Mensagem"] = "Usuário excluído";

            return RedirectToAction ("Listar");
        }
    
        [HttpGet]
        public IActionResult Editar (int id) {
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("emailUsuario"))) {
                TempData["Mensagem"] = "Faça login!";
                return RedirectToAction("Login", "Usuario");
            }
            
            if (id == 0) {
                TempData["Mensagem"] = "Informe o id do usuário!";
                return RedirectToAction("Listar", "Usuario");
            }
            
            string[] linhas = System.IO.File.ReadAllLines("usuarios.csv");


            foreach (var item in linhas)
            {
                string[] dados =item.Split(';');
                
                if (id.ToString() == dados[0]) {
                    UsuarioModel usuario = new UsuarioModel();
                    usuario.Id = int.Parse(dados[0]);
                    usuario.Nome = dados[1];
                    usuario.Email = dados[2];
                    usuario.Senha = dados[3];
                    usuario.Tipo = dados[4];
                    usuario.DataCriacao = DateTime.Parse(dados[5]); 

                    ViewBag.Usuario = usuario;
                    break;
                }
            }
            return View();
        }

        [HttpPost]

        public IActionResult Editar (IFormCollection form) {
            //Declara um objeto e atribui os valores do form
            UsuarioModel usuario = new UsuarioModel() {
                Id = int.Parse(form["id"]),
                Nome = form["nome"],
                Email = form["email"],
                Senha = form["senha"],
                DataCriacao = DateTime.Now,
            };

            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            usuarioRepositorio.Editar(usuario);

            TempData["Mensagem"] = "Usuário editado!";
            return RedirectToAction("Listar");
        }
    }
}