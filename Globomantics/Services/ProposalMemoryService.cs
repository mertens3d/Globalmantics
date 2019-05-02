using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Services
{
    public class ProposalMemoryService : IProposalService
    {
        private readonly List<ProposalModel> _proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            _proposals.Add(new ProposalModel()
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding APT.NET Core Security"
            });

            _proposals.Add(new ProposalModel()
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "John Reynolds",
                Title = "Starting Your Developer Career"
            });
            _proposals.Add(new ProposalModel()
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Stan Lipens",
                Title = "ASP.NET Core TagHelpers"
            });
        }

        public Task Add(ProposalModel model)
        {
            model.Id = _proposals.Max(p => p.Id) + 1;
            _proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = _proposals
                    .First(x => x.Id == proposalId);
                if (proposal != null)
                {
                    proposal.Approved = true;
                }

                return proposal;

            });
        }


        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => _proposals.Where(x => x.ConferenceId == conferenceId));
        }
    }
}
