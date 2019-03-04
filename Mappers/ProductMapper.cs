using System;
using AngularProj.Entities;
using AngularProj.ViewModels;

namespace AngularProj.Mappers
{
    public static class ProductMapper
    {
        public static Func<Product, ProductVM> Map_Product_ProductVM = (c) => (new ProductVM
        {
            Title = c.Title,
            Slug = c.Slug,
            Description = c.Description,
            Condition = c.Condition,
            Quantity = c.Quantity,
            Price = c.Price            
        });
    }
}