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

            var combinedNodes = testatorNodes.Concat(heirNodes).ToList();

            return combinedNodes;
        }
    }
}

