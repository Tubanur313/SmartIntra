﻿using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.CompanyDto
{
    public class CompanyListDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Company Parent { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
