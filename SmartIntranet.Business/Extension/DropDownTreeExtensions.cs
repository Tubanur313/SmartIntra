using SmartIntranet.DTO.DTOs.CommonUseDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartIntranet.Business.Extension
{
    public static class DropDownTreeExtensions
    {
        public static IList<TreeDto> BuildTrees(this IList<Company> companies)
        {
            var dtos = companies.Select(c => new TreeDto
            {
                Id = c.Id,
                Text = c.Name,
                ParentId = c.ParentId
            }).ToList();

            return BuildTrees(null, dtos);
        }
        public static IList<TreeDto> BuildTrees(this IList<Department> departments)
        {
            var dtos = departments.Select(c => new TreeDto
            {
                Id = c.Id,
                Text = c.Name,
                ParentId = c.ParentId
            }).ToList();

            return BuildTrees(null, dtos);
        }        
        public static IList<TreeDto> BuildTrees(this IList<Position> positions)
        {
            var dtos = positions.Select(c => new TreeDto
            {
                Id = c.Id,
                Text = c.Name,
                ParentId = c.ParentId
            }).ToList();

            return BuildTrees(null, dtos);
        }        
        public static IList<TreeDto> BuildTrees(this IList<CategoryTicket> positions)
        {
            var dtos = positions.Select(c => new TreeDto
            {
                Id = c.Id,
                Text = c.Name,
                ParentId = c.ParentId,
                TicketType = c.TicketType
                
            }).ToList();

            return BuildTrees(null, dtos);
        }
        private static IList<TreeDto> BuildTrees(int? pid, List<TreeDto> candicates)
        {
            var subs = candicates.Where(c => c.ParentId == pid).ToList();
            if (subs.Count() == 0)
            {
                return new List<TreeDto>();
            }
            foreach (var i in subs)
            {
                i.Children = BuildTrees(i.Id, candicates);
            }
            return subs;
        }
    }
}
