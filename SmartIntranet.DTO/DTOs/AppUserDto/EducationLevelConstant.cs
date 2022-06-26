using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class EducationLevelConstant
    {
        public const string PRIMARY_VOCATIONAL = "PRIMARY_VOCATIONAL"; // İlkin peşə təhsili
        public const string GENERAL_SECONDARY = "GENERAL_SECONDARY"; // umumi orta
        public const string VOCATIONAL = "VOCATIONAL"; // orta ixtisas
        public const string BACHELORS = "BACHELORS"; // bakalavr
        public const string MASTER = "MASTER"; // magistratura
    }

    public class IdCardTypeConstant
    {
        public const string NATIVE = "NATIVE"; // - Şəxsiyyət vəsiqəsi
        public const string DYI = "DYI"; // Daimi yaşayış icazəsi vəsiqəsi
        public const string MYI = "MYI"; // Müvəqqəti yaşayış icazəsi vəsiqəsi
    }


    public class LevelType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
