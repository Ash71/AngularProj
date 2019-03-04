namespace AngularProj.ViewModels
{
    public class ProductVM
    {
        public string Id {get; set; }        
        public string Title { get; set; }
        public string Slug { get; set; }        
        public string Description { get; set; }        
        public string Condition { get; set; }         
        public string Quantity { get; set; }
        public int Price { get; set; }        
        public bool Deleted { get; set; }         
        public bool IsActive { get; set; }
    }
}