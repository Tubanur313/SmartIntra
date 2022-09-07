namespace SmartIntranet.DTO.DTOs.ContractDto
{
    public static class ContractTypeConst
    {
        public const string WORK_ACCEPT = "WORK_ACCEPT"; // ise qebul
        public const string PERSONAL_CHG = "PERSONAL_CHG"; // kadr deyisikliyi
        public const string VACATION = "VACATION";
        public const string BUSINESS_TRIP = "BUSINESS_TRIP";
        public const string TERMINATION = "TERMINATION"; 
    }

    public static class ContractConst
    {
        public const string TEMPLATE = "TEMPLATE"; // sablon
        public const string UPLOAD_FILE = "UPLOAD_FILE"; // hazir fayl
    }

    public static class VacationTypeConst
    {
        public const string LABOR = "labor"; 
        public const string WITHOUT_PRICE = "without_price";
        public const string EDU = "edu";
        public const string PREGNANCY = "pregnancy";
        public const string SOCIAL = "social";
    }

    public static class PersonalContractConst
    {
        public const string SALARY = "SALARY"; 
        public const string POSITION = "POSITION";
        public const string SALARY_POSITION = "SALARY_POSITION";
        public const string WORK_PLACE = "WORK_PLACE";
        public const string WORK_GRAPHIC = "WORK_GRAPHIC";
        public const string VACATION = "VACATION";
    }

    public static class ContractFileReadyConst
    {
        public const string recruitment_privacy = "recruitment_privacy"; // mexfilik ise qebul
        public const string recruitment_labor_contract = "recruitment_labor_contract"; // emek muqavilesi ise qebul
        public const string recruitment_command = "recruitment_command"; // emr ise qebul
        public const string recruitment_financial_responsibility = "recruitment_financial_responsibility"; // maddi mesuliyyet ise qebul

        ////////////////// 
        public const string personal_extra = "personal_extra"; // kadr deyisikliyi elave
        public const string personal_change_command_salary = "personal_change_command_salary"; // emr kadr deyisikliyi - maas
        public const string personal_change_extra_salary = "personal_change_extra_salary"; // emr kadr deyisikliyi - maas
        public const string personal_change_command_position = "personal_change_command_position"; // emr kadr deyisikliyi - vezife
        public const string personal_change_extra_position = "personal_change_extra_position"; // emr kadr deyisikliyi - vezife
        public const string personal_change_command_salary_position = "personal_change_command_salary_position"; // emr kadr deyisikliyi - maas, vezife
        public const string personal_change_extra_salary_position = "personal_change_extra_salary_position"; // emr kadr deyisikliyi - maas, vezife

        public const string personal_work_place = "personal_change_extra_work_place"; // əsas və əlavə iş yeri kadr deyisikliyi
        public const string personal_work_graphic = "personal_change_extra_work_graphic"; // iş qrafiki kadr deyisikliyi
        public const string personal_change_extra_vacation = "personal_change_extra_vacation"; // məzuniyyət kadr deyisikliyi


        // Mezuniyyet senedleri
        public const string vacation_labor = "vacation_labor"; // emek mezuniyyeti
        public const string vacation_without_price = "vacation_without_price"; // odenissiz mezuniyyeti
        public const string vacation_edu = "vacation_edu"; // tehsil mezuniyyeti
        public const string vacation_pregnancy = "vacation_pregnancy"; // analiz mezuniyyeti
        public const string vacation_social = "vacation_social"; // sosial mezuniyyeti


        // Ezamiyyet
        public const string business_trip_command = "business_trip_command";

        // Xitam
        public const string termination_base = "termination_base";
        public const string termination_reduction_agree = "termination_reduction_agree";
        public const string termination_reduction_not_agree = "termination_reduction_not_agree";
    }
}
