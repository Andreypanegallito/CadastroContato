using WebApplication3.Repositorio;
using WebApplication3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                var apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";

                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não foi possível apagar o contato, tente novamente.";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar o contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index"); 
            }

        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar o contato, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
           
        }
    }
}
