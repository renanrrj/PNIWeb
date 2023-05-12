using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PNIWeb.Model;
using PNIWeb.Model.Models;

namespace PNIWeb.View.Controllers
{
    public class PesquisaController : Controller
    {
        // GET: PesquisaController
        bd_PNIContext _db;
         public PesquisaController ()
        {
            _db = new bd_PNIContext ();
        }        

        public ActionResult pes_Index()
        {
            List <TbPesquisa> ls_Pes = _db.TbPesquisa.ToList ();
            return View(ls_Pes);
        }

        // GET: PesquisaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PesquisaController/Create
        public ActionResult pes_Adicionar()
        {
            return View();
        }

        // POST: PesquisaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pes_Adicionar(TbPesquisa _Pes)
        {
            try
            {
                _db.TbPesquisa.Add(_Pes);
                    _db.SaveChanges();
                return RedirectToAction(("pes_Index"));
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: PesquisaController/Edit/5
        public ActionResult pes_Alterar(int id)
        {
            TbPesquisa _pes = _db.TbPesquisa.Find (id);
            return View(_pes);
        }

        // POST: PesquisaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pes_Alterar(int id, TbPesquisa _Pes)
        {
            try
            {
                var xpes = _db.TbPesquisa.Find(id);
                xpes.PqNome = _Pes.PqNome;
                xpes.PqInstituicao = _Pes.PqNome;
                xpes.PqSaida = _Pes.PqSaida;
                xpes.PqEntrada = _Pes.PqEntrada;
                xpes.PqInstituicao = _Pes.PqInstituicao;
                xpes.PqTitulo = _Pes.PqTitulo;
                _db.Entry(xpes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();                
                return RedirectToAction("pes_Index");
            }
            catch
            {
                return View("pes_Index");
            }
        }

        // GET: PesquisaController/Delete/5
        public ActionResult pes_Deletar(int id)
        {
            TbPesquisa _pes = _db.TbPesquisa.Find(id);
            return View(_pes);            
        }

        // POST: PesquisaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pes_Deletar(int id, TbPesquisa _pes)
        {
            try
            {
                var xpes = _db.TbPesquisa.Find(id);
                xpes.PqNome = _pes.PqNome;
                _db.Entry(xpes).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("pes_Index");
            }
            catch
            {
                return View("pes_Index");
            }
        }
    }
}
