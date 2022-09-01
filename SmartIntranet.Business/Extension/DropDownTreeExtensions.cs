using SmartIntranet.DTO.DTOs.CommonUseDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Linq;

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
        public static IList<TreeDto> BuildTrees(this IList<Category> positions)
        {
            var dtos = positions.Select(c => new TreeDto
            {
                Id = c.Id,
                Text = c.Name,
                ParentId = c.ParentId,
                
            }).ToList();

            return BuildTrees(null, dtos);
        }
        private static IList<TreeDto> BuildTrees(int? pid, List<TreeDto> candicates)
        {
            if (candicates.Any(c => c.ParentId == null))
            {
                var subs = candicates.Where(c => c.ParentId == pid).ToList();
                if (subs.Count == 0)
                {
                    return new List<TreeDto>();
                }
                foreach (var i in subs)
                {
                    i.Children = BuildTrees(i.Id, candicates);
                }
                return subs;
            }
            else
            {
                var subs = candicates.Where(c => c.ParentId > 0).ToList();
                if (subs.Count == 0)
                {
                    return new List<TreeDto>();
                }
                foreach (var i in subs)
                {
                    i.ParentId = pid;
                    i.Children = BuildTrees(i.Id, candicates);
                }
                return subs;
            }

        }
    }
}
