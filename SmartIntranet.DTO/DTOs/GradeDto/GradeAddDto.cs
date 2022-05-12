using System;


namespace SmartIntranet.DTO.DTOs.GradeDto
{
    public class GradeAddDto
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
