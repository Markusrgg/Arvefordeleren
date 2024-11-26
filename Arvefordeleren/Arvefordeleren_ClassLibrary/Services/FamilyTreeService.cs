using Arvefordeleren_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arvefordeleren_ClassLibrary.Services
{
    public class FamilyTreeService
    {
        private TestatorService _testatorService;
        private HeirService _heirService;

        public FamilyTreeService(TestatorService testatorService, HeirService heirService)
        {
            _testatorService = testatorService;
            _heirService = heirService;
        }

        //private static List<FamilyMember> familyTree = new List<FamilyMember>();
        //private static int nextId = 1;

        //// Method to find a member by ID
        //public static FamilyMember FindMemberById(int id)
        //{
        //    return familyTree.FirstOrDefault(m => m.Id == id);
        //}

        //public static FamilyMember Create(FamilyMember familyMember)
        //{
        //    var member = familyTree.Find(x => x.Id == familyMember.Id);
        //    if (member != null)
        //    {
        //        member.Id = familyMember.Id;
        //        member.Name = familyMember.Name;
        //        member.Fid = familyMember.Fid;
        //        member.Mid = familyMember.Mid;
        //        member.Pids = familyMember.Pids;
        //        member.Relation = familyMember.Relation;

        //        foreach (var member2 in familyTree)
        //        {
        //            if (member2.Pids.Contains(familyMember.Id) && !familyMember.Pids.Contains(member2.Id))
        //            {
        //                familyMember.Pids.Add(member2.Id);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        familyTree.Add(familyMember);

        //        foreach (var member2 in familyTree)
        //        {
        //            if (member2.Pids.Contains(familyMember.Id) && !familyMember.Pids.Contains(member2.Id))
        //            {
        //                familyMember.Pids.Add(member2.Id);
        //            }
        //        }
        //    }
        //    return familyMember;
        //}

        // Get family data
        //public static List<FamilyMember> GenerateFamilyData()
        //{
        //    return familyTree;
        //}

        //public static FamilyMember CreateEmptyMember()
        //{
        //    return new FamilyMember(nextId++, "");
        //}

        //public static void Delete(int id)
        //{
        //    var member = familyTree.Find(x => x.Id == id);
        //    if (member != null)
        //    {
        //        familyTree.Remove(member);
        //        foreach (var member2 in familyTree)
        //        {
        //            if (member2.Pids.Contains(id))
        //            {
        //                member2.Pids.Remove(id);
        //            }
        //            if (member2.Mid == id)
        //            {
        //                member2.Mid = null;
        //            }
        //            if (member2.Fid == id)
        //            {
        //                member2.Fid = null;
        //            }
        //        }
        //    }
        //}

        //public async List<Dictionary<string, object>> Format()
        //{
        //    List<Testator> testators = await _testatorService.GetAll();
        //    List<Heir> heirs = await _heirService.GetAll();

        //    var nodes = testators.Select(member =>
        //    {
        //        var node = new Dictionary<string, object>
        //        {
        //            { "id", member.Id },
        //            { "pids", member.Pids ?? new List<Guid>() },
        //            { "name", member.FullName },
        //            { "relation", member.RelationType.GetDisplayName() },
        //            { "img", $"/img/{member.RelationType}.png" },
        //        };

        //        //if (member.Mid.HasValue)
        //        //{
        //        //    node["mid"] = member.Mid.Value;
        //        //}
        //        //if (member.Fid.HasValue)
        //        //{
        //        //    node["fid"] = member.Fid.Value;
        //        //}

        //        return node;
        //    }).ToList();

        //    return nodes;
        //}

        public async Task<List<Dictionary<string, object>>> Format()
        {
            List<Testator> testators = await _testatorService.GetAll();
            List<Heir> heirs = await _heirService.GetAll();

            var testatorNodes = testators.Select(member =>
            {
                var node = new Dictionary<string, object>
                {
                    { "id", member.Id },
                    { "pids", member.Pids ?? new List<Guid>() },
                    { "name", member.FullName },
                    { "relation", member.RelationType.GetDisplayName() },
                    { "img", $"/img/{member.RelationType}.png" },
                };


                return node;
            });

            var heirNodes = heirs.Select(heir =>
            {
                var node = new Dictionary<string, object>
                {
                    { "id", heir.Id },
                    { "name", heir.FullName },
                    { "relation", heir.RelationType.GetDisplayName() },
                    { "img", $"/img/{heir.RelationType}.png" },
                };

                if (heir.Mid != Guid.Empty)
                {
                    node["mid"] = heir.Mid;
                }
                if (heir.Fid != Guid.Empty)
                {
                    node["fid"] = heir.Fid;
                }

                return node;
            });

            // Combine both lists into one
            var combinedNodes = testatorNodes.Concat(heirNodes).ToList();

            return combinedNodes;
        }
    }
}

