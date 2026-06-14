using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    // GET /api/orders
    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = new[]
        {
            new { Id = 1, Product = "Laptop" },
            new { Id = 2, Product = "Mouse" }
        };

        return Ok(orders);
    }

    // GET /api/orders/42
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        if (id <= 0)
            return BadRequest("L'id doit être positif");

        if (id > 100)
            return NotFound();

        return Ok(new { Id = id, Product = "Laptop", Quantity = 1, Status = "Pending" });
    }

    // POST /api/orders
    [HttpPost]
    public IActionResult Create([FromBody] CreateOrderRequest request)
    {
        var createdOrder = new
        {
            Id = new Random().Next(1, 1000),
            Product = request.Product,
            Quantity = request.Quantity,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };

        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }
}
