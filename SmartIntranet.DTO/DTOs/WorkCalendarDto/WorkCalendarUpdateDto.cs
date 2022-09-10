using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.WorkCalendarDto
{
    public class WorkCalendarUpdateDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Month { get; set; }
        public int Day { get; set; }
        public int? WorkGraphicId { get; set; }
        public WorkGraphic WorkGraphic { get; set; }
        public int? NonWorkingYearId { get; set; }
        public NonWorkingYear NonWorkingYear { get; set; }
    }
}
