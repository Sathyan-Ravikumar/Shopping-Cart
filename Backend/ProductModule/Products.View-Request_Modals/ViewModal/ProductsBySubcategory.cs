namespace Products.View_Request_Modals.ViewModal
{
    public class ProductsBySubcategory
    {
        public int ProductId {  get; set; }

        public string Name { get; set;}
        public decimal Price { get; set;}

        public string Brand { get; set;}

        public List<ProductImages_ViewModal> PrimaryImage { get; set; }
    }
}
