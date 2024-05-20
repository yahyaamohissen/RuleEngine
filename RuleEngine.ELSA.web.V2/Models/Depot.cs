using System.ComponentModel.DataAnnotations;

namespace RuleEngine.ELSA.web.V2.Models
{
    public class Depot
    {
        [Key]
        public int ID { get; set; }
        public string DepotName { get; set; }
        public string DepotCode { get; set; }
        public bool? IsClickAndCollect { get; set; }
        public bool? IsDelivery { get; set; }
        public bool? IsCapable { get; set; }
        public bool? IsOpen { get; set; }
    }
}