namespace GameBox.ViewModel
{
    public class CommonPropViewModel
    {
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Suppoted Devices")]
        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Description")]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;


    }
}
