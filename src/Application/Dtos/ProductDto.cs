using System;

namespace Application.Dtos
{
    public class ProductDto
    {
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public static ProductDto FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            return new ProductDto
            {
                Description = values[1],
                Active = (values[2].Trim().ToUpper() == "SIM"),
                ManufacturingDate = DateTime.Parse(values[3]),
                ExpirationDate = DateTime.Parse(values[4])
            };
        }
    }
}
