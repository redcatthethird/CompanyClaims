using CompanyClaims.Api.Services;
using CompanyClaims.Core.Models;
using CompanyClaims.Data.Repos.Interfaces;

using Moq;

namespace CompanyClaims.Api.Test.Services;

public class ClaimsServiceTest
{
    [Fact]
    public async Task UpdateClaim_ShouldUpdate_IsClosed()
    {
        string? testUcr = nameof(testUcr);
        var testClaim = new Claim
        {
            UniqueClaimReference = testUcr,
            IsClosed = false
        };

        var mockRepo = new Mock<IClaimRepo>();
        mockRepo.Setup(repo => repo.GetByUcr(testUcr))
            .ReturnsAsync(testClaim);

        var service = new ClaimService(mockRepo.Object);
        var success = await service.TryUpdateClaim(testUcr, new()
        {
            IsClosed = true,
        });

        mockRepo.Verify(repo => repo.Update(testClaim));
        Assert.True(testClaim.IsClosed);
    }
}