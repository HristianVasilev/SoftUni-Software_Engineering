namespace WebShopDemo.gRPC.Services
{
    using Google.Protobuf.WellKnownTypes;
    using Grpc.Core;
    using System.Threading.Tasks;
    using WebShopDemo.Core.Contracts;

    public class ProductGrpcService : Product.ProductBase
    {
        private IProductService productService;

        public ProductGrpcService(IProductService productService)
        {
            this.productService = productService;
        }

        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        {
            ProductList result = new ProductList();
            var products = await productService.GetAll();

            result.Items.AddRange(products.Select(p => new ProductItem()
            {
                Name = p.Name,
                Id = p.Id.ToString(),
                Price = (double)p.Price,
                Quiantity = p.Quantity
            }));
            return result;
        }
    }
}
