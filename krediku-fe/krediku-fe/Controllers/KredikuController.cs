using krediku_fe.Models;
using krediku_fe.Models.Backend;
using krediku_fe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace krediku_fe.Controllers
{
    public class KredikuController : Controller
    {
        private IKredikuService _kredikuService;
        public KredikuController(IKredikuService kredikuService)
        {
            _kredikuService = kredikuService;
        }
        
        public async Task<IActionResult> Index()
        {
            ApiMessage<List<Transaction>> trans = await _kredikuService.GetTransactions();

            if(trans.isSuccess)
            {
                List<TranViewModel> addTranViewModel = new List<TranViewModel>();
                addTranViewModel = (from a in trans.data
                                    select new TranViewModel
                                    {
                                        NoAgreement = a.AgreementNumber,
                                        BranchId = a.BranchId,
                                        DateFaktur = a.FakturDate,
                                        Location = a.LocationName,
                                        NoBPKB = a.BpkbNumber,
                                        NoFaktur = a.FakturNumber,
                                        NoPolis = a.PoliceNumber,
                                        DateInput = a.BpkbDateInput,
                                        DateBPKB = a.BpkbDate
                                    }).ToList();
                ViewData.Model = addTranViewModel;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddTran()
        {
            ApiMessage<List<Location>> locs = await _kredikuService.GetLocations();
            if(locs.isSuccess)
            {
                ViewData["locations"] = new SelectList(locs.data, "Id", "Name");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTran(AddTranViewModel tran)
        {
            if (ViewData["locations"] == null)
            {
                ApiMessage<List<Location>> locs = await _kredikuService.GetLocations();
                if (locs.isSuccess)
                {
                    ViewData["locations"] = new SelectList(locs.data, "Id", "Name");
                }
            }

            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Input data tidak valid";
                return View();
            }

            Transaction newTran = new Transaction()
            {
                AgreementNumber = tran.NoAgreement,
                BpkbDate = tran.DateBPKB,
                BpkbDateInput = tran.DateInput,
                BpkbNumber = tran.NoBPKB,
                BranchId = tran.BranchId,
                FakturDate = tran.DateFaktur,
                FakturNumber = tran.NoFaktur,
                LocationId = tran.LocationId,
                PoliceNumber = tran.NoPolis                
            };

            ApiMessage<Transaction> addTran = await _kredikuService.AddTransaction(newTran);
            if(addTran.isSuccess)
            {
                TempData["TransactionReponse"] = "Data berhasil disimpan";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = addTran.message;
                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CancelProses()
        {
            return RedirectToAction("Index");
        }
    }
}
