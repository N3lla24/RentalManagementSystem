using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.ViewModel;

namespace RentalManagement.Controllers
{
    public class PurchasingController : Controller
    {
        private readonly RentalManagementContext _context;

        public PurchasingController(RentalManagementContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (GetId() == null || _context.Admin == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return _context.PurchaseOrder != null ?
                         View(await _context.PurchaseOrder.ToListAsync()) :
                         Problem("Entity set 'RentalManagementContext.PurchaseOrder'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.PurchaseOrder == null)
            {
                return NotFound();
            }

            var po = await _context.PurchaseOrder
                .Include(r => r.Supplier)
                .Include(r => r.PurchaseItems)
                .Include(r => r.PurchaseServices)
                .FirstOrDefaultAsync(r => r.PurchaseOrderId == id);

            if (po == null)
            {
                return NotFound();
            }

            return View(po);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("adminid");
            return RedirectToAction("Index", "Home");
        }
        private int? GetId()
        {
            var id = HttpContext.Session.GetInt32("adminid");
            if (id is not null) { return id; }
            return null;
        }

        public IActionResult ReceivingMemo(int? id)
        {
            var purchaseOrder = _context.PurchaseOrder
            .Include(po => po.PurchaseItems)
            .FirstOrDefault(po => po.PurchaseOrderId == id);

            if (purchaseOrder == null)
            {
                // Handle the case where the purchase order is not found
                return NotFound();
            }

            return View(purchaseOrder);
        }
        [HttpPost]
        public IActionResult ReceivingMemo(int purchaseOrderId, Dictionary<int, int> receivedQuantities)
        {
            var purchaseOrder = _context.PurchaseOrder
            .Include(po => po.PurchaseItems)
            .FirstOrDefault(po => po.PurchaseOrderId == purchaseOrderId);

            if (purchaseOrder == null)
            {
                // Handle the case where the purchase order is not found
                return NotFound();
            }

            foreach (var item in purchaseOrder.PurchaseItems)
            {
                if (receivedQuantities.TryGetValue(item.PurchaseItem_Id, out int receivedQuantity))
                {
                    // Check if there is an existing inventory entry for the item
                    var existingInventory = _context.Inventory
                        .FirstOrDefault(i => i.Inventory_ItemName == item.PurchaseItem_Name);

                    if (existingInventory != null)
                    {
                        // If an entry exists, update the quantity
                        existingInventory.Inventory_ItemQuantity += receivedQuantity;
                    }
                    else
                    {
                        // If no entry exists, create a new entry
                        var inventoryItem = new Inventory
                        {
                            Inventory_ItemName = item.PurchaseItem_Name,
                            Inventory_ItemQuantity = receivedQuantity,
                            Inventory_ItemUnit = item.PurchaseItem_Unit,
                            Inventory_Status = "Received Item",
                            Inventory_CreatedAt = DateTime.Now
                        };

                        _context.Inventory.Add(inventoryItem);
                    }
                }
            }

            // Update the PurchaseOrder status or any other relevant information
            purchaseOrder.PurchaseOrder_Status = "RECIEVE PURCHASED ITEM";
            purchaseOrder.PurchaseOrder_CreatedAt = DateTime.Now;

            _context.SaveChanges();

            // Redirect to the receiving memo page after updating
            return RedirectToAction("Index");
        }
    }
}
