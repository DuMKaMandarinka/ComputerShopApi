namespace ComputerShopApi.WorkLogics
{
    public class TypeProduct
    {
        public int TypeId { get; set; }

        public int? ProductId { get; set; }

        public int? Limit { get; set; }
    }

    public class SoloSetProduct
    {
        public List<TypeProduct> TypeProducts { get; set; }
    }
}
