using PCF_POC.Data;
using System.Collections.Generic;

namespace PCF_POC.Models.HomeViewModels
{
    public class RecommendationViewModel
    {
        public IEnumerable<Equipment> equipments { get; set; }
        public IEnumerable<Package> packages { get; set; }
    }
}
