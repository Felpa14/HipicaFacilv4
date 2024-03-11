using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HipicaFacilv4.Context;
using static HipicaFacilv4.Context.ApplicationDbContext;

namespace HipicaFacilv4.Pages
{
    public class EstoqueModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EstoqueModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produto NovoProduto { get; set; }

        public List<Produto> Produtos { get; set; }

        public void OnGet()
        {

            Produtos = _context.Produtos.ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(NovoProduto);
                _context.SaveChanges();
                return RedirectToPage("./Estoque");
            }
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
            return RedirectToPage("./Estoque");
        }

        public IActionResult OnPostAtualizar(int id)
        {
            var produtoExistente = _context.Produtos.Find(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            produtoExistente.Nome = NovoProduto.Nome;
            produtoExistente.Validade = NovoProduto.Validade;
            produtoExistente.Quantidade = NovoProduto.Quantidade;

            _context.SaveChanges();

            return RedirectToPage("./Estoque");
        }
    }
}
