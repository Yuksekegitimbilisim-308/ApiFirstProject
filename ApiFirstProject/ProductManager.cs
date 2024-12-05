using ApiFirstProject.DTOs;

namespace ApiFirstProject
{
    public class ProductManager
    {
        private readonly IList<Product> _products = new List<Product>();
        public ProductManager()
        {
            _products.Add(new Product() { Id = 1, Name = "Kalem", Price = 150, Stock = 40, CategoryName = "Kırtasiye" });
            _products.Add(new Product() { Id = 2, Name = "Elma", Price = 35, Stock = 400, CategoryName = "Meyve" });
            _products.Add(new Product() { Id = 3, Name = "Monitör", Price = 1500, Stock = 10, CategoryName = "Elektronik" });
            _products.Add(new Product() { Id = 4, Name = "Pantolon", Price = 800, Stock = 4000, CategoryName = "Giyim" });
        }
        public Result<List<ListProductResultDto>> GetAllProducts()
        {
            var result = _products.Select(x => new ListProductResultDto()
            {
                Name = x.Name,
                Price = x.Price,
                CategoryName = x.CategoryName
            }).ToList();
            return Result<List<ListProductResultDto>>.Success(200, result);

        }
        public Result<SingleProductResultDto> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            SingleProductResultDto dto = new()
            {
                Name = product.Name,
                CategoryName = product.CategoryName,
                Price = product.Price,
                Stock = product.Stock,
            };
            return Result<SingleProductResultDto>.Success(200, dto);
        }
        public Result<CreateProductDto> AddProduct(CreateProductDto productDto)
        {

            int id = _products.LastOrDefault().Id + 1;
            if (_products.Any(x => x.Name == productDto.Name))
            {
                return Result<CreateProductDto>.Fail(400, "Bu İsimde Ürün Zaten Mevcut.");
            }

            var product = new Product()
            {
                Id = id,
                CategoryName = productDto.CategoryName,
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CreatedDate = DateTime.Now
            };
            _products.Add(product);
            return Result<CreateProductDto>.Success(201, productDto);
        }
        public Result<UpdateProductDto> UpdateProduct(int id, UpdateProductDto productDto)
        {
            if (id == productDto.Id)
            {
                Product current = _products.FirstOrDefault(x => x.Id == id);
                current.Name = productDto.Name;
                current.Price = productDto.Price;
                current.Stock = productDto.Stock;
                current.CategoryName = productDto.CategoryName;
                current.LastUpdateTime = DateTime.Now;
            }
            return Result<UpdateProductDto>.Success(200, productDto);
        }
        public Result<Product> RemoveProduct(int id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(product);
            return Result<Product>.Success(200);
        }
        public Result<ProductCategoryStoreResultDto> ProductInfoWithStore(int id)
        {
            Product product = _products.FirstOrDefault(p => p.Id == id);

            ProductCategoryStoreResultDto dto = new()
            {
                CategoryName = product.CategoryName,
                Price = product.Price,
                ProductName = product.Name,
                Stock = product.Stock,
                StoreName = "Mağaza 1",
                Vergino = 64648948943612984
            };

            return Result<ProductCategoryStoreResultDto>.Success(200, dto);
        }


    }
}
