using SmartIntranet.DTO.DTOs.CommonUseDto;
using SmartIntranet.Entities.Concrete.Intranet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartIntranet.Business.Extension
{
    public static class DropDownTreeExtensions
    {
        public static IList<TreeDto> BuildTreesCompany(this IList<Company> companies)
        {
            var dtos = companies.Select(c => new TreeDto
            {
                Id = c.Id,
                Text = c.Name,
                ParentId = c.ParentId
            }).ToList();

            return BuildTreesCompany(null, dtos);
        }

        private static IList<TreeDto> BuildTreesCompany(int? pid, List<TreeDto> candicates)
        {
            var subs = candicates.Where(c => c.ParentId == pid).ToList();
            if (subs.Count() == 0)
            {
                return new List<TreeDto>();
            }
            foreach (var i in subs)
            {
                i.Children = BuildTreesCompany(i.Id, candicates);
            }
            return subs;
        }
    }
}
