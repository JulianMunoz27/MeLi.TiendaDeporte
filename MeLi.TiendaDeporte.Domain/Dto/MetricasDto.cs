﻿using System.Text.Json.Serialization;

namespace MeLi.TiendaDeporte.Domain.Dto
{
    public class MetricasDto
    {
        public int total_products { get; set; }
        [JsonIgnore]
        public string top_categoriesString { get; set; }
        public List<string> top_categories { get; set; }
        public int total_stock { get; set; }
        public decimal average_price { get; set; }
    }
}
