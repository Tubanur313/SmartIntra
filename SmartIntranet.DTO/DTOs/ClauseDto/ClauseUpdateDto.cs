﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.ClauseDto
{
    public class ClauseUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Key { get; set; }
        public bool IsDeletable { get; set; } // seed de yaranma statusu
        public bool IsBackground { get; set; } // arxa planda isledilir
    }
}
