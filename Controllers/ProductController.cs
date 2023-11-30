
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet("getAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
    [HttpGet("getProductById")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpPost("addProduct")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _productService.AddProductAsync(product);
        return Ok(product);
    }

    [HttpPost("addManyProducts")]
    public async Task<IActionResult> AddManyProducts(List<Product> products)
    {
        await _productService.AddManyProductsAsync(products);
        return Ok();
    }

    [HttpGet("getProductByCategory")]
    public async Task<IActionResult> GetProductByCategory(string category)
    {
        var products = await _productService.GetProductsByCategory(category);
        return Ok(products);
    }

    [HttpGet("getCategoryList")]
    public async Task<IActionResult> GetCategoryList()
    {
        var categoryList = await _productService.GetCategoryList();
        return Ok(categoryList);
    }



}