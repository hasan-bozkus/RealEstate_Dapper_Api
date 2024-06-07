﻿namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class GetProductByProductIdDto
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string SlugUrl { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Dİstrict { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string CoverImage { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}
